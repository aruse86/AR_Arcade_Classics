using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private void Start()
    {
        // Destroy the bullet after a certain time to avoid clutter
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet forward in the direction it’s facing
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // Detect collisions with asteroids
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destroy both the bullet and the asteroid on collision
            Destroy(collision.gameObject); // Asteroid is destroyed
            Destroy(gameObject); // Bullet is destroyed
        }
    }
}
