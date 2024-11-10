using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponMountPoint; // Reference to the weapon mount on the player
    private GameObject currentWeapon;  // Currently equipped weapon

    public void EquipWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);  // Remove any existing weapon
        }
        currentWeapon = Instantiate(weaponPrefab, weaponMountPoint.position, weaponMountPoint.rotation, weaponMountPoint);
        // Additional setup for weapon mechanics, if needed
    }
}
