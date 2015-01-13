using UnityEngine;
using System.Collections;

public class Bomb : Geometry 
{
    GameObject bomb;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        bomb = (GameObject)Resources.Load("Props/Geometry/Bomb/Bomb");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation, Vector3 scale, bool firstPlacing)
    {
        if (GameFlow.selectedInteractive == "Bomb" || GameFlow.gameMode != GameFlow.GameMode.PLAYER)
        {
            bomb = GameObject.Instantiate(bomb, pos, Quaternion.identity) as GameObject;

            // Head atributes
            bomb.name = "Bomb";
            bomb.tag = "Geometry";
            bomb.transform.parent = world.interactivesController.transform;

            // Set transforms
            bomb.transform.position = new Vector3(pos.x, pos.y, pos.z);
            bomb.AddComponent<BombBehaviour>();
            bomb.GetComponent<BombBehaviour>().Init(world);
        }
    }
}
