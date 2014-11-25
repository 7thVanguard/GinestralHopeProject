using UnityEngine;
using System.Collections;


public class PlayerMovement
{
    private Player player;

    private Vector3 objectiveDirection;
    private Vector3 interpolateDirection;


    public PlayerMovement(Player player)
    {
        this.player = player;
    }


    public void NormalMovementUpdate()
    {
        // Calculates the module of the speed
        float root = Mathf.Sqrt(player.runSpeed * player.runSpeed / 2);

        // Acceleration and deceleration
        interpolateDirection = new Vector3(Mathf.Lerp(interpolateDirection.x, objectiveDirection.x, player.acceleration),
                                            objectiveDirection.y,
                                            Mathf.Lerp(interpolateDirection.z, objectiveDirection.z, player.acceleration));

        // Calculates the direction
        HorizontalMovement(player.runSpeed, root);

        // Jump
        if (player.controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
                objectiveDirection = new Vector3(objectiveDirection.x, player.jumpInitialSpeed, objectiveDirection.z);
        }
        else
            objectiveDirection += new Vector3(0, -EGamePhysics.gravity * player.jumpGravityMultiplier, 0) * Time.deltaTime;

        // Assign movement
        player.controller.Move(interpolateDirection * Time.deltaTime);
    }


    public void DeveloperMovementUpdate()
    {
        // Calculates the module of the speed
        float root = Mathf.Sqrt(player.godModeSpeed * player.godModeSpeed / 2);

        // Acceleration and deceleration
        interpolateDirection = new Vector3(Mathf.Lerp(interpolateDirection.x, objectiveDirection.x, player.acceleration),
                                            objectiveDirection.y,
                                            Mathf.Lerp(interpolateDirection.z, objectiveDirection.z, player.acceleration));
        
        // Calculates the direction
        HorizontalMovement(player.godModeSpeed, root);

        // Fly
        if (Input.GetKey(KeyCode.E))
            objectiveDirection = new Vector3(objectiveDirection.x, player.godModeSpeed, objectiveDirection.z);
        else if (Input.GetKey(KeyCode.Q))
            objectiveDirection = new Vector3(objectiveDirection.x, -player.godModeSpeed, objectiveDirection.z);
        else
            objectiveDirection = new Vector3(objectiveDirection.x, 0, objectiveDirection.z);

        // Assign movement
        player.controller.Move(interpolateDirection * Time.deltaTime);
    }


    private void HorizontalMovement(float speed, float root)
    {
        player.isMoving = true;

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
            {
                objectiveDirection = new Vector3(0, objectiveDirection.y, 0);
                player.isMoving = false;
            }
        }

        player.playerObj.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        objectiveDirection = player.playerObj.transform.TransformDirection(objectiveDirection);
    }
}
