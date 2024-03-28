using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortManager : MonoBehaviour
{

    [SerializeField] public Serial serial;
    [SerializeField] public TMPro.TMP_Text textNomPort;
    [SerializeField] public GameObject portGameObject;
    [SerializeField] public ParticleSystem particleSystem;
    [SerializeField] public TMPro.TMP_Text textFouling;

    private void Start() {
        textNomPort.text = "Port numéro : " + GameManager.Instance.indexPort;
        GameManager.Instance.date = GameManager.Instance.date.AddDays(4);
        
        textFouling.text = "Fouling : " + (GameManager.Instance.Fooling * 100).ToString("0.0") + " %";
        
    }


    public void partir() {
        SceneManager.LoadScene(1);
        GameManager.Instance.IncreaseFooling();
    }
    
    
    private void Update() {
        //gamepad button 0 is press
        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            partir();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            clean();
        }

    }

    

    public void clean() {
        StartCoroutine("portFlip");
    }


    IEnumerator portFlip() {
        particleSystem.Play();
        Animator animation = portGameObject.GetComponent<Animator>();
        animation.SetTrigger("clean");
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.Fooling = 0;
        serial.clean();
        SceneManager.LoadScene(1);
    }
}
