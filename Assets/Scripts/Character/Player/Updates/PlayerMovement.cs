using UnityEngine;
using System.Collections;


public class PlayerMovement
{
    private GameObject player;
    private CharacterController playerController;

    private Vector3 objectiveDirection;
    private Vector3 interpolateDirection;

    

    public void Start(GameObject player)
    {
        this.player = player;
        playerController = player.GetComponent<CharacterController>();
    }


    public void Update()
    {
        if (EGameFlow.generalMode != EGameFlow.GeneralMode.DEVELOPER)       // Normal mode
            NormalMovement();
        else                                                                // God mode
            GodModeMovement();

        // Assign movement
        playerController.Move(interpolateDirection * Time.deltaTime);
    }


    private void NormalMovement()
    {
        // Calculates the module of the speed
        float root = Mathf.Sqrt(SPlayer.runSpeed * SPlayer.runSpeed / 2);

        // Acceleration and deceleration
        interpolateDirection = new Vector3(Mathf.Lerp(interpolateDirection.x, objectiveDirection.x, SPlayer.acceleration),
                                            objectiveDirection.y,
                                            Mathf.Lerp(interpolateDirection.z, objectiveDirection.z, SPlayer.acceleration));

        // Calculates the direction
        HorizontalMovement(SPlayer.runSpeed, root);

        // Jump
        if (playerController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
                objectiveDirection = new Vector3(objectiveDirection.x, SPlayer.jumpInitialSpeed, objectiveDirection.z);
        }
        else
            objectiveDirection += new Vector3(0, -EGamePhysics.gravity * 1.5f, 0) * Time.deltaTime;
    }


    private void GodModeMovement()
    {
        // Calculates the module of the speed
        float root = Mathf.Sqrt(SPlayer.godModeSpeed * SPlayer.godModeSpeed / 2);

        // Acceleration and deceleration
        interpolateDirection = new Vector3(Mathf.Lerp(interpolateDirection.x, objectiveDirection.x, SPlayer.acceleration),
                                            objectiveDirection.y,
                                            Mathf.Lerp(interpolateDirection.z, objectiveDirection.z, SPlayer.acceleration));
        
        // Calculates the direction
        HorizontalMovement(SPlayer.godModeSpeed, root);

        // Fly
        if (Input.GetKey(KeyCode.E))
            objectiveDirection = new Vector3(objectiveDirection.x, SPlayer.godModeSpeed, objectiveDirection.z);
        else if (Input.GetKey(KeyCode.Q))
            objectiveDirection = new Vector3(objectiveDirection.x, -SPlayer.godModeSpeed, objectiveDirection.z);
        else
            objectiveDirection = new Vector3(objectiveDirection.x, 0, objectiveDirection.z);
    }


    private void HorizontalMovement(float speed, float root)
    {
        // Assign a direction depending on the input introduced
        if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)))
            objectiveDirection = new Vector3(-root, objectiveDirection.y, root);
        else if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
            objectiveDirection = new Vector3(root, objectiveDirection.y, root);
        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A)))
            objectiveDirection = new Vector3(-root, objectiveDirection.y, -root);
        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
            objectiveDirection = new Vector3(root, objectiveDirection.y, -root);
        else
        {
            if (Input.GetKey(KeyCode.D))
                objectiveDirection = new Vector3(speed, objectiveDirection.y, 0);
            else if (Input.GetKey(KeyCode.A))
                objectiveDirection = new Vector3(-speed, objectiveDirection.y, 0);
            else if (Input.GetKey(KeyCode.W))
                objectiveDirection = new Vector3(0, objectiveDirection.y, speed);
            else if (Input.GetKey(KeyCode.S))
                objectiveDirection = new Vector3(0, objectiveDirection.y, -speed);
            else
                objectiveDirection = new Vector3(0, objectiveDirection.y, 0);
        }

        player.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        objectiveDirection = player.transform.TransformDirection(objectiveDirection);
    }
}
