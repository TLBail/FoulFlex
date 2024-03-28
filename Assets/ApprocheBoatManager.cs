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

    private void Update() {
        //gamepad button 0 is press
        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            ammarage();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            boatentry();
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
