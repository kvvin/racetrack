# Unity 3D Race car simulation
This Unity 3D project is a basic race car simulation that includes a racetrack and a race car asset. The game allows the player to control the car using arrow key controls. The car asset is equipped with a physics controller, and the camera follows the car in a third-person perspective view.

# Steps
 - Set up the Unity 3D environment.
 - Import the racetrack and race car asset from the Unity Asset Store.
 - Create the car controller script.
 - Create the wheel controller script.
 - Create the camera controller script.

# Car Controller Script
The carController script controls the movement and steering of the car. It includes references to the wheel colliders and wheel meshes. The script applies motor torque to the rear wheels based on the vertical input axis (arrow keys), and it applies steering angle to the front wheels based on the horizontal input axis. The script also updates the wheel rotation based on the wheel collider's pose.

- public WheelCollider WheelFL;: Front left wheel collider reference.
- public WheelCollider WheelFR;: Front right wheel collider reference.
- public WheelCollider WheelRL;: Rear left wheel collider reference.
- public WheelCollider WheelRR;: Rear right wheel collider reference.
- public Transform WheelFLtrans;: Transform of the front left wheel mesh.
- public Transform WheelFRtrans;: Transform of the front right wheel mesh.
- public Transform WheelRLtrans;: Transform of the rear left wheel mesh.
- public Transform WheelRRtrans;: Transform of the rear right wheel mesh.
- public Transform centreofmass;: Transform representing the center of mass for the car.
- public float maxTorque = 1000f;: Maximum torque applied to the rear wheels.
- public float steerAngle = 30f;: Maximum steering angle for the front wheels.
- private Rigidbody rb;: Reference to the Rigidbody component attached to the car.
- rb.centerOfMass = centreofmass.transform.localPosition;: Sets the center of mass of the car to the position defined by the centreofmass transform.
- void FixedUpdate(): FixedUpdate is used for physics-related updates and ensures consistent simulation steps.
- float motorTorque = maxTorque * Input.GetAxis("Vertical");: Calculates the motor torque based on the vertical input axis.
- WheelRR.motorTorque = motorTorque;: Applies the calculated motor torque to the rear right wheel collider.
- WheelRL.motorTorque = motorTorque;: Applies the calculated motor torque to the rear left wheel collider.
- float steerInput = Input.GetAxis("Horizontal");: Retrieves the horizontal input axis for steering.
- WheelFL.steerAngle = steerAngle * steerInput;: Applies the steering angle to the front left wheel collider.
- WheelFR.steerAngle = steerAngle * steerInput;: Applies the steering angle to the front right wheel collider.
- UpdateWheelRotation(WheelFL, WheelFLtrans);: Updates the rotation of the front left wheel mesh to match the wheel collider's pose.
- UpdateWheelRotation(WheelFR, WheelFRtrans);: Updates the rotation of the front right wheel mesh to match the wheel collider's pose.
- UpdateWheelRotation(WheelRL, WheelRLtrans);: Updates the rotation of the rear left wheel mesh to match the wheel collider's pose.
- UpdateWheelRotation(WheelRR, WheelRRtrans);: Updates the rotation of the rear right wheel mesh to match the wheel collider's pose.
- void UpdateWheelRotation(WheelCollider wheelCollider, Transform wheelTransform): A helper method to update the rotation of a wheel mesh based on the corresponding wheel collider's pose.
- wheelCollider.GetWorldPose(out position, out rotation);: Retrieves the current world position and rotation of the wheel collider.
- wheelTransform.position = position;: Sets the wheel mesh's position to match the wheel collider's position.
- wheelTransform.rotation = rotation;: Sets the wheel mesh's rotation to match the wheel collider's rotation.

# Wheel Controller Script
The WheelController script is attached to each wheel mesh. It synchronizes the wheel mesh's position and rotation with the corresponding wheel collider's pose. For front wheels, it also applies the steer angle to the wheel rotation.

- public Transform wheelMesh;: The wheel mesh object that will be synchronized with the wheel collider's pose.
- public WheelCollider wheelCollider;: The corresponding wheel collider that represents the physical wheel.
- public bool isFrontWheel;: Indicates if the wheel is a front wheel. This is used to apply additional rotation if it's a front wheel that is being steered.
- void FixedUpdate(): FixedUpdate is used for physics-related updates and ensures consistent wheel synchronization.
- wheelCollider.GetWorldPose(out position, out rotation);: Retrieves the current world position and rotation of the wheel collider.
- wheelMesh.position = position;: Sets the wheel mesh's position to match the wheel collider's position.
- if (isFrontWheel): Checks if the wheel is a front wheel.
- float steerAngle = wheelCollider.steerAngle;: Retrieves the current steer angle of the wheel collider.
- wheelMesh.rotation = rotation * Quaternion.Euler(0f, steerAngle, 0f);: Applies rotation to the wheel mesh based on the steer angle of the wheel collider, creating a visual representation of the wheel being turned. For non-front wheels, the rotation is directly set to match the wheel collider's rotation.

# Camera Controller Script
The cameraController script is responsible for following the car and maintaining a third-person perspective view. It is attached to the camera object. The script calculates the desired position and rotation based on the target's position and the defined offset. It smoothly moves and rotates the camera towards the desired position and rotation using interpolation.

- public Transform target;: The target object that the camera will follow.
- public Vector3 offset;: The offset from the target's position, used to position the camera.
- public float smoothSpeed = 0.125f;: The smoothing factor for camera movement. Higher values make the camera movement smoother.
- public float rotationDamping = 5f;: The damping factor for camera rotation. Higher values make the camera rotation smoother.
- void LateUpdate(): LateUpdate is called after all other updates to ensure the camera follows the target correctly.
- desiredPosition = target.position - target.forward * offset.z - target.up * offset.y;: Calculates the desired position of the camera based on the target's position and the defined offset.
- desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);: Calculates the desired rotation of the camera to look at the target while keeping the up direction aligned with the target's up direction.
- transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);: Smoothly moves the camera towards the desired position using linear interpolation.
- transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationDamping * Time.deltaTime);: Smoothly rotates the camera towards the desired rotation using spherical linear interpolation.

Feel free to customize and enhance the game according to your requirements. Enjoy racing!

- Racetrack asset: https://assetstore.unity.com/packages/3d/environments/roadways/environmental-race-track-pack-63493
- Race car asset: https://assetstore.unity.com/packages/3d/vehicles/land/arcade-free-racing-car-161085

# Screenshots:

![image](https://github.com/kvvin/racetrack/assets/78724550/1977e9ce-e1ea-4b44-b4e6-2346b05e1378)
![image](https://github.com/kvvin/racetrack/assets/78724550/b94b8cf0-0dae-4376-b50a-903e08574f25)
![image](https://github.com/kvvin/racetrack/assets/78724550/07618fdb-92d2-407a-bb75-4d6e1f56fe4e)


