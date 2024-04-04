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
        textNomPort.text = "Port " + GameManager.Instance.nomPorts[GameManager.Instance.indexPort];
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
            clean();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
            partir();
        }

    }

    

    public void clean() {
        StartCoroutine("portFlip");
    }

    [SerializeField] private OSC osc;

    IEnumerator portFlip() {
        particleSystem.Play();
        Animator animation = portGameObject.GetComponent<Animator>();
        animation.SetTrigger("clean");
        yield return new WaitForSeconds(1.0f);
        GameManager.Instance.Fooling = 0;
        
        OscMessage msg = new OscMessage();
        msg.address = "/cleaning";
        msg.values.Add(1);
        osc.Send(msg);
        SceneManager.LoadScene(1);
    }
}
