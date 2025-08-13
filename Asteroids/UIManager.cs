using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}