using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tkt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
