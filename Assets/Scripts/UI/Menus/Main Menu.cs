using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas MenuCanvas;
    public Canvas weaponSelectionCanvas;
    public Canvas settingsCanvas;

    void Start()
    {
        MenuCanvas.enabled = true;
        weaponSelectionCanvas.enabled = false;
        settingsCanvas.enabled = false;

        //startGameButton.onClick.AddListener(() => LoadSceneByName("Tutorial Level"));
    }

    void LoadSceneByName(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ShowMainMenu()
    {
        MenuCanvas.enabled = true;
        weaponSelectionCanvas.enabled = false;
        settingsCanvas.enabled = false;
    }

    public void ShowWeaponSelection()
    {
        MenuCanvas.enabled = false;
        weaponSelectionCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    public void ShowSettings()
    {
        MenuCanvas.enabled = false;
        weaponSelectionCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }
}
