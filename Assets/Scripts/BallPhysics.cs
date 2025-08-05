using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public float maxVelocity = 15f;
    public float min_Y = -5f;
    public int brickHits = 0;
    Rigidbody2D rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.y < min_Y)
      {
        transform.position = Vector3.zero;
        rigidBody.linearVelocity = new Vector3(0,-10,0);
      }

      if(rigidBody.linearVelocity.magnitude > maxVelocity)
      {
        rigidBody.linearVelocity = Vector3.ClampMagnitude(rigidBody.linearVelocity, maxVelocity);
      }
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
      }


      if (collision.gameObject.CompareTag("Paddle"))
      {
        rigidBody.linearVelocity *= -1;
      }
    }
}
