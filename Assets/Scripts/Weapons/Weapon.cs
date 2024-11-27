using System.Collections;
using UnityEngine;
using TMPro;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon Properties")]
    public float damage;
    public float fireRate;
    public GameObject projectilePrefab;
    public Transform gunTransform;
    public float recoilForce = 2f;  // Weak recoil force; can be adjusted in the Inspector
    public float projectileSpeed; // Bullet speed
    protected float nextFireTime = 0f;

    [Header("Ammo and Reload")]
    public int maxAmmo ; // Maximum ammo per magazine
    public int currentAmmo; // Current ammo in the magazine
    public int maxSpareAmmo; // Maximum spare ammo capacity
    public int currentSpareAmmo; // Current spare ammo count
    public float reloadTime = 2f; // Time taken to reload
    public TMP_Text ammoText; // Reference to the ammo UI
    private bool isReloading = false;

    [Header("Audio")]
    public AudioClip reloadSound;
    public AudioClip shootSound;
    private AudioSource audioSource; // Cached reference to the weapon's audio source


    void Start()
    {
        // Cache the audio source on the weapon
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on this weapon!");
        }

        // Initialize ammo
        currentAmmo = maxAmmo;
        currentSpareAmmo = maxSpareAmmo;

        UpdateAmmoUI();
    }

    private void Update()
    {
        if (Input.GetButton("Reload"))
        {
            StartCoroutine(Reload());
        }
    }

    public virtual void Shoot()
    {
        if (isReloading)
        {
            Debug.Log("Cannot shoot while reloading.");
            return;
        }

        if (currentAmmo <= 0)
        {
            Debug.Log("Out of ammo in magazine! Reload needed.");
            StartCoroutine(Reload());
            return;
        }

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // Set the next allowed firing time

            // Fire a projectile in the current gun direction
            FireProjectile();

            // Play shooting sound
            PlayAudio(shootSound);

            // Apply a recoil force if shooting downward
            if (gunTransform.right.y < -0.7f) // Checks if the gun is angled downward
            {
                Rigidbody2D playerRb = GetComponentInParent<Rigidbody2D>();
                if (playerRb != null)
                {
                    float downwardVelocity = Mathf.Min(playerRb.velocity.y, 0); // Only consider downward velocity (negative y)

                    // Adjust recoil force to counteract downward velocity
                    float adjustedRecoilForce = recoilForce - downwardVelocity;

                    // Apply the recoil force
                    playerRb.AddForce(-gunTransform.right * adjustedRecoilForce, ForceMode2D.Impulse);
                }
            }

            currentAmmo--; // Reduce ammo count
            UpdateAmmoUI(); // Update the UI
        }
    }


    protected virtual void FireProjectile()
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

    public IEnumerator Reload()
    {
        if (isReloading) yield break;

        if (currentSpareAmmo <= 0)
        {
            Debug.Log("No spare ammo to reload!");
            yield break;
        }

        isReloading = true;
        Debug.Log("Reloading...");

        // Play reload audio
        PlayAudio(reloadSound);

        yield return new WaitForSeconds(reloadTime);

        int ammoNeeded = maxAmmo - currentAmmo; // How much ammo we need to refill the magazine
        int ammoToReload = Mathf.Min(ammoNeeded, currentSpareAmmo); // Take only what is available in spare ammo

        currentAmmo += ammoToReload; // Add to the magazine
        currentSpareAmmo -= ammoToReload; // Deduct from spare ammo

        UpdateAmmoUI(); // Update the UI
        isReloading = false;

        Debug.Log("Reload complete.");
    }


    private void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = $"{currentAmmo} | {currentSpareAmmo}";
        }
        else
        {
            Debug.LogWarning("AmmoText UI reference is not assigned.");
        }
    }

    protected void PlayAudio(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else if (clip == null)
        {
            Debug.LogWarning("AudioClip is null and cannot be played.");
        }
    }
}
