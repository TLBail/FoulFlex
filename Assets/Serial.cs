using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using UnityEngine;

public class Serial : MonoBehaviour
{
    
    [SerializeField] public  String PortName = "COM3";
    [SerializeField] public  int BaudRate = 34800; 
    private SerialPort sp;
    
    void Start()
    {
        
        string cheminFichier = Path.Combine(Application.streamingAssetsPath, "port.txt");

        // Vérifier si le fichier existe
        if(File.Exists(cheminFichier))
        {
            // Lire le contenu du fichier
            string contenu = File.ReadAllText(cheminFichier);
            PortName = contenu;
            Debug.Log(contenu);
        }
        else
        {
            Debug.LogError("Fichier non trouvé : " + cheminFichier);
        }



        try {
            sp = new SerialPort(PortName, BaudRate); 
            sp.Open(); 
            Debug.Log(sp); 
            sp.ReadTimeout = 100; 

        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
    }


    private void OnDestroy() {
        sp.Close();
    }

    public void clean() {
        //TODO send correct message to arduino
        sp.Write("1");
    }
}
