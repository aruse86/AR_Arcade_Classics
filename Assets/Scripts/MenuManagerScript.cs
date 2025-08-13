// needed namespaces for Unity to function
using UnityEngine;
using UnityEngine.SceneManagement;

// Defines the MenuManager class which handles the start screen of the Space Invaders game
public class MenuManager : MonoBehaviour
{
    // Starts Space Invaders when the Start Game button is pushed
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SpaceInvadersGamePlayScene"); 
    }

    // Go's to the home menu when the Quit button is pushed
    public void QuitToHome()
    {
        SceneManager.LoadScene("HomeMenu");
    }
}
