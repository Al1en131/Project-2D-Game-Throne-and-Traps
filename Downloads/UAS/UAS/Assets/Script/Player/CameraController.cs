using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerControls; // Objek pemain yang akan diikuti kamera
    public float offset; // Offset pada sumbu X
    public float offsetSmoothing; // Kehalusan perpindahan kamera
    public Vector3 playerPosition; // Posisi target kamera

    void Start()
    {
        
    }

    void Update()
    {
        // Mengatur posisi target kamera pada sumbu X dan Y berdasarkan posisi pemain
        playerPosition = new Vector3(
            playerControls.transform.position.x, 
            playerControls.transform.position.y, // Mengikuti posisi Y pemain
            transform.position.z // Tetap pada sumbu Z kamera
        );

        // Menambahkan offset ke posisi X berdasarkan arah skala pemain
        if (playerControls.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        // Menginterpolasi posisi kamera menuju posisi target untuk menghasilkan pergerakan halus
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
