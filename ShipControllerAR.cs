using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class ShipControllerAR : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float thrust = 2f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 500f;

    private Camera mainCamera;
    private bool firePressed = false;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (firePressed)
        {
            Fire();
            firePressed = false; // Reset after firing
        }

        // Optional: movement based on touch
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 pos = Touchscreen.current.primaryTouch.position.ReadValue();
            float rot = (pos.x - Screen.width / 2f) / (Screen.width / 2f);
            transform.Rotate(Vector3.forward, -rot * rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * thrust * Time.deltaTime, Space.Self);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            firePressed = true;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce);
        }
    }
}
