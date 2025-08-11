using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float maxVelocity = 15f;
    public float min_Y = -5f;
    public int brickHits = 0;
    public int totalBricks = 54;
    Rigidbody2D rigidBody;
    public float timer = 0f;
    public string timerDisplay;
    public int deaths = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rigidBody = GetComponent<Rigidbody2D>();
      Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
      if(totalBricks < 1)
      {
        GameWin();
      }
      // Ball reset after falling off-screen
      if(transform.position.y < min_Y)
      {
        constructTimer(timer);
        Debug.Log(timerDisplay);
        StartCoroutine(BallWaitCoroutine());
      }

      // cap max velocity
      if(rigidBody.linearVelocity.magnitude > maxVelocity)
      {
        rigidBody.linearVelocity = Vector3.ClampMagnitude(rigidBody.linearVelocity, maxVelocity);
      }

      timer += Time.deltaTime;

    }



    // The brickHits variable allows a gameplay variant where each brick takes
    // multiple hits
    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Brick"))
      {
        brickHits -= 1;
      }
      if (brickHits < 1 && collision.gameObject.CompareTag("Brick"))
      {
        Destroy(collision.gameObject);
        totalBricks -= 1;
      }
    }

    private void constructTimer(float time)
    {
      float minutes = Mathf.FloorToInt(time / 60);
      float seconds = Mathf.FloorToInt(time % 60);
      timerDisplay = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator BallWaitCoroutine()
    {
        // Delays the new ball launching by 1 second
        yield return new WaitForSeconds(1);
        deaths += 1;
        transform.position = Vector3.zero;
        rigidBody.linearVelocity = new Vector3(0,-10,0);
    }

    private void GameWin()
    {
      Debug.Log("You win!");
      constructTimer(timer);
      Debug.Log(timerDisplay);
    }

}
