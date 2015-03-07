using UnityEngine;
using System.Collections;

public class MainCamera
{
    public GameObject cameraObj;
    public GameObject voxelsObj;
    public CharacterController controller;


    // Camera movement
    public Quaternion rotation;
    public Vector3 offset;
    public Vector3 direction;

    public float objectivePosition;
    public Vector3 interpolatedPosition;

    public float angleSight;
    public float playerRelativeHeight = 0.8f;

    public Vector3 position;
    public Vector3 previousPosition;


    // Camera raycast
    public RaycastHit raycast;


    // Camera sensitivity
    public float mouseSensitivityX = 5;
    public float mouseSensitivityY = 5;
    public float rotationSensitivity = 0.2f;

    // Movement limits
    public float minAngleSight;
    public float maxAngleSight;
    public float distance;
    public float objectiveDistance;
    public float minDistance;
    public float maxDistance;
    public bool isMoving;


    public MainCamera()
    {
        Init();
    }


    public void ChangeCameraParams()
    {
        switch (GameFlow.runningGame)
        {
            case GameFlow.RunningGame.GINESTRAL_HOPE:
                {
                    minAngleSight = -85;
                    maxAngleSight = 85;

                    distance = 3;
                    objectiveDistance = 3;

                    minDistance = 3;
                    maxDistance = 3;
                }
                break;
            case GameFlow.RunningGame.CLOUDS_SIGHT:
                {
                    minAngleSight = 45;
                    maxAngleSight = 75;

                    distance = 15;
                    objectiveDistance = 15;

                    minDistance = 10;
                    maxDistance = 20;
                }
                break;
            case GameFlow.RunningGame.PLANNED_DREAM:
                {
                    minAngleSight = -85;
                    maxAngleSight = 85;

                    distance = 0;
                    objectiveDistance = 0;

                    minDistance = 0;
                    maxDistance = 0;
                }
                break;
            default:
                break;
        }
    }


    private void Init()
    {
        //+ Main camera creation
        cameraObj = new GameObject();

        cameraObj.name = "MainCamera";
        cameraObj.tag = "MainCamera";
        cameraObj.layer = LayerMask.NameToLayer("Player");

        // Camera components creation
        cameraObj.AddComponent<Camera>();
        controller = cameraObj.AddComponent<CharacterController>();
        controller.height = 0.3f;
        controller.radius = 0.3f;

        cameraObj.AddComponent("FlareLayer");

        ChangeCameraParams();
    }
}
