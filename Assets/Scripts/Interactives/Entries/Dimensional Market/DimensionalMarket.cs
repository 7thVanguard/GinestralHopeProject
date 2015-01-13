using UnityEngine;
using System.Collections;

public class DimensionalMarket : Interactive
{
    GameObject dimensionalMarket;

    public override void Init(World world, Player player, MainCamera mainCamera, Interactive gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.NONE;

        dimensionalMarket = (GameObject)Resources.Load("Props/Interactives/Dimensional Market/Dimensional Market");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, bool firstPlacing)
    {
        dimensionalMarket = GameObject.Instantiate(dimensionalMarket, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        dimensionalMarket.name = "Dimensional Market";
        dimensionalMarket.tag = "Interactive";

        dimensionalMarket.transform.localScale = Vector3.one;
        dimensionalMarket.transform.parent = world.interactivesController.transform;

        // Assign component
        dimensionalMarket.gameObject.AddComponent<DimensionalMarketBehaviour>();
        dimensionalMarket.gameObject.AddComponent<InteractiveComponent>();
        dimensionalMarket.GetComponent<InteractiveComponent>().world = world;
    }
}
