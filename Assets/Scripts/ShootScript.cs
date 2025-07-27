// needed namespaces for Unity to function
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Defines the ShootScript class which handles shooting, scoring, keeping track of high scores, and showing explosions
public class ShootScript : MonoBehaviour
{
    public GameObject arCamera;  // references the AR camera which is the origin and idrection of the shot
    public GameObject smoke;  // references the explosion prefab once an invader is destroyed

    public TMP_Text scoreText;  // UI text element that shows score
    public TMP_Text highScoreText; // UI text element that shows high score

    private int score = 0;
    private int highScore = 0;

    // shows score and high scores once the game starts
    private void Start()
    {
        // Load high score from PlayerPrefs (default to 0)
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Ensure both texts show initial values at game start
        UpdateScoreUI();
    }

    // controls the shooting aspect of the game
    public void Shoot()
    {
        RaycastHit hit;
        // shoots from the center of the AR camera
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            // the shot hits aan object with an Invader tag (all invader prefabs have this tag)
            if (hit.transform.CompareTag("Invader"))
            {
                // add invader point value to score, and call CheckHighScore and UpdateScoreUI methods
                InvaderInfo info = hit.transform.GetComponent<InvaderInfo>();
                if (info != null)
                {
                    score += info.pointValue;
                    CheckHighScore();
                    UpdateScoreUI();
                }

                // destroy that invader and show the explosion
                Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

                // update count of destroyed invaders
                GameManager gm = FindAnyObjectByType<GameManager>();
                if (gm != null)
                {
                    gm.InvaderDestroyed();
                }
            }
        }
    }

    // method to check the highscore and update if necessary
    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    // update the current score
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }
}
