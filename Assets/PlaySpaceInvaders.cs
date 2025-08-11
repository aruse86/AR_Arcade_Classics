using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySpaceInvaders : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartSpaceInvaders()
    {
        SceneManager.LoadScene("SpaceInvadersScene");
    }

}
