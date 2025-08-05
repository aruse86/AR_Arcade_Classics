using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting();
    }

    // Handle movement forward/backward based on user input
    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Vertical"); // "W" or "S" (up or down arrow key)
        transform.Translate(Vector3.up * moveInput * moveSpeed * Time.deltaTime);
    }

    // Handle rotation using horizontal input (A/D or left/right arrow keys)
    void HandleRotation()
    {
        float rotateInput = Input.GetAxis("Horizontal"); // "A" or "D" (left or right arrow key)
        transform.Rotate(Vector3.forward * -rotateInput * rotationSpeed * Time.deltaTime);
    }

    // Handle shooting (space bar or tap for mobile)
    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // or use a touch input for mobile
        {
            Shoot();
        }
    }

    // Instantiate bullets from the fire point
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
