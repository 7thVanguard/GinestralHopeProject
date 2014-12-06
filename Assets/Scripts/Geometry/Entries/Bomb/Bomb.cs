using UnityEngine;
using System.Collections;

public class Bomb : Geometry 
{
    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation, Vector3 scale)
    {
        if (EGameFlow.selectedGadget == "Bomb" || EGameFlow.gameMode != EGameFlow.GameMode.PLAYER)
        {
            Transform bomb = Object.Instantiate(world.gadgets.FindChild("Bomb"), pos, Quaternion.identity) as Transform;

            // Head atributes
            bomb.name = "Bomb";
            bomb.tag = "Geometry";
            bomb.transform.parent = world.gadgetsController.transform;

            // Set transforms
            bomb.transform.position = new Vector3(pos.x, pos.y, pos.z);
            bomb.gameObject.AddComponent<BombBehaviour>();
            bomb.gameObject.GetComponent<BombBehaviour>().Init(world);
        }
    }
}
