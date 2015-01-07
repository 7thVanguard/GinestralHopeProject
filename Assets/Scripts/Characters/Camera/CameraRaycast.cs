using UnityEngine;
using System.Collections;

public class CameraRaycast
{
    Player player;
    MainCamera mainCamera;


    public CameraRaycast(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public void Update()
    {
        if (GameFlow.gameMode == GameFlow.GameMode.DEVELOPER || GameFlow.runningGame != GameFlow.RunningGame.CLOUDS_SIGHT)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out mainCamera.raycast, 1000)) { }
        }
        else
        {
            Ray fromMouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(fromMouseRay, out mainCamera.raycast, 1000)) { }
        }
    }
}
