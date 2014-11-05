using UnityEngine;
using System.Collections;

public class DevCombatSkills
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CastLambertBall();
    }


    private void CastLambertBall()
    {
        // variables
        Vector3 ballDirection;
        Vector3 targetPosition;
        float ballSpeed = 25;
        int maxDistance = 30;

        // Create ball
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // Set transforms
        ball.transform.position = SPlayer.transform.position;
        ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Ignoring the raycasts
        ball.layer = LayerMask.NameToLayer("Ignore Raycast");

        // Add components
        ball.AddComponent<Rigidbody>();
        ball.AddComponent<CastLambertBall>();

        ball.GetComponent<Rigidbody>().useGravity = false;

        // Target location
        if (PlayerCombat.target == null)
        {
            if (CameraRaycast.impact.distance < maxDistance && CameraRaycast.impact.distance != 0)
                targetPosition = CameraRaycast.impact.point;
            else
                targetPosition = Camera.main.transform.position + Camera.main.transform.forward * maxDistance;
        }
        else
            targetPosition = PlayerCombat.target.transform.position;
            
        // Detecting initial direction
        ballDirection = targetPosition - SPlayer.transform.position;
        ballDirection.Normalize();
        ballDirection *= ballSpeed;

        // Launch
        ball.GetComponent<CastLambertBall>().Initialize(targetPosition, ballDirection, ballSpeed);
    }
}
