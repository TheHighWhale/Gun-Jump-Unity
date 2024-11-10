using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject selectedWeaponPrefab; // Stores the selected weapon prefab
    public bool[] unlockedWeapons; // Tracks unlocked weapons (true = unlocked, false = locked)

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this GameObject across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize unlockedWeapons array (for example, the first weapon is unlocked)
        if (unlockedWeapons == null || unlockedWeapons.Length == 0)
        {
            unlockedWeapons = new bool[weaponPrefabs.Length];
            unlockedWeapons[0] = true; // Assume first weapon is always unlocked (or any starting weapon)
        }
    }

    // Call this method to unlock a new weapon
    public void UnlockWeapon(int index)
    {
        if (index < unlockedWeapons.Length)
        {
            unlockedWeapons[index] = true;
        }
    }

    public bool IsWeaponUnlocked(int index)
    {
        return unlockedWeapons[index];
    }
}
