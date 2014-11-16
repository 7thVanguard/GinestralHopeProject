using UnityEngine;
using System.Collections;

public class WoodPieces : Gadget 
{
    public void PlaceGadget(World world, string ID, Vector3 pos, Vector3 rotation)
    {
        Transform woodPieces = world.woodPieces;
        woodPieces = Object.Instantiate(woodPieces, pos, Quaternion.identity) as Transform;

        // Head atributes
        woodPieces.name = "Wood Pieces";
        woodPieces.tag = "Gadget";

        // Set transforms
        woodPieces.transform.eulerAngles = rotation;
        woodPieces.transform.localScale = GadgetDictionary.GadgetsDictionary[woodPieces.name].size;
    }
}
