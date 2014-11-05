using UnityEngine;
using System.Collections;

public class CameraMovement
{
    private CharacterController cameraController;

    Vector3 cameraOffset;
    Vector3 cameraDirection;
    private float objectivePosition;
    private float interpolationPosition;
    private float angleSight;


    public void Start(GameObject camera)
    {
        cameraController = camera.GetComponent<CharacterController>();
    }


    public void Update()
    {
        // Camera aim that depends on the player
        cameraOffset = SPlayer.transform.right * 0.5f + SPlayer.transform.forward * 0.3f + Vector3.up * (1.2f - angleSight / 45.0f);

        // Mouse inputs
        objectivePosition += Input.GetAxis("Mouse X") * SCamera.mouseSensitivityX;
        angleSight -= Input.GetAxis("Mouse Y") * SCamera.mouseSensitivityY;

        // Set a maxium and minium pitch angle
        angleSight = Mathf.Clamp(angleSight, SCamera.minAngleSight, SCamera.maxAngleSight);

        // Interpolates between the actual rotation and the rotation objective
        interpolationPosition = Mathf.Lerp(interpolationPosition, objectivePosition, SCamera.rotationSensitivity);

        // Sets the rotation and the position, uses the camera offset as the central point
        Quaternion rotation = Quaternion.Euler(angleSight, interpolationPosition, 0);
        Vector3 position = rotation * (new Vector3(0, 0, -SCamera.distance)) + SPlayer.transform.position + cameraOffset;

        // Calculates the displacement
        cameraDirection = position - Camera.main.transform.position;

        // Assign the rotation
        Camera.main.transform.rotation = rotation;

        // Assign the movement
        cameraController.Move(cameraDirection);
    }
}
