using UnityEngine;
using System.Collections;

public class CameraMovement
{
    Player player;
    MainCamera mainCamera;


    public CameraMovement(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public void Start(GameObject camera)
    {
        mainCamera.controller = camera.GetComponent<CharacterController>();
    }


    public void Update()
    {
        // Camera aim that depends on the player
        mainCamera.offset = player.playerObj.transform.right * 0.5f + player.playerObj.transform.forward * 0.3f + Vector3.up * (1.2f - mainCamera.angleSight / 45.0f);

        // Mouse inputs
        mainCamera.objectivePosition += Input.GetAxis("Mouse X") * mainCamera.mouseSensitivityX;
        mainCamera.angleSight -= Input.GetAxis("Mouse Y") * mainCamera.mouseSensitivityY;

        // Set a maxium and minium pitch angle
        mainCamera.angleSight = Mathf.Clamp(mainCamera.angleSight, mainCamera.minAngleSight, mainCamera.maxAngleSight);

        // Interpolates between the actual rotation and the rotation objective
        mainCamera.interpolatedPosition = Mathf.Lerp(mainCamera.interpolatedPosition, mainCamera.objectivePosition, mainCamera.rotationSensitivity);

        // Sets the rotation and the position, uses the camera offset as the central point
        mainCamera.rotation = Quaternion.Euler(mainCamera.angleSight, mainCamera.interpolatedPosition, 0);
        Vector3 position = mainCamera.rotation * (new Vector3(0, 0, -mainCamera.distance)) + player.playerObj.transform.position + mainCamera.offset;

        // Calculates the displacement
        mainCamera.direction = position - mainCamera.cameraObj.transform.position;

        // Assign the rotation
        mainCamera.cameraObj.transform.rotation = mainCamera.rotation;

        // Assign the movement
        mainCamera.controller.Move(mainCamera.direction);
    }
}
