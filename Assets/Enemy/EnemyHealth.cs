using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int  maxHitPoints = 5;
    
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();    
    }

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)
    {
         ProcessHit();

        if(currentHitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit(){
        currentHitPoints--;
    }

    void KillEnemy(){
        gameObject.SetActive(false);
        maxHitPoints  += difficultyRamp;
        enemy.RewardGold();
    }
}
