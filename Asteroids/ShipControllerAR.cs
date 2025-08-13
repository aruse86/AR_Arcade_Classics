using UnityEngine;
using UnityEngine.InputSystem; // New Input System

public class ShipControllerAR : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float thrust = 2f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 500f;

    private bool firePressed = false;

    private void Update()
    {
        // Touch input (for mobile)
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 pos = Touchscreen.current.primaryTouch.position.ReadValue();
            float rot = (pos.x - Screen.width / 2f) / (Screen.width / 2f);
            transform.Rotate(Vector3.forward, -rot * rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.up * thrust * Time.deltaTime, Space.Self);
        }

        // Keyboard input (for testing on desktop)
        float horizontal = Keyboard.current?.aKey.isPressed == true ? -1f :
                           Keyboard.current?.dKey.isPressed == true ? 1f : 0f;
        float vertical = Keyboard.current?.wKey.isPressed == true ? 1f : 0f;

        transform.Rotate(Vector3.forward, -horizontal * rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * thrust * Time.deltaTime, Space.Self);

        // Fire handling
        if (firePressed)
        {
            Fire();
            firePressed = false;
        }

        // Also support spacebar for desktop fire
        if (Keyboard.current?.spaceKey.wasPressedThisFrame == true)
        {
            Fire();
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Fire input received!");
            firePressed = true;
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("BulletPrefab or FirePoint not assigned.");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce);
        }
        else
        {
            Debug.LogWarning("No Rigidbody found on bullet prefab.");
        }
    }
}