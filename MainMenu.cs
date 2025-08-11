using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public void ReturnToMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
}
