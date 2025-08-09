using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction;
    public GameObject smallerAsteroidPrefab; // Prefab of a smaller asteroid

    private void Start()
    {
        // Randomize direction and speed for movement
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        speed = Random.Range(1f, 3f);
    }

    private void Update()
    {
        // Move the asteroid in its direction
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // On collision with a bullet, break the asteroid into smaller pieces
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // Destroy the bullet

            // Optionally, break the asteroid into smaller pieces
            if (transform.localScale.x > 0.5f) // Only break if the asteroid is big enough
            {
                // Spawn two smaller asteroids
                Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
                Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
            }

            // Destroy the current asteroid
            Destroy(gameObject);
        }
    }
}
