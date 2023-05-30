using UnityEngine;

public class carController : MonoBehaviour
{
    public WheelCollider WheelFL;       // Front left wheel collider
    public WheelCollider WheelFR;       // Front right wheel collider
    public WheelCollider WheelRL;       // Rear left wheel collider
    public WheelCollider WheelRR;       // Rear right wheel collider
    public Transform WheelFLtrans;      // Front left wheel mesh transform
    public Transform WheelFRtrans;      // Front right wheel mesh transform
    public Transform WheelRLtrans;      // Rear left wheel mesh transform
    public Transform WheelRRtrans;      // Rear right wheel mesh transform
    public Transform centreofmass;      // Centre of mass transform
    public float maxTorque = 1000f;     // Maximum torque applied to rear wheels
    public float steerAngle = 30f;      // Maximum steering angle for front wheels

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        // Apply motor torque to rear wheels
        float motorTorque = maxTorque * Input.GetAxis("Vertical");
        WheelRR.motorTorque = motorTorque;
        WheelRL.motorTorque = motorTorque;

        // Apply steering angle to front wheels
        float steerInput = Input.GetAxis("Horizontal");
        WheelFL.steerAngle = steerAngle * steerInput;
        WheelFR.steerAngle = steerAngle * steerInput;

        // Update wheel rotation
        UpdateWheelRotation(WheelFL, WheelFLtrans);
        UpdateWheelRotation(WheelFR, WheelFRtrans);
        UpdateWheelRotation(WheelRL, WheelRLtrans);
        UpdateWheelRotation(WheelRR, WheelRRtrans);
    }

    void UpdateWheelRotation(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }
}
