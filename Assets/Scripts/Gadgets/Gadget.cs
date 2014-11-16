using UnityEngine;
using System.Collections;


public class Gadget
{
    public string nameKey;
    public int blastResistance;
    public Vector3 size;

    public int count;

    // Drops
    public bool givesComponents;
    public int dropCount;


    public void PlaceGadget(World world, string ID, Vector3 pos, Vector3 rotation)
    {
        switch(ID)
        {
            case "Wooden Plank":
            {
                WoodenPlank woodenPlamk = new WoodenPlank();
                woodenPlamk.PlaceGadget(ID, pos, rotation);
            }
            break;
            case "Wood Pieces":
            {
                WoodPieces woodPieces = new WoodPieces();
                woodPieces.PlaceGadget(world, ID, pos, rotation);
            }
            break;
            case "Nails":
            {
                Nails nails = new Nails();
                nails.PlaceGadget(world, ID, pos, rotation);
            }
            break;
        }
    }
}
