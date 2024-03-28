using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CarteManager : MonoBehaviour
{
    [SerializeField] private GameObject boat;
    [SerializeField] private TMPro.TMP_Text textVitesse;
    [SerializeField] private TMPro.TMP_Text textFooling;
    [SerializeField] private Slider  slider;
    [SerializeField] private Slider  sliderFooling;
    [SerializeField] private TMPro.TMP_Text textPoint;
    [SerializeField] private GameObject portHighlighter;
    [SerializeField] private TMP_Text textDate;
    

    public Transform[] ports;

    private void Start() {
        // get all children of the parent object
        ports = gameObject.GetComponentsInChildren<Transform>().Where((a) => a.CompareTag("port")).ToArray();
    }
    // get the index of the port near the boat
    // -1 if no port near
    public int GetIndexOfPortNear() {
        for (int i = 0; i < ports.Length; i++) {
            if (Vector2.Distance(boat.transform.position, ports[i].position) < 1) {
                return i;
            }
        }

        return -1;
    }

    public Transform getPortActuel() {
        return ports[GameManager.Instance.indexPort];
    }
    
    
    public void samarrer() {
        int index = GetIndexOfPortNear();
        if (index == -1) {
            Debug.Log("No port near");
            return;
        }
        Debug.Log("Samarrage to port " + ports[index].name);
        
        if((GameManager.Instance.indexPort + 1) % ports.Length == index) {
            GameManager.Instance.point += 10;
        }
        GameManager.Instance.indexPort = index;
        SceneManager.LoadScene(2);

        
    }

    private float elapsedTime = 0;

    private void Update() {
        textVitesse.text = "Vitesse : " + GameManager.Instance.vitesse.ToString("0.00");
        slider.value = GameManager.Instance.vitesse;
        textFooling.text = "Fooling : " + (GameManager.Instance.Fooling * 100).ToString("0") + " %";
        sliderFooling.value = GameManager.Instance.Fooling;
        
        textPoint.text = "Point : " + GameManager.Instance.point;
        
        Transform transformNextPort = ports[(GameManager.Instance.indexPort + 1) % ports.Length];
        portHighlighter.transform.position = transformNextPort.position;

        textDate.text = GameManager.Instance.date.ToString("dd/MM/yyyy");
        
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 1) {
            GameManager.Instance.date = GameManager.Instance.date.AddDays(2);
            
            if(GameManager.Instance.date.Year > 2024) {
                SceneManager.LoadScene(4);
            }
            elapsedTime = 0;
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            samarrer();
        }
    }
}
