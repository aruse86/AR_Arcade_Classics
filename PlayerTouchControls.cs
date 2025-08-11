using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchControls : MonoBehaviour
{
    public float speed = 10;
    public float max_X = 10;

    public float horizontalMovement = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Sets horizontal boundaries for the paddle
        if(
          (horizontalMovement > 0 && transform.position.x < max_X) ||
          (horizontalMovement < 0 && transform.position.x > -max_X)
        ) {
          // adjust paddle speed to change difficulty
          transform.position += Vector3.right * horizontalMovement * speed * Time.deltaTime;
        }
    }

    public void MoveLeft()
    {
      horizontalMovement = -1;
    }

    public void MoveRight()
    {
      horizontalMovement = 1;
    }

    public void MoveStop()
    {
      horizontalMovement = 0;
    }

}
