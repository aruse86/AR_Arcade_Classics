using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
