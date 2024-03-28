using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Serial : MonoBehaviour
{
    
    [SerializeField] public  String PortName = "COM3";
    [SerializeField] public  int BaudRate = 34800; 
    private SerialPort sp;
    
    void Start()
    {
        sp = new SerialPort(PortName, BaudRate); 
        sp.Open(); 
        Debug.Log(sp); 
        sp.ReadTimeout = 100; 
        Debug.Log("start");
    }


    private void OnDestroy() {
        sp.Close();
    }

    public void clean() {
        sp.Write("1");
    }
}
