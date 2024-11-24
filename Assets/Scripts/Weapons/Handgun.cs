using UnityEngine;

public class Handgun : Weapon
{
    private void Awake()
    {
        fireRate = 0.8f;  // Limit firing rate to one shot per second
        damage = 10f;   // Set initial damage for the handgun (adjust as needed)
        recoilForce = 20f;
        maxAmmo = 24;
        maxSpareAmmo = 240;
        projectileSpeed = 30f; // Use the inherited property

        currentAmmo = maxAmmo; // Initialize ammo in magazine
        currentSpareAmmo = maxSpareAmmo; // Initialize spare ammo
    }
}

