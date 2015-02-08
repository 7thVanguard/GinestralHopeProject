using UnityEngine;
using System.Collections;

public class GameMusic
{
    public static bool playing = false;
    public static bool fadingOut = false;
    public static bool fadingIn = true;


    public static void Update()
    {
        if (fadingOut)
        {
            FadeOut(Global.player.playerObj.transform.FindChild("MusicPlayer"));
        }
        else if (fadingIn)
        {
            FadeIn(Global.player.playerObj.transform.FindChild("MusicPlayer"));
        }
        else if (!playing)
        {
            if (GameFlow.gameState == GameFlow.GameState.MENU)
            {
                Global.player.playerObj.transform.FindChild("MusicPlayer").audio.Play();
                playing = true;
            }
        }
    }

    private static void FadeIn(Transform audioTransform)
    {
        if (audioTransform.audio.volume < 1)
            audioTransform.audio.volume += 0.2f * Time.deltaTime;
    }


    private static void FadeOut(Transform audioTransform)
    {
        if (audioTransform.audio.volume > 0)
            audioTransform.audio.volume -= 0.2f * Time.deltaTime;
    }
}