using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
		
        Reset();
    }

    public void Reset() {
        fooling = 0;
        indexPort = 0;
        point = 0;
        date = new DateTime(2024, 1, 2);
    }

    public const float vitesseMax = 4;
    public const float vitessMin = 1;

    public float vitesse => (vitesseMax * (1.0f - fooling)) + vitessMin;
    
    public void IncreaseFooling() {
        fooling += 0.3f * Random.Range(0.5f, 1.5f);
    }

    private float fooling = 0;
    public float Fooling
    {
        get
        {
            return fooling;
        }
        set
        {
            if(value > 1 && value < 0)
            {
                return;
            }
            fooling = value;
        }
    }


    public int indexPort;


    public int point;

    public DateTime date;

}
