using UnityEngine;
using System.Collections;

public class GUIGHMainMenu : MonoBehaviour 
{
    void Awake()
    {
        GameGUI.GHMainMenu = transform.parent.FindChild("GH Main Menu").gameObject;
    }


    public void NewGameButton()
    {
        switch (GameFlow.runningGame)
        {
            case GameFlow.RunningGame.GINESTRAL_HOPE:
                break;
            case GameFlow.RunningGame.CLOUDS_SIGHT:
                break;
            case GameFlow.RunningGame.PLANNED_DREAM:
                Global.world.worldObj.GetComponent<GameManager>().gameSerializer.Load(Global.world, Global.player, "NewGamePD");
                break;
            default:
                break;
        }
        GameFlow.gameState = GameFlow.GameState.GAME;
        Deactivate();
    }


    public void LoadGAmeButton()
    {
        GameFlow.gameState = GameFlow.GameState.GAME;
        Deactivate();
    }


    public void DeveloperButton()
    {
        GameFlow.gameState = GameFlow.GameState.GAME;
        Deactivate();
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    private void Deactivate()
    {
        GameGUI.GHMainMenu.SetActive(false);
    }
}
