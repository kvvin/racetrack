using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Transform wheelMesh;         // The wheel mesh to be synchronized
    public WheelCollider wheelCollider; // The corresponding wheel collider
    public bool isFrontWheel;           // Indicates if the wheel is a front wheel

    void FixedUpdate()
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);

        wheelMesh.position = position;
        if (isFrontWheel)
        {
            float steerAngle = wheelCollider.steerAngle;
            wheelMesh.rotation = rotation * Quaternion.Euler(0f, steerAngle, 0f);
        }
        else
        {
            wheelMesh.rotation = rotation;
        }
    }
}