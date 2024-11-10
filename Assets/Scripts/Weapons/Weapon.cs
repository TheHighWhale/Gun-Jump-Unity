using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;
    public float fireRate;
    public GameObject projectilePrefab;
    public Transform gunTransform;
    public float recoilForce = 2f;  // Weak recoil force; can be adjusted in the Inspector

    protected float nextFireTime = 0f;

    public virtual void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;  // Set the next allowed firing time

            // Fire a projectile in the current gun direction
            FireProjectile();

            // Apply a weak recoil force if shooting downward
            if (gunTransform.right.y < -0.7f) // Checks if the gun is angled downward
            {
                Rigidbody2D playerRb = GetComponentInParent<Rigidbody2D>();
                if (playerRb != null)
                {
                    playerRb.AddForce(-gunTransform.right * recoilForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    protected virtual void FireProjectile()
    {
        Vector3 spawnPosition = gunTransform.position + gunTransform.right * 0.5f;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, gunTransform.rotation);

        // Apply damage to the projectile (or other settings specific to this weapon)
        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.damage = damage;
        }
    }
}
