using UnityEngine;
using System.Collections;

public class PlayerHUD
{
    private float lateralButtonSize = Screen.height * 6 / 50;


    public void Update(Texture2D developerAtlas)
    {
        // Fire Ball
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(0 / 8f, 1 / 8f, 1 / 8f, 1 / 8f));
        GUI.Label(new Rect(Screen.width * 41 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), "1");

        // Wooden Bridge
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 60 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(0 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));
        GUI.Label(new Rect(Screen.width * 61 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), "4");

        // Bomb
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 70 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(2 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));
        GUI.Label(new Rect(Screen.width * 71 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), "5");
    }
}
