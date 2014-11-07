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
        woodenPlank.count = 0;
        woodenPlank.givesComponents = false;
        woodenPlank.dropCount = 1;

        GadgetsDictionary.Add(woodenPlank.nameKey, woodenPlank);

        //+ Wood Pieces
        Gadget woodPieces = new Gadget();

        woodPieces.nameKey = "Wood Pieces";
        woodPieces.blastResistance = 0;
        woodPieces.size = Vector3.one;
        woodPieces.count = 0;
        woodPieces.givesComponents = true;
        woodPieces.dropCount = 1;

        GadgetsDictionary.Add(woodPieces.nameKey, woodPieces);

        //+ Nails
        Gadget nails = new Gadget();

        nails.nameKey = "Nails";
        nails.blastResistance = 0;
        nails.size = Vector3.one;
        nails.count = 0;
        nails.givesComponents = true;
        nails.dropCount = 4;

        GadgetsDictionary.Add(nails.nameKey, nails);
    }
}
