using UnityEngine;

public class AK : Weapon
{ 
    private void Awake()
    {
        fireRate = 5;  // Limit firing rate to one shot per second
        damage = 10f;   // Set initial damage for the handgun (adjust as needed)
        recoilForce = 10f;
        maxAmmo = 24;
        maxSpareAmmo = 240;
        projectileSpeed = 30f;

        currentAmmo = maxAmmo; // Initialize ammo in magazine
        currentSpareAmmo = maxSpareAmmo; // Initialize spare ammo
    }
}

