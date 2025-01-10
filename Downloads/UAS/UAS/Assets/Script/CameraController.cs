using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; // Referensi ke transform pemain
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // Offset kamera dari pemain
    [SerializeField] private float smoothSpeed = 0.125f; // Kecepatan smoothing kamera

    private void LateUpdate()
    {
        // Posisi target kamera
        Vector3 targetPosition = player.position + offset;

        // Smooth movement ke target posisi
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
