using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBreakout : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartBreakout()
    {
        SceneManager.LoadScene("BreakoutScene");
    }

}
