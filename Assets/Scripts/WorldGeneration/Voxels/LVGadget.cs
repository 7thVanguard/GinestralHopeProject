using UnityEngine;
using System.Collections;

public static class LVGadget
{
    public static void placePlank(Vector3 position, int rotation)
    {
        if (GadgetDictionary.GadgetsDictionary.ContainsKey("Wooden Plank"))
        {
            if (GadgetDictionary.GadgetsDictionary["Wooden Plank"].count >= 1)
            {
                GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Gadget gadget = GadgetDictionary.GadgetsDictionary["Wooden Plank"];

                plank.name = "Wooden Plank";
                plank.tag = "Gadget";

                // Set the transform of the plank
                if (rotation == 0)
                {
                    plank.transform.position = new Vector3(position.x + gadget.size.x / 2.0f, position.y + gadget.size.y / 2.0f, position.z + gadget.size.z / 2.0f);
                    plank.transform.localScale = gadget.size;
                }
                else if (rotation == 90)
                {
                    plank.transform.position = new Vector3(position.x + gadget.size.z / 2.0f, position.y + gadget.size.y / 2.0f, position.z + gadget.size.x / 2.0f);
                    plank.transform.localScale = gadget.size;
                }
                else if (rotation == 180)
                {
                    plank.transform.position = new Vector3(position.x + gadget.size.x / 2.0f, position.y + gadget.size.y / 2.0f, 1 + position.z - gadget.size.z / 2.0f);
                    plank.transform.localScale = gadget.size;
                }
                else
                {
                    plank.transform.position = new Vector3(1 + position.x - gadget.size.z / 2.0f, position.y + gadget.size.y / 2.0f, position.z + gadget.size.x / 2.0f);
                    plank.transform.localScale = gadget.size;
                }

                plank.transform.eulerAngles = new Vector3(0, rotation, 0);

                // Remove the plank from the inventory
                GadgetDictionary.GadgetsDictionary["Wooden Plank"].count--;
            }
        }
        GameComponentDictionary.GameComponentsDictionary["Wood Pieces"].count++;
        GameComponentDictionary.GameComponentsDictionary["Nails"].count += 4;
    }
}
