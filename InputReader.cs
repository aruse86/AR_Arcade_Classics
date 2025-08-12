using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public ShipControllerAR shipController;

    private GameControls controls;

    void Awake()
    {
        controls = new GameControls();
        controls.Player.Fire.performed += ctx => shipController.OnFire(ctx);
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
}
