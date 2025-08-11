using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject Ball;
    public BallPhysics ballPhysicsRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ballPhysicsRef.totalBricks < 50)
        {
          GameOverMenu.SetActive(true);
          Ball.SetActive(false);
        }
    }
}
