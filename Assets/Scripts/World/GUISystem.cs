using UnityEngine;
using System.Collections;

public class GUISystem : MonoBehaviour 
{
    private enum MenuState {Main, Selector, OAudio, OVideo, OKeys, OAdvanced }

    private MenuState menuState = MenuState.Main;

    public GUIStyle menuStyle;

    public Texture background;

    void OnGUI()
    {
        if (true)
        {
            GUI.Box(new Rect(20, 20, Screen.width - 40, Screen.height - 20), GUIContent.none, menuStyle);

            switch (menuState)
            {
                case MenuState.Main:
                    {
                        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 60, 220, 80), "New Game", menuStyle)) { }
                    }
                    break;
                case MenuState.Selector:
                    break;
                case MenuState.OAudio:
                    break;
                case MenuState.OVideo:
                    break;
                case MenuState.OKeys:
                    break;
                case MenuState.OAdvanced:
                    break;
                default:
                    break;
            }
        }
    }
}
