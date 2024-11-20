using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public bool isUnlocked = false; // Exit is initially locked
    public string nextSceneName; // Scene to load when the exit is used

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked && other.CompareTag("Player"))
        {
            Debug.Log("Player exited through the door!");
            LoadNextScene();
        }
    }

    public void UnlockExit()
    {
        isUnlocked = true;
        Debug.Log("Exit unlocked!");
        // Optional: Add animation or visual feedback for unlocking
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set.");
        }
    }
}
