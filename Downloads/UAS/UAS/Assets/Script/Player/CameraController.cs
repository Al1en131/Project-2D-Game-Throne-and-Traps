using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerControls; // Objek pemain yang akan diikuti kamera
    public float offset; // Offset pada sumbu X
    public float offsetSmoothing; // Kehalusan perpindahan kamera
    private Vector3 playerPosition; // Posisi target kamera

    void Start()
    {
        if (playerControls == null)
        {
            playerControls = GameObject.FindWithTag("Player"); // Cari objek dengan tag "Player"
        }
    }

    void Update()
    {
        if (playerControls == null)
        {
            Debug.LogWarning("PlayerControls belum diatur!");
            return;
        }

        // Mengatur posisi target kamera pada sumbu X dan Y berdasarkan posisi pemain
        playerPosition = new Vector3(
            playerControls.transform.position.x,
            playerControls.transform.position.y, // Mengikuti posisi Y pemain
            transform.position.z
        );

        // Menambahkan offset ke posisi X berdasarkan arah skala pemain
        if (playerControls.transform.localScale.x > 0f)
        {
            playerPosition.x += offset;
        }
        else
        {
            playerPosition.x -= offset;
        }

        // Menginterpolasi posisi kamera menuju posisi target untuk menghasilkan pergerakan halus
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
