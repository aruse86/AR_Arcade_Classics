// needed namespace for Unity to function
using UnityEngine;

// Defines the PauseManager class which toggles a pause feature for the game
public class PauseManager : MonoBehaviour
{
    public GameObject resumeButton;

    private bool isPaused = false;  // keps track of if the game is paused or not

    // pauses the game and shows the Resume button
    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            resumeButton.SetActive(true);
        }
    }

    // resumes the game and hides the Resume button
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        resumeButton.SetActive(false);
    }
}
