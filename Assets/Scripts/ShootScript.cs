using UnityEngine;
using TMPro;

public class ShootScript : MonoBehaviour
{
    [Header("References")]
    public Camera arCamera;  // AR Camera component
    public GameObject smoke; // Explosion prefab
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public AudioSource laserAudioSource;

    [Header("Settings")]
    public float maxShootDistance = 20f; // Ray length

    private int score = 0;
    private int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    public void Shoot()
    {
        // Play laser shot sound
        if (laserAudioSource != null) laserAudioSource.Play();

        // Build a ray from the AR camera
        Ray ray = new Ray(arCamera.transform.position, arCamera.transform.forward);
        RaycastHit hit;

        // Debug draw in Scene View (red = no hit, green = hit)
        Color rayColor = Color.red;

        if (Physics.Raycast(ray, out hit, maxShootDistance))
        {
            rayColor = Color.green;
            Debug.Log($"Hit object: {hit.transform.name} | Tag: {hit.transform.tag}");

            if (hit.transform.CompareTag("Invader"))
            {
                InvaderInfo info = hit.transform.GetComponent<InvaderInfo>();
                if (info != null)
                {
                    score += info.pointValue;
                    CheckHighScore();
                    UpdateScoreUI();
                }

                InvaderScript invader = hit.transform.GetComponent<InvaderScript>();
                if (invader != null)
                {
                    invader.DestroyInvader();
                }

                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

                GameManager gm = FindAnyObjectByType<GameManager>();
                if (gm != null) gm.InvaderDestroyed();
            }
            else
            {
                Debug.Log("Ray hit something, but it's not tagged 'Invader'");
            }
        }
        else
        {
            Debug.Log("No hit");
        }

        Debug.DrawRay(ray.origin, ray.direction * maxShootDistance, rayColor, 1f);
    }

    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
        if (highScoreText != null) highScoreText.text = "High Score: " + highScore;
    }
}
