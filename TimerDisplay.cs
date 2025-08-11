using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public BallPhysics ballPhysicsRef;
    public float timer = 0f;


    void Start()
    {

    }

    void Update()
    {
      if (ballPhysicsRef.totalBricks > 0)
        timer += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
