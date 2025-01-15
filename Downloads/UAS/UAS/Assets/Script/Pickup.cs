using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private enum PickUpType
    {
        GoldCoin,
        HealthGlobe,
        diamondsGlobe,
        GuideBook,
    }

    [SerializeField] private PickUpType pickUpType;
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelartionRate = .2f;
    [SerializeField] private float moveSpeed = 3f;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
    // Dapatkan posisi pemain
    Vector3 playerPos = PlayerController.Instance.transform.position;

    // Hanya lakukan pergerakan pada pemain (pemain mendekati pickup)
    if (Vector3.Distance(transform.position, playerPos) < pickUpDistance) {
        // Jika pemain cukup dekat, mungkin beri sinyal atau efek untuk memberi tahu pemain bisa mengambilnya
        Debug.Log("Player is close to pickup!");
    }
    // Tidak perlu lagi memperbarui pergerakan objek pickup, biarkan objek tetap diam
}

private void OnTriggerStay2D(Collider2D other) {
    if (other.gameObject.GetComponent<PlayerController>()) {
        // Jika pemain berada di dalam trigger dan menekan tombol untuk mengambil item
        DetectPickupType();
        Destroy(gameObject);
    }
}


    private void FixedUpdate() {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void DetectPickupType() {
        switch (pickUpType)
        {
            case PickUpType.GoldCoin:
                EconomyManager.Instance.UpdateCurrentGold();
                Debug.Log("GoldCoin");
                break;
            case PickUpType.HealthGlobe:
                PlayerHealth.Instance.HealPlayer();
                Debug.Log("HealthGlobe");
                break;
            case PickUpType.diamondsGlobe:
                // do stamina globe stuff
                Debug.Log("diamondsGlobe");
                break;
                 case PickUpType.GuideBook:
                // do stamina globe stuff
                Debug.Log("guidebookGlobe");
                break;
        }
    }
}
