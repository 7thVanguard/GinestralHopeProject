using UnityEngine;
using System.Collections;

public class DimensionalMarket : Interactive
{
    private Transform dimensionalMarket;

    public override void Init(World world, Player player, MainCamera mainCamera, Interactive gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.NONE;

        dimensionalMarket = world.interactives.FindChild("Dimensional Market").transform;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, bool firstPlacing)
    {
        dimensionalMarket = Object.Instantiate(dimensionalMarket, pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        dimensionalMarket.name = "Dimensional Market";
        dimensionalMarket.tag = "Interactive";

        dimensionalMarket.localScale = Vector3.one;
        dimensionalMarket.parent = world.interactivesController.transform;

        // Assign component
        dimensionalMarket.gameObject.AddComponent<DimensionalMarketBehaviour>();
        dimensionalMarket.gameObject.AddComponent<InteractiveComponent>();
        dimensionalMarket.GetComponent<InteractiveComponent>().world = world;
    }
}
