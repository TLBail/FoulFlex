using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowBoat : MonoBehaviour
{
    [SerializeField] private GameObject boatToFollow;


    private void Update() {
        // follow the boat
        transform.position = new Vector3(boatToFollow.transform.position.x, boatToFollow.transform.position.y, -10);
    }
}
