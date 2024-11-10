using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;
    public float damage = 5f; // Weapon damage for this enemy type
    public string enemyType;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<LevelManager>().EnemyDefeated();
    }
}
