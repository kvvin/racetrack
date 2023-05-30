# Unity 3D Car Racing Game
This Unity 3D project is a basic car racing game that includes a racetrack and a race car asset. The game allows the player to control the car using arrow key controls. The car asset is equipped with a physics controller, and the camera follows the car in a third-person perspective view.

# Steps
Set up the Unity 3D environment.
Import the racetrack and race car asset from the Unity Asset Store.
Create the car controller script.
Create the wheel controller script.
Create the camera controller script.

# Car Controller Script
The carController script controls the movement and steering of the car. It includes references to the wheel colliders and wheel meshes. The script applies motor torque to the rear wheels based on the vertical input axis (arrow keys), and it applies steering angle to the front wheels based on the horizontal input axis. The script also updates the wheel rotation based on the wheel collider's pose.

# Wheel Controller Script
The WheelController script is attached to each wheel mesh. It synchronizes the wheel mesh's position and rotation with the corresponding wheel collider's pose. For front wheels, it also applies the steer angle to the wheel rotation.

# Camera Controller Script
The cameraController script is responsible for following the car and maintaining a third-person perspective view. It is attached to the camera object. The script calculates the desired position and rotation based on the target's position and the defined offset. It smoothly moves and rotates the camera towards the desired position and rotation using interpolation.

Feel free to customize and enhance the game according to your requirements. Enjoy racing!

Racetrack asset: https://assetstore.unity.com/packages/3d/environments/roadways/environmental-race-track-pack-63493
Race car asset: https://assetstore.unity.com/packages/3d/vehicles/land/arcade-free-racing-car-161085

# Screenshots:

![image](https://github.com/kvvin/racetrack/assets/78724550/1977e9ce-e1ea-4b44-b4e6-2346b05e1378)
![image](https://github.com/kvvin/racetrack/assets/78724550/b94b8cf0-0dae-4376-b50a-903e08574f25)
![image](https://github.com/kvvin/racetrack/assets/78724550/07618fdb-92d2-407a-bb75-4d6e1f56fe4e)


