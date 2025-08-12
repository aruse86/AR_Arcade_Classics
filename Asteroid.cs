using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<UIManager>().AddScore(10);
            Destroy(collision.gameObject); // Destroy bullet
            Destroy(gameObject); // Destroy asteroid
        }
    }
}