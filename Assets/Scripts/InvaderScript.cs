// needed namespaces for Unity to function
using System.Collections;
using UnityEngine;

// Defines an InvaderScript class that controls the default movement of each invader (basically horizontal
// for a few seconds, down for a few seconds, then reverse for a few seconds, repeat)
public class InvaderScript : MonoBehaviour
{
    [Header("Horizontal Movement")]  // horizontal movement header in each prefabs inspector window 
    public float horizontalSpeed = 2f;  // Starting side-to-side speed
    public float moveDuration = 10f;  // Time to move horizontally
    public float speedIncrement = 0.2f;  // Increase in horizontal speed each cycle after going down
    public float maxSpeed = 10f;  // Max horizontal speed to set limit

    [Header("Vertical Movement")]  // vertical movement header in each prefabs inspector window
    public float verticalSpeed = 1f;  // Downward speed
    public float downDuration = 3f;  // How long to move down
    public float groundLevel = 0f;  // Y-position at which game ends and player loses if reached by any invader

    private bool movingRight = true;  // keeps track of which horizontal direction the invader moves
    private GameManager gameManager; // references another script to call GameOver()

    //  starts the MovePattern() coroutine that keeps the invader moving
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(MovePattern());
    }

    // coroutine that handles the invader movement
    IEnumerator MovePattern()
    {
        while (true)
        {
            // Move horizontally for moveDuration
            float elapsed = 0f;
            while (elapsed < moveDuration)
            {
                Vector3 direction = movingRight ? Vector3.right : Vector3.left;
                transform.Translate(direction * horizontalSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Move down for downDuration
            elapsed = 0f;
            while (elapsed < downDuration)
            {
                transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;

                // Check if invader reaches the ground. if so, trigger the GameOver() method in the GameManagerScript
                if (transform.position.y <= groundLevel)
                {
                    Debug.Log("Invader reached the ground. Game Over.");
                    if (gameManager != null)
                    {
                        gameManager.GameOver();
                    }
                    yield break; // Stop this invader's movement
                }

                yield return null;
            }

            // Reverse direction and increase speed after dropping down
            movingRight = !movingRight;
            horizontalSpeed = Mathf.Min(horizontalSpeed + speedIncrement, maxSpeed);
        }
    }
}
