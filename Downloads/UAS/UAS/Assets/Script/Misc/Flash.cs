using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDefaultMatTime = .2f;

    private Material defaultMat;
    private SpriteRenderer spriteRenderer;
    private EnemyHealth enemyHealth;
    private EnemyHealth2 enemyHealth2;
     private EnemyHealth3 enemyHealth3;

    private void Awake() {
        enemyHealth = GetComponent<EnemyHealth>();
         enemyHealth2 = GetComponent<EnemyHealth2>();
          enemyHealth3 = GetComponent<EnemyHealth3>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMat = spriteRenderer.material;
    }

    public IEnumerator FlashRoutine() {
        spriteRenderer.material = whiteFlashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        spriteRenderer.material = defaultMat;
        enemyHealth.DetectDeath();
    }
}
