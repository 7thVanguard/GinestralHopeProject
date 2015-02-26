using UnityEngine;
using System.Collections;

public class PlayerHUD
{
    private Texture2D lifeFull;
    private Texture2D lifeEmpty;
    private Texture2D coin;

    private int margin = 5;
    private int collectorYposition = 0;


    public void Start()
    {
        lifeFull = (Texture2D)Resources.Load("GUI/Ginestral Hope GUI/HUD/LifeFull");
        lifeEmpty = (Texture2D)Resources.Load("GUI/Ginestral Hope GUI/HUD/LifeEmpty");
        coin = (Texture2D)Resources.Load("GUI/Ginestral Hope GUI/HUD/Coin");
    }


    public void Update()
    {
        // Life
        for (int i = 0; i < Global.player.maxLife; i++)
        {
            if (Global.player.currentLife > i)
                GUI.DrawTextureWithTexCoords(new Rect(margin * (i + 1) + i * Screen.width / 40, margin, Screen.width / 40, Screen.width / 40), lifeFull, 
                                             new Rect(0, 0, 1, 1));
            else
                GUI.DrawTextureWithTexCoords(new Rect(margin * (i + 1) + i * Screen.width / 40, margin, Screen.width / 40, Screen.width / 40), lifeEmpty, 
                                             new Rect(0, 0, 1, 1));
        }


        // Orbs
        // GUI Style
        GUI.skin.label.fontSize = 30;
        GUI.skin.font = (Font)Resources.Load("Fonts/Amigo-Regular");


        GUI.DrawTextureWithTexCoords(new Rect(Screen.width / 2 - Screen.width / 60, margin + collectorYposition, Screen.width / 30, Screen.width / 30), coin, 
                                     new Rect(0, 0, 1, 1));

        GUI.Label(new Rect(margin + Screen.width / 2 + Screen.width / 60, margin + collectorYposition, Screen.width / 3, Screen.width / 30), 
                  "x " + Global.player.orbsCollected);
    }
}
