using UnityEngine;
using System.Collections;

public class GUISystem : MonoBehaviour 
{
    World world;


    private enum MenuState {MAIN, SELECTOR, AUDIO_OPTIONS, VIDEO_OPTIONS, KEYS_OPTIONS, ADVANCED_OPTIONS }

    private MenuState menuState = MenuState.MAIN;

    //public GUIStyle menuStyle;

    //public Texture background;



    public void Init(World world)
    {
        this.world = world;
    }



    void OnGUI()
    {
        if (EGameFlow.gameState == EGameFlow.GameState.MENU)
        {
             GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none);

            switch (menuState)
            {
                case MenuState.MAIN:
                    {
                        if (GUI.Button(new Rect(Screen.width * 2 / 5, Screen.height * 1 / 6, Screen.width / 5, Screen.height / 6 - 20), "New Game"))
                        {
                            world.worldObj.GetComponent<GameManager>().gameSerializer.Load(world, "NewGameSave");
                            EGameFlow.gameState = EGameFlow.GameState.GAME;
                        }
                        else if (GUI.Button(new Rect(Screen.width * 2 / 5, Screen.height * 2 / 6, Screen.width / 5, Screen.height / 6 - 20), "Load Game"))
                        {
                            world.worldObj.GetComponent<GameManager>().gameSerializer.Load(world, "CaverninaOnPlaySave");
                            EGameFlow.gameState = EGameFlow.GameState.GAME;
                        }
                    }
                    break;
                case MenuState.SELECTOR:
                    break;
                case MenuState.AUDIO_OPTIONS:
                    break;
                case MenuState.VIDEO_OPTIONS:
                    break;
                case MenuState.KEYS_OPTIONS:
                    break;
                case MenuState.ADVANCED_OPTIONS:
                    break;
                default:
                    break;
            }
        }
    }
}
