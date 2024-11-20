using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10f;
    public float damage = 5f; // Weapon damage for this enemy type
    public string enemyType;
    public bool dead;
    public float speed;

    private void Start()
    {
        dead = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<LevelManager>().EnemyDefeated();
        dead = true;
    }
}
