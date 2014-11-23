using UnityEngine;
using System.Collections;

public class CameraMovement
{
    Player player;
    MainCamera mainCamera;

    RaycastHit impact;


    public CameraMovement(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public void Start(GameObject camera)
    {
        Vector3 beginingRotation = mainCamera.cameraObj.transform.eulerAngles;
        mainCamera.interpolatedPosition = beginingRotation.y;
        mainCamera.angleSight = beginingRotation.x;

        Physics.IgnoreCollision(mainCamera.cameraObj.collider, player.playerObj.collider);
    }


    public void Update()
    {
        // Camera aim depending on the player
        mainCamera.offset = player.playerObj.transform.right * 0.5f + player.playerObj.transform.forward * 0.3f + Vector3.up * (1.2f - mainCamera.angleSight / 45.0f);

        // Mouse inputs
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            mainCamera.interpolatedPosition += Input.GetAxis("Mouse X") * mainCamera.mouseSensitivityX;
            mainCamera.angleSight -= Input.GetAxis("Mouse Y") * mainCamera.mouseSensitivityY;
        }

        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            mainCamera.isMoving = true;
        else
            mainCamera.isMoving = false;

        // Zoom adapt
        if (mainCamera.objectiveDistance < mainCamera.maxDistance && (mainCamera.isMoving || player.isMoving))
            mainCamera.objectiveDistance += Time.deltaTime;

        // Angle sight clamp
        mainCamera.angleSight = ClampAngle(mainCamera.angleSight, mainCamera.minAngleSight, mainCamera.maxAngleSight);

        // Camera rotation
        Quaternion rotation = Quaternion.Euler(mainCamera.angleSight, mainCamera.interpolatedPosition, 0);
        mainCamera.cameraObj.transform.rotation = rotation;

        // Camera position 
        mainCamera.previousPosition = mainCamera.cameraObj.transform.position;
        mainCamera.position = player.playerObj.transform.position + mainCamera.offset - (rotation * Vector3.forward * mainCamera.objectiveDistance);
        mainCamera.controller.Move(mainCamera.position - mainCamera.previousPosition);

        // Blocked view detection
        Vector3 trueTargetPosition = player.playerObj.transform.position + mainCamera.offset;
        
        // Raycast with an objective
        if (Physics.Linecast(trueTargetPosition, mainCamera.cameraObj.transform.position, out impact))
        {
            if (impact.transform.gameObject.tag != "MainCamera" && impact.transform.gameObject.tag != "Player")
            {
                // Reallocates the camera
                float advancedDistance = Vector3.Distance(trueTargetPosition, impact.point) - 0.5f;
                mainCamera.objectiveDistance = Vector3.Distance(trueTargetPosition, impact.point) - 0.5f;
                mainCamera.cameraObj.transform.position = player.playerObj.transform.position + mainCamera.offset - (rotation * Vector3.forward * advancedDistance);
                //mainCamera.cameraObj.transform.position = mainCamera.position;
            }
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);

    }
}
