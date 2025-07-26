// needed namespaces for Unity to function
using UnityEngine;
using UnityEngine.SceneManagement;

// Defines a GameOverUI class that is assigned to the GameOverPanel object (screen that pop up when the game ends)
public class GameOverUI : MonoBehaviour
{
    // makes the GameOverPanel invisible and disabled at the start of the game
    void Awake()
    {
        gameObject.SetActive(false);
    }

    // called by GameManager script when the game ends, it shows the GameOverPanel
    public void ShowGameOver()
    {
        Debug.Log("ShowGameOver() called"); // logs information
        gameObject.SetActive(true);  // Show the panel
        Time.timeScale = 0f;         // Pause the game so it no longer continues after the player lost
    }

    // called when the Restart Button on the GameOverPanel is pressed
    public void RestartGame()
    {
        Time.timeScale = 1f; // unpauses the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reloads the game screen
    }

    // called when the Menu Button on the GameOverPanel is pressed
    public void SpaceInvadersMenu()
    {
        // Load the Space Invaders menu scene
        SceneManager.LoadScene("SpaceInvadersMenuScene");
    }
}

