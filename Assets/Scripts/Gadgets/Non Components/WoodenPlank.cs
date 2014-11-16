using UnityEngine;
using System.Collections;

public class WoodenPlank : Gadget 
{
    public void PlaceGadget(string ID, Vector3 pos, Vector3 rotation)
    {
        GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Head atributes
        plank.name = "Wooden Plank";
        plank.tag = "Gadget";

        // Set transforms
        plank.transform.position = pos;
        plank.transform.eulerAngles = rotation;
        plank.transform.localScale = GadgetDictionary.GadgetsDictionary[plank.name].size;
    }
}
