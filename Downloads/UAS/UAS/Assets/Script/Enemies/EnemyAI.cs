using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float leftLimit;    // Batas kiri gerakan
    private float rightLimit;   // Batas kanan gerakan
    private float speed = 2f;   // Kecepatan gerakan
    private bool movingRight = true; // Arah gerakan (true = kanan, false = kiri)

    private void Start() {
        // Tetapkan batas kiri dan kanan berdasarkan posisi awal
        leftLimit = transform.position.x - 2f; // Geser 2 unit ke kiri dari posisi awal
        rightLimit = transform.position.x + 2f; // Geser 2 unit ke kanan dari posisi awal
    }

    private void Update() {
        // Periksa arah gerakan
        if (movingRight) {
            // Bergerak ke kanan
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            if (transform.position.x >= rightLimit) {
                movingRight = false; // Berbalik arah ke kiri
                Flip(); // Balik orientasi
            }
        } else {
            // Bergerak ke kiri
            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
            if (transform.position.x <= leftLimit) {
                movingRight = true; // Berbalik arah ke kanan
                Flip(); // Balik orientasi
            }
        }
    }

    private void Flip() {
        // Ambil skala saat ini
        Vector3 localScale = transform.localScale;
        // Balik sumbu X
        localScale.x *= -1;
        // Terapkan kembali skala
        transform.localScale = localScale;
    }
}
