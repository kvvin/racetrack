using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float rotationDamping = 5f;

    private Vector3 desiredPosition;
    private Quaternion desiredRotation;

    void LateUpdate()
    {
        // Calculate the desired position and rotation
        desiredPosition = target.position - target.forward * offset.z - target.up * offset.y;
        desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

        // Smoothly move and rotate the camera
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);
    }
}
