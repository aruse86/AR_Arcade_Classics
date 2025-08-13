using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AsteroidPlayerMotor : MonoBehaviour
{
    public float ThrottlePower;
    public float TorquePower;
    private Rigidbody rigidbody;
    private float torqueInput;
    private float throttleInput;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var torqueInput = Input.GetAxisRaw("Horizontal");
        var throttleInput = Input.GetAxisRaw("Vertical");
        throttleInput = Mathf.Clamp(throttleInput, 0, 1);
        
    }

    void FixedUpdate() {
        rigidbody.AddRelativeForce(Vector3.forward * throttleInput * ThrottlePower, ForceMode.Force);
        rigidbody.AddTorque(Vector3.up * torqueInput * TorquePower, ForceMode.Force);
    }
}
