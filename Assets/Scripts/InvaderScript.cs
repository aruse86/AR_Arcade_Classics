
using System.Collections.Generic;


using System.Collections;
using UnityEngine;

public class InvaderScript : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float horizontalSpeed = 2f;         // Starting side-to-side speed
    public float moveDuration = 10f;           // Time to move horizontally
    public float speedIncrement = 0.2f;        // Increase in horizontal speed each cycle
    public float maxSpeed = 10f;               // Max horizontal speed

    [Header("Vertical Movement")]
    public float verticalSpeed = 1f;           // Downward speed
    public float downDuration = 3f;            // How long to move down

    private bool movingRight = true;

    void Start()
    {
        StartCoroutine(MovePattern());
    }

    IEnumerator MovePattern()
    {
        while (true)
        {
            // ▶ Move horizontally for moveDuration
            float elapsed = 0f;
            while (elapsed < moveDuration)
            {
                Vector3 direction = movingRight ? Vector3.right : Vector3.left;
                transform.Translate(direction * horizontalSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // ▶ Move down for downDuration
            elapsed = 0f;
            while (elapsed < downDuration)
            {
                transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // 🔄 Reverse direction and increase speed
            movingRight = !movingRight;
            horizontalSpeed = Mathf.Min(horizontalSpeed + speedIncrement, maxSpeed);
        }
    }
}
