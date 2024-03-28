using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ApprocheBoatManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    

    private void Start() {
        GameManager.Instance.date = GameManager.Instance.date.AddDays(2);
        
        
        
    }

    private bool isammaring = false;
    private void Update() {
        if(isammaring) return;
        //gamepad button 0 is press
        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            isammaring = true;
            ammarage();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            isammaring = true;
            nettoyageEnMer();
        }

    }


    public void ammarage() {
        StartCoroutine("boatentry");
    }
    

    IEnumerator boatentry() {
        animator.SetTrigger("boatentry");
        
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(3);
        
    }


    public void nettoyageEnMer() {
        SceneManager.LoadScene(3);
    }
}
