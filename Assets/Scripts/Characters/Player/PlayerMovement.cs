using UnityEngine;
using System.Collections;


public class PlayerMovement
{
    private World world;
    private Player player;
    private MainCamera mainCamera;

    private GameObject ringMarker;
    private GameObject lookAtObjective;
    private Vector3 objectiveDirection;
    private Vector3 interpolateDirection;

    private int jumpAnimationCounter = 0;


    public PlayerMovement(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ringMarker = (GameObject)Resources.Load("Particle Systems/Clouds Sight/Ring Marker/Ring Marker");
        lookAtObjective = new GameObject();
        lookAtObjective.transform.parent = player.playerObj.transform;
        lookAtObjective.transform.localPosition = Vector3.zero;
        lookAtObjective.transform.localEulerAngles = Vector3.zero;
        lookAtObjective.transform.localScale = Vector3.zero;
    }


    public void NormalMovementUpdate()
    {
        if (GameFlow.runningGame == GameFlow.RunningGame.CLOUDS_SIGHT)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                InputMovement();
                Movement(player.runSpeed);
            }
            // Stopping key
            else
            {
                player.targetPosition.x = player.playerObj.transform.position.x;
                player.targetPosition.y = player.playerObj.transform.position.z;
                objectiveDirection = Vector3.zero;
            }

            if (!player.controller.isGrounded)
                objectiveDirection.y -= GamePhysics.gravity * Time.deltaTime;
            else
                objectiveDirection.y = 0;

            // Assign movement
            player.controller.Move(objectiveDirection * Time.deltaTime);
        }
        else
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
                {
                    objectiveDirection = new Vector3(objectiveDirection.x, player.jumpInitialSpeed, objectiveDirection.z);
                }
                else
                    objectiveDirection.y = 0;

                // Set back the counter to 0 preventing the jump animation play for little air times
                jumpAnimationCounter = 0;
            }
            else
            {
                objectiveDirection += new Vector3(0, -GamePhysics.gravity * player.jumpGravityMultiplier, 0) * Time.deltaTime;

                // Jump animation activation
                jumpAnimationCounter++;
                if (jumpAnimationCounter >= 3)
                    Animation("Jump", false, true); 
            }

            // Assign movement
            player.controller.Move(interpolateDirection * Time.deltaTime);
        }

        // Light lantern if it is too dark
        if (RenderSettings.ambientLight.r < 125 / 255f)
        {
            if (RenderSettings.ambientLight.r < 25 / 255f)
                player.pointLight.SetActive(true);
            else
                player.pointLight.SetActive(false);

            player.spotLight.SetActive(true);

            // Lantern look at camera lerp
            Quaternion actualRotation;
            Quaternion lookAtRotation;

            actualRotation = player.spotLight.transform.rotation;
            player.spotLight.transform.LookAt(mainCamera.raycast.point);
            lookAtRotation = player.spotLight.transform.rotation;

            player.spotLight.transform.rotation = Quaternion.Lerp(actualRotation, lookAtRotation, 0.5f);

            // Intensity varies depending on darkness
            player.spotLight.light.intensity = Mathf.Pow(1 - RenderSettings.ambientLight.r, 3) * 2.5f;
        }
        else
        {
            // Turn off the lantern when is not dark
            player.pointLight.SetActive(false);
            player.spotLight.SetActive(false);
        }

        // Animation speed Control
        player.playerObj.transform.FindChild("Mesh").animation["Run"].speed = 1.1f;
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
        {
            objectiveDirection = new Vector3(-root, objectiveDirection.y, root);

            Animation("Run", true, false); 
        }
        else if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)))
        {
            objectiveDirection = new Vector3(root, objectiveDirection.y, root);

            Animation("Run", true, false); 
        }
        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.A)))
        {
            objectiveDirection = new Vector3(-root, objectiveDirection.y, -root);

            Animation("Run", true, false); 
        }
        else if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.D)))
        {
            objectiveDirection = new Vector3(root, objectiveDirection.y, -root);

            Animation("Run", true, false); 
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                objectiveDirection = new Vector3(speed, objectiveDirection.y, 0);

                Animation("Run", true, false); 
            }
            else if (Input.GetKey(KeyCode.A))
            {
                objectiveDirection = new Vector3(-speed, objectiveDirection.y, 0);

                Animation("Run", true, false); 
            }
            else if (Input.GetKey(KeyCode.W))
            {
                objectiveDirection = new Vector3(0, objectiveDirection.y, speed);

                Animation("Run", true, false); 
            }
            else if (Input.GetKey(KeyCode.S))
            {
                objectiveDirection = new Vector3(0, objectiveDirection.y, -speed);

                Animation("Run", true, false); 
            }
            else
            {
                objectiveDirection = new Vector3(0, objectiveDirection.y, 0);
                player.isMoving = false;

                Animation("Idle", true, false); 
            }
        }

        // Set the objective direction depending on the camera rotation
        player.playerObj.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, 0);
        objectiveDirection = player.playerObj.transform.TransformDirection(objectiveDirection);

        // Player looking at movement direction
        // objective
        lookAtObjective.transform.LookAt(new Vector3(   objectiveDirection.x + player.playerObj.transform.position.x,
                                                        player.playerObj.transform.position.y,
                                                        objectiveDirection.z + player.playerObj.transform.position.z));
        // Lerp to objective
        player.playerObj.transform.FindChild("Mesh").rotation = Quaternion.Lerp(player.playerObj.transform.FindChild("Mesh").rotation,
                                                                lookAtObjective.transform.rotation, 0.25f);
    }


    private void InputMovement()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Get the raycast impact point
            if (mainCamera.raycast.transform != null)
                if (mainCamera.raycast.transform.gameObject.tag == "Chunk")
                {
                    player.targetPosition.x = mainCamera.raycast.point.x;
                    player.targetPosition.y = mainCamera.raycast.point.z;
                }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            // Instantiates a ring just one centimeter above the place clicked
            GameObject effect = Object.Instantiate(ringMarker,
                                        new Vector3(player.targetPosition.x, mainCamera.raycast.point.y + 0.01f, player.targetPosition.y),
                                        Quaternion.identity) as GameObject;
        }
    }


    private void Movement(float speed)
    {
        Vector2 objectiveDirection2D, playerPosition2D;

        playerPosition2D.x = player.playerObj.transform.position.x;
        playerPosition2D.y = player.playerObj.transform.position.z;

        if (Vector3.Distance(playerPosition2D, player.targetPosition) > speed * Time.deltaTime)
        {
            objectiveDirection2D = (player.targetPosition - playerPosition2D).normalized * speed;
            objectiveDirection.x = objectiveDirection2D.x;
            objectiveDirection.z = objectiveDirection2D.y;

            player.playerObj.transform.LookAt(new Vector3(player.targetPosition.x, player.playerObj.transform.position.y, player.targetPosition.y));
        }
        else
        {
            objectiveDirection.x = 0;
            objectiveDirection.z = 0;
        }
    }


    private void Animation(string animationName, bool grounded, bool air)
    {
        if (grounded)
        {
            if (player.controller.isGrounded)
                player.playerObj.transform.FindChild("Mesh").animation.CrossFade(animationName);
        }
        else if (air)
        {
            if (!player.controller.isGrounded)
                player.playerObj.transform.FindChild("Mesh").animation.CrossFade(animationName);
        }
        else { }
    }
}
