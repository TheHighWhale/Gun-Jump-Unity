using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyMain : MonoBehaviour
{
    public int health = 100;
    public TutorialManager tutorialManager;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        tutorialManager.KillEnemy();
        Destroy(gameObject);
    }
}
