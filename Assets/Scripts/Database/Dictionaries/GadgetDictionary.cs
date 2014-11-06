using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GadgetDictionary : MonoBehaviour
{
    public static Dictionary<string, Gadget> GadgetsDictionary = new Dictionary<string, Gadget>();

    
    void Awake()
    {
        //+ Wooden Plank
        Gadget woodenPlank = new Gadget();

        woodenPlank.nameKey = "Wooden Plank";
        woodenPlank.blastResistance = 0;
        woodenPlank.size = new Vector3(1, 0.1f, 6);
        woodenPlank.voxelDrop = "Wooden Plank";
        woodenPlank.voxelDropCount = 1;
        woodenPlank.componentDrop = "Nothing";
        woodenPlank.componentDropCount = 0;
        woodenPlank.count = 0;

        GadgetsDictionary.Add(woodenPlank.nameKey, woodenPlank);

        //+ Wood Pieces
        Gadget woodPieces = new Gadget();

        woodPieces.nameKey = "Wood Pieces";
        woodPieces.blastResistance = 0;
        woodPieces.size = Vector3.one;
        woodPieces.voxelDrop = "Nothing";
        woodPieces.voxelDropCount = 0;
        woodPieces.componentDrop = "Wood Pieces";
        woodPieces.componentDropCount = 1;
        woodPieces.count = 0;

        GadgetsDictionary.Add(woodPieces.nameKey, woodPieces);

        //+ Nails
        Gadget nails = new Gadget();

        nails.nameKey = "Nails";
        nails.blastResistance = 0;
        nails.size = Vector3.one;
        nails.voxelDrop = "Nothing";
        nails.voxelDropCount = 0;
        nails.componentDrop = "Nails";
        nails.componentDropCount = 4;
        nails.count = 0;

        GadgetsDictionary.Add(nails.nameKey, nails);
    }
}
