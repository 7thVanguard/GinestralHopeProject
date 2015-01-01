using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Interactive
{
    public enum PlacedOn { FLOOR, WALL, NONE }

    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Interactive> Dictionary;

    // Variables
    public PlacedOn placedOn;

    

    public virtual void Init(World world, Player player, MainCamera mainCamera, Interactive interactive)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Interactive>();

        //+ Gadgets
        // Dimensional Market
        interactive = new DimensionalMarket();
        interactive.Init(world, player, mainCamera, interactive);
        Dictionary.Add("Dimensional Market", interactive);

        interactive = new ToolsCloset();
        interactive.Init(world, player, mainCamera, interactive);
        Dictionary.Add("Tools Closet", interactive);

        interactive = Dictionary["Dimensional Market"];
    }


    public virtual void Place(string ID, Vector3 pos, Vector3 rotation, bool firstPlaced) { }
}
