using UnityEngine;
using System.Collections;

public class Nails : Gadget 
{
    public void PlaceGadget(World world, string ID, Vector3 pos, Vector3 rotation)
    {
        Transform nails = world.nails;
        nails = Object.Instantiate(nails, pos, Quaternion.identity) as Transform;

        // Head atributes
        nails.name = "Wood Pieces";
        nails.tag = "Gadget";

        // Set transforms
        nails.transform.eulerAngles = rotation;
        nails.transform.localScale = GadgetDictionary.GadgetsDictionary[nails.name].size;
    }
}
