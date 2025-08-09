using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;  // UI Text element to display the score
    private int score = 0;

    private void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    public void IncrementScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
