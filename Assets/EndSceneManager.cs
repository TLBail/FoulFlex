using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textFin;
    private void Start() {
        textFin.text = "Vous avez terminé le jeu avec " + GameManager.Instance.point + " points";
    }

    
    private void Update() {
        //gamepad button 0 is press
        if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            ressayer();
        }

    }


    public void ressayer() {
        GameManager.Instance.Reset();
        SceneManager.LoadScene(1);
    }
}
