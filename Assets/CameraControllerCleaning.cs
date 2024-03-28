using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerCleaning : MonoBehaviour
{
    public Transform target; // L'objet autour duquel la caméra tournera
    public Vector3 offset; // Décalage de la position de la caméra par rapport au target
    public float rotateSpeed = 5.0f; // Vitesse de rotation de la caméra

    void Update()
    {
        // Déplacement et rotation de la caméra basés sur l'entrée utilisateur
        RotateCamera();

        // S'assure que la caméra reste toujours orientée vers la cible
        transform.LookAt(target);
    }

    void RotateCamera()
    {
        // Détermine la direction de la rotation basée sur les touches fléchées horizontales
        float horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed;
        transform.RotateAround(target.position, Vector3.up, horizontalInput * Time.deltaTime);

        // Utilisez une approche similaire pour la rotation verticale si nécessaire,
        // mais attention aux problèmes de renversement lorsque vous regardez trop haut ou trop bas.
    }
}
