using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameComponentDictionary : MonoBehaviour 
{
    public static Dictionary<string, GameComponent> GameComponentsDictionary = new Dictionary<string, GameComponent>();


    void Awake()
    {
        //+ Wood Pieces
        GameComponent woodPieces = new GameComponent();

        woodPieces.nameKey = "Wood Pieces";
        woodPieces.count = 0;

        GameComponentsDictionary.Add(woodPieces.nameKey, woodPieces);

        //+ Nails
        GameComponent nails = new GameComponent();

        nails.nameKey = "Nails";
        nails.count = 0;

        GameComponentsDictionary.Add(nails.nameKey, nails);
    }
}
