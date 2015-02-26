using UnityEngine;
using System.Collections;

public class GUIGHPauseMenu : MonoBehaviour
{
    void Awake()
    {
        GameGUI.GHPauseMenu = transform.parent.FindChild("GH Pause Menu").gameObject;
        GameGUI.GHPauseMenu.SetActive(false);
    }


    public void ContinueButton()
    {
        GameFlow.pause = false;
        Deactivate();
    }


    public void MainMenuButton()
    {
        GameFlow.gameState = GameFlow.GameState.MENU;
        GameFlow.pause = false;
        GameGUI.GHPauseMenu.SetActive(false);
        GameGUI.GHMainMenu.SetActive(true);
    }


    private void Deactivate()
    {
        GameGUI.GHPauseMenu.SetActive(false);
    }
}
