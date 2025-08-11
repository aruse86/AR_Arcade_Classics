using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAsteroids : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartAsteroids()
    {
        SceneManager.LoadScene("Asteroids");
    }

}
