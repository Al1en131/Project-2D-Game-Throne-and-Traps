using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe, diamondsGlobe;

public void DropItems() {
    // Random chance for each item drop
    int randomHealthGlobe = Random.Range(1, 12);
    int randomDiamondsGlobe = Random.Range(1, 12);
    int randomGoldCoin = Random.Range(1, 12);

    // Chance for health globe to appear (3 out of 12)
    if (randomHealthGlobe == 3) {
        Instantiate(healthGlobe, transform.position, Quaternion.identity); 
    }

    // Chance for diamonds globe to appear (4 out of 12)
    if (randomDiamondsGlobe == 4) {
        Instantiate(diamondsGlobe, transform.position, Quaternion.identity); 
    }

    // Chance for gold coins to appear (5 out of 12)
    if (randomGoldCoin == 5) {
        int randomAmountOfGold = Random.Range(1, 5);
            
        for (int i = 0; i < randomAmountOfGold; i++) {
            Instantiate(goldCoin, transform.position, Quaternion.identity);
        }
    }
}

}
