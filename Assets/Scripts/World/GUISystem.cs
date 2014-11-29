using UnityEngine;
using System.Collections;

public class GUISystem : MonoBehaviour 
{
    World world;
    Texture2D atlasGUI;
    Font ghFont;

    int timer;
    bool show;
    //Derivated Textures
    Texture2D background;
    Texture2D pressStart;
    Texture2D iddleButton;
    Texture2D pressedButton;
    Texture2D hoverButton;
    Texture2D title;


    private enum MenuState { PRESSENTER, MAIN, SELECTOR, AUDIO_OPTIONS, VIDEO_OPTIONS, KEYS_OPTIONS, ADVANCED_OPTIONS }

    private MenuState menuState = MenuState.PRESSENTER;

    public GUIStyle ghStyle;



    public void Init(World world, Texture2D background, Texture2D pressStart, Texture2D iddleButton, Texture2D pressedButton, Texture2D hoverButton, Texture2D title, Font ghFont)
    {
        this.world = world;
        this.atlasGUI = background;
        this.pressStart = pressStart;
        this.ghFont = ghFont;

        this.iddleButton = iddleButton;
        this.pressedButton = pressedButton;
        this.hoverButton = hoverButton;
        this.title = title;


        //Initialize Style
        ghStyle.name = "GHStyle";
        ghStyle.font = ghFont;
        ghStyle.fontSize = 50;
        ghStyle.normal.background = background;
        ghStyle.normal.textColor = Color.black;

        ghStyle.onHover.background = background;
    }



    void OnGUI()
    {
        if (EGameFlow.gameState == EGameFlow.GameState.MENU)
        {
             GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none, ghStyle);

            switch (menuState)
            {
                case MenuState.PRESSENTER:
                    {
                        timer++;

                        GUI.DrawTexture(new Rect(Screen.width / 2 - title.width / 2, Screen.height / 6, title.width, title.height), title);

                        if (timer >= 30)
                        {
                            timer = 0;
                            show = !show;
                        }
                        if (show) GUI.DrawTexture(new Rect(Screen.width / 2 - 120, Screen.height / 2 + Screen.height/6, pressStart.width, pressStart.height), pressStart);
                        
                        if (Input.GetKey(KeyCode.Space)) menuState = MenuState.MAIN;
                    }
                    break;
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
