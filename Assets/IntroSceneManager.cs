using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject presentationPanel;
    [SerializeField] private GameObject tutoPanel;
    [SerializeField] private GameObject creditsPanel;
    
    [SerializeField] private Button tutoButton; 
    [SerializeField] private Button menuPlayButton;
    [SerializeField] private Button creditButton;
    

    
    private GameObject currentPanel;


    private void Start() {
        currentPanel = presentationPanel;
    }

    public void onPresentationPanelClick() {
        currentPanel.SetActive(false);
        menuPanel.SetActive(true);
        currentPanel = menuPanel;
        menuPlayButton.Select();
    }

    public void Play() {
        currentPanel.SetActive(false);
        tutoPanel.SetActive(true);
        currentPanel = tutoPanel;
        tutoButton.Select();
    }

    public void onCreditButtonClick() {
        currentPanel.SetActive(false);
        creditsPanel.SetActive(true);
        currentPanel = creditsPanel;
        creditButton.Select();
    }
    
    
    public void onTutoPanelClick() {
        SceneManager.LoadScene(1);
    }


    public void onCreditPanelClick() {
        currentPanel.SetActive(false);
        menuPanel.SetActive(true);
        currentPanel = menuPanel;
        menuPlayButton.Select();
    }


    private void Update() {
        if (currentPanel == menuPanel) {
            if (Input.GetKeyDown(KeyCode.JoystickButton1)) {
                onCreditButtonClick();
            }            
        }
    }
}
