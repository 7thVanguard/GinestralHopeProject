using UnityEngine;
using System.Collections;

public class UCamera : MonoBehaviour
{
    private CameraMovement movement;
    private CameraRaycast raycast;


	void Start ()
    {
        movement = new CameraMovement();
        raycast = new CameraRaycast();

        transform.localPosition = SPlayer.transform.position + new Vector3(0, 0, -10);
        transform.localEulerAngles = Vector3.zero;

        gameObject.GetComponent<CharacterController>().transform.localScale = new Vector3(0.3f, 0.15f, 0.3f);

        movement.Start(gameObject);
	}
	

	void LateUpdate ()
    {
        if ((!EGameFlow.pause && UWorldGenerator.gameLoaded) || EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        {
            movement.Update();
            raycast.Update();
        }
	}
}
