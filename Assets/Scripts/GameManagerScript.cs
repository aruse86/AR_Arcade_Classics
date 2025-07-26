// needed namespace for Unity to function
using UnityEngine;

// Defines a GameManager class that detects when a game is over and triggers the game over state
public class GameManager : MonoBehaviour
{
    // create a variable to track if the game has ended
    private bool gameEnded = false;

    // references another script that shows a Game Over Screen
    public GameOverUI gameOverUI;

    // this method is called when a space invader reaches the ground (see InvaderScript)
    public void GameOver()
    {
        if (gameEnded) return;  // if game already ended, exit

        // sets gameEnded to true and logs to the console
        gameEnded = true;
        Debug.Log("GAME OVER!");

        // calls ShowGameOver() from GameOverUIScript if the GameOverUI has an assignment in inspector, shows warning otherwise
        if (gameOverUI != null)
        {
            gameOverUI.ShowGameOver();
        }
        else
        {
            Debug.LogWarning("GameOverUI reference is NULL in GameManager.");
        }
    }
}

