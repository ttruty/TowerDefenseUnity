using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when destroyed")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
    }
    
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        healthBar.fillAmount = (float)currentHitPoints / (float)maxHitPoints;
    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    void ProcessHit() {
        currentHitPoints--;
        healthBar.fillAmount = (float)currentHitPoints / (float)maxHitPoints;
        if (currentHitPoints <= 0) {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();

        }
    }
}
