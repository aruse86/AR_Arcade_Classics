using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject resumeButton;

    private bool isPaused = false;

    public void TogglePause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            resumeButton.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        resumeButton.SetActive(false);
    }
}
