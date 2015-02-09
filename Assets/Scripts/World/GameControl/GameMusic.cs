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


    public static bool CheckFadeOut(Transform audioTransform)
    {
        if (audioTransform.audio.volume <= 0)
            return true;
        else
        {
            FadeOut(audioTransform);
            return false;
        }
    }

    private static void FadeIn(Transform audioTransform)
    {
        if (audioTransform.audio.volume < 1)
            audioTransform.audio.volume += 0.2f * Time.deltaTime;

        if (audioTransform.audio.volume >= 1)
            fadingIn = false;
    }


    private static void FadeOut(Transform audioTransform)
    {
        if (audioTransform.audio.volume > 0)
            audioTransform.audio.volume -= 0.5f * Time.deltaTime;

        if (audioTransform.audio.volume <= 0)
            fadingOut = false;
    }


    public static void SelectClips(string saveName)
    {
        switch (saveName)
        {
            case "NewGameGH":
                {
                    Global.player.playerObj.transform.FindChild("MusicPlayer").audio.clip = (AudioClip)Resources.Load("Audio/OST/Gameplay/Cavern of Time");
                    Global.player.playerObj.transform.FindChild("MusicPlayer").audio.Play();
                }
                break;
            case "CaverninaFirstLevel":
                {
                    Global.player.playerObj.transform.FindChild("MusicPlayer").audio.clip = (AudioClip)Resources.Load("Audio/OST/Gameplay/The Land of Lament V2");
                    Global.player.playerObj.transform.FindChild("MusicPlayer").audio.Play();
                }
                break;
            case "CaverninaBoss":
                {
                    Global.player.playerObj.transform.FindChild("MusicPlayer").audio.clip = (AudioClip)Resources.Load("Audio/OST/Boss Stage/Rise of The Titans V2");
                    Global.player.playerObj.transform.FindChild("MusicPlayer").audio.Play();
                }
                break;
            default:
                break;
        }
    }
}