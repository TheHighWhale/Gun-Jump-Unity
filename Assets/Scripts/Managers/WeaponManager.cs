using UnityEngine;
using TMPro; // Ensure you include TextMeshPro namespace

public class WeaponManager : MonoBehaviour
{
    public Transform weaponMountPoint; // Where the weapon should attach
    public PlayerController playerController; // Reference to PlayerController script on the player
    public TMP_Text ammoText; // Reference to the ammo text UI

    void Start()
    {
        if (GameManager.instance.selectedWeaponPrefab != null)
        {
            GameObject weaponInstance = InstantiateWeapon(GameManager.instance.selectedWeaponPrefab);

            // Get the Weapon component from the instantiated GameObject
            Weapon weaponComponent = weaponInstance.GetComponent<Weapon>();

            if (weaponComponent != null)
            {
                // Assign the Weapon component to the playerController's equippedWeapon
                playerController.equippedWeapon = weaponComponent;

                // Optionally, you can also assign the weaponTransform here if needed
                playerController.weaponTransform = weaponInstance.transform;

                // Link the ammo UI to the weapon
                if (ammoText != null)
                {
                    weaponComponent.ammoText = ammoText; // Assign the UI reference to the weapon
                }
                else
                {
                    Debug.LogWarning("AmmoText UI reference is not assigned in WeaponManager.");
                }

                Debug.Log("Weapon selected and equipped.");
            }
            else
            {
                Debug.LogError("Weapon component not found on instantiated weapon.");
            }
        }
        else
        {
            Debug.LogError("No weapon selected in GameManager.");
        }
    }

    GameObject InstantiateWeapon(GameObject weaponPrefab)
    {
        Vector3 offset = new Vector3(0, 1, 0);

        // Instantiate the weapon at the center of the player's position
        GameObject weaponInstance = Instantiate(weaponPrefab, weaponMountPoint.position + offset, weaponMountPoint.rotation, weaponMountPoint);

        return weaponInstance;
    }
}
