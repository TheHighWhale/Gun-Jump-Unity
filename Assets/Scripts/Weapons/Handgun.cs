using UnityEngine;

public class Handgun : Weapon
{
    public float projectileSpeed = 30f; // Bullet speed

    private void Start()
    {
        fireRate = .8f;  // Limit firing rate to one shot per second
        damage = 10f;   // Set initial damage for the handgun (adjust as needed)
    }

    protected override void FireProjectile()
    {
        Vector3 spawnPosition = gunTransform.position + gunTransform.right * 0.5f;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, gunTransform.rotation);

        // Apply damage to the projectile
        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.damage = damage;
            projScript.speed = projectileSpeed;  // Set the speed of the projectile here
        }
    }
}

