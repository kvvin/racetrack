using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Transform wheelMesh;
    public WheelCollider wheelCollider;
    public bool isFrontWheel;

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