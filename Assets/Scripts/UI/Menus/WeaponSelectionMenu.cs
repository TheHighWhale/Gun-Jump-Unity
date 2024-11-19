using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WeaponSelectionMenu : MonoBehaviour
{
    public List<Button> weaponButtons; // Buttons for each weapon
    public List<RawImage> weaponImages; // Images for each weapon button
    public List<GameObject> weaponPrefabs; // Prefabs of all available weapons

    void Start()
    {
        // Initialize buttons and add listeners
        for (int i = 0; i < weaponButtons.Count; i++)
        {
            int index = i; // Capture index for lambda
            weaponButtons[i].onClick.AddListener(() => SelectWeapon(index));
            UpdateWeaponButtonState(index); // Update button state at start
        }
    }

    void SelectWeapon(int index)
    {
        if (GameManager.instance.IsWeaponUnlocked(index))
        {
            GameManager.instance.SetSelectedWeapon(weaponPrefabs[index]);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Tutorial Level");
            GameManager.instance.levelActive = true;
        }
    }

    void UpdateWeaponButtonState(int index)
    {
        if (!GameManager.instance.IsWeaponUnlocked(index))
        {
            // Disable button and fade out weapon image if locked
            weaponButtons[index].interactable = false;
            weaponImages[index].color = new Color(1, 1, 1, 0.5f); // Faded effect (adjust alpha for fading)
        }
        else
        {
            // Enable button and set image to normal
            weaponButtons[index].interactable = true;
            weaponImages[index].color = new Color(1, 1, 1, 1); // Normal opacity
        }
    }

    // Call this method whenever a new weapon is unlocked, such as after completing a level
    public void UnlockNewWeapon(int index)
    {
        GameManager.instance.UnlockWeapon(index);
        UpdateWeaponButtonState(index); // Update the UI for the newly unlocked weapon
    }
}
