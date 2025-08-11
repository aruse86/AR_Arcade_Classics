using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Called when "Start Game" button is clicked
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SpaceInvadersScene"); // Replace with your actual game scene name
    }

    // Called when "Quit to Home" button is clicked
    public void QuitToHome()
    {
        // Load the home menu scene (not created yet)
        SceneManager.LoadScene("MainMenu");
    }
}
