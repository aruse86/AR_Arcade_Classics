using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float max_X = 10;

    float horizontalMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        // Sets horizontal boundaries for the paddle
        if(
          (horizontalMovement > 0 && transform.position.x < max_X) ||
          (horizontalMovement < 0 && transform.position.x > -max_X)
        ) {
          // adjust paddle speed to change difficulty
          transform.position += Vector3.right * horizontalMovement * speed * Time.deltaTime;
        }
    }
}
