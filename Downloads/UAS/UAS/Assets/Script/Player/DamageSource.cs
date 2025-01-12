using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damageAmount);
        }
        else if (other.gameObject.GetComponent<EnemyHealth2>())
        {
            EnemyHealth2 enemyHealth2 = other.gameObject.GetComponent<EnemyHealth2>();
            enemyHealth2.TakeDamage(damageAmount);
        }
        else if (other.gameObject.GetComponent<EnemyHealth3>())
        {
            EnemyHealth3 enemyHealth3 = other.gameObject.GetComponent<EnemyHealth3>();
            enemyHealth3.TakeDamage(damageAmount);
        }
    }
}
