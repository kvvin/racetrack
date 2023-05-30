using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;                    // The target object to follow
    public Vector3 offset;                      // The offset from the target's position
    public float smoothSpeed = 0.125f;          // The smoothing factor for camera movement
    public float rotationDamping = 5f;          // The damping factor for camera rotation

    private Vector3 desiredPosition;            // The desired position of the camera
    private Quaternion desiredRotation;         // The desired rotation of the camera

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