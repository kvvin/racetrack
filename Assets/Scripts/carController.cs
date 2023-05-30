using UnityEngine;

public class carController : MonoBehaviour
{
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;
    public Transform centreofmass;
    public float maxTorque = 1000f;
    public float steerAngle = 30f;

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