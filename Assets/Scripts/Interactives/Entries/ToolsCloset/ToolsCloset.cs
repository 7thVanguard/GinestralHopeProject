using UnityEngine;
using System.Collections;

public class ToolsCloset : Interactive 
{
    GameObject toolsCloset;

    public override void Init(World world, Player player, MainCamera mainCamera, Interactive gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        toolsCloset = (GameObject)Resources.Load("Props/Interactives/Tools Closet/Tools Closet");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, bool firstPlacing)
    {
        toolsCloset = GameObject.Instantiate(toolsCloset, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        toolsCloset.name = "Tools Closet";
        toolsCloset.tag = "Interactive";

        toolsCloset.transform.localScale = Vector3.one;
        toolsCloset.transform.parent = world.interactivesController.transform;

        // Assign component
        toolsCloset.gameObject.AddComponent<ToolsClosetBehaviour>();
        toolsCloset.gameObject.AddComponent<ToolsClosetGUI>();
        toolsCloset.gameObject.AddComponent<InteractiveComponent>();
        toolsCloset.GetComponent<InteractiveComponent>().world = world;
    }
}
