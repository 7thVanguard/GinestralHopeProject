using UnityEngine;
using System.Collections;

public class ToolsCloset : Interactive 
{
    private Transform toolsCloset;

    public override void Init(World world, Player player, MainCamera mainCamera, Interactive gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        toolsCloset = world.interactives.FindChild("Tools Closet").transform;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, bool firstPlacing)
    {
        toolsCloset = Object.Instantiate(toolsCloset, pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        toolsCloset.name = "Tools Closet";
        toolsCloset.tag = "Interactive";

        toolsCloset.localScale = Vector3.one;
        toolsCloset.parent = world.interactivesController.transform;

        // Assign component
        toolsCloset.gameObject.AddComponent<ToolsClosetBehaviour>();
        toolsCloset.gameObject.AddComponent<ToolsClosetGUI>();
        toolsCloset.gameObject.AddComponent<InteractiveComponent>();
        toolsCloset.GetComponent<InteractiveComponent>().world = world;
    }
}
