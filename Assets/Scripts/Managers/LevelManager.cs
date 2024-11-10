using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int enemiesDefeated = 0;
    public int enemiesToNextLevel = 5;

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= enemiesToNextLevel)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Code to load the next level here
        Debug.Log("Next Level Loaded!");
    }
}
