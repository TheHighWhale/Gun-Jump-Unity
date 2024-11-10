using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponMountPoint; // Place where weapon attaches on the player

    void Start()
    {
        if (GameManager.instance.selectedWeaponPrefab != null)
        {
            EquipWeapon(GameManager.instance.selectedWeaponPrefab);
        }
    }

    void EquipWeapon(GameObject weaponPrefab)
    {
        Instantiate(weaponPrefab, weaponMountPoint.position, weaponMountPoint.rotation, weaponMountPoint);
    }
}
