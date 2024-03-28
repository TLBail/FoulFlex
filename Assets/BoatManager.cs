using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatManager : MonoBehaviour
{

    [SerializeField] public CarteManager carteManager;
    private Rigidbody2D rb;
    private float timeSinceLastPress = 0;

    public AnimationCurve curve;
    
    public bool haveMoveAtLeastOnce = false;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Transform portTransform = carteManager.getPortActuel();
        transform.position = new Vector3(portTransform.transform.position.x,
            portTransform.transform.position.y, transform.position.z);
        
        haveMoveAtLeastOnce = false;

    }


    private void Update() {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal) <= 0.1f && Mathf.Abs(vertical) <= 0.1f) {
            if (haveMoveAtLeastOnce) {
                timeSinceLastPress += Time.deltaTime;
                GameManager.Instance.Fooling += curve.Evaluate(timeSinceLastPress) / 1000;
                if(GameManager.Instance.Fooling > 1) {
                    GameManager.Instance.Fooling = 1;
                }
            }
        } else {
            haveMoveAtLeastOnce = true;
            timeSinceLastPress = 0;
            
            Vector3 targentAngle = new Vector3(0, 0, Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targentAngle), Time.deltaTime * 80);
            Debug.Log(targentAngle);
        
        
            Vector3 vectorForward = new Vector3(
                Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.Deg2Rad),
                0
            );
            
            rb.AddForce(vectorForward * (GameManager.Instance.vitesse * Time.deltaTime * 30));
        }
      

    }


}
