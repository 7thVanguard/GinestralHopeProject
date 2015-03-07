using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIGHMainMenu : MonoBehaviour 
{
    GameObject mainMenu;
    GameObject texturePackMenu;

    Texture2D selectedAtlas;

    void Awake()
    {
        GameGUI.GHMainMenu = transform.parent.FindChild("GH Main Menu").gameObject;

        mainMenu = transform.parent.FindChild("GH Main Menu").FindChild("Main Menu").gameObject;
        texturePackMenu = transform.parent.FindChild("GH Main Menu").FindChild("Texture Pack Menu").gameObject;

        selectedAtlas = (Texture2D)Global.G1.mainTexture;

        mainMenu.SetActive(true);
        texturePackMenu.SetActive(false);
    }


    void OnGUI()
    {
        if (texturePackMenu.activeSelf)
            GUI.DrawTexture(new Rect(Screen.width * 3 / 5, 20, Screen.width * 2 / 5 - 20, Screen.width * 2 / 5 - 20), selectedAtlas);
    }

    // New Game
    public void NewGameButton()
    {
        switch (GameFlow.runningGame)
        {
            case GameFlow.RunningGame.GINESTRAL_HOPE:
                {
                    //Global.world.worldObj.GetComponent<GameManager>().gameSerializer.Load(Global.world, Global.player, "NewGameGH");

                    Global.mainCamera.cameraObj.camera.renderingPath = RenderingPath.DeferredLighting;

                    foreach (Transform child in Global.world.worldObj.transform)
                        GameObject.Destroy(child.gameObject);

                    GameObject.Destroy(Global.world.geometryController);
                    GameObject.Destroy(Global.world.eventsController);
                    GameObject.Destroy(Global.world.interactivesController);
                    GameObject.Destroy(Global.world.enemiesController);
                    GameObject.Destroy(Global.world.emitersController);

                    Global.player.playerObj.transform.position = new Vector3(34.5f, 1, 17);
                    Global.player.playerObj.transform.eulerAngles = new Vector3(0, 160, 0);

                }
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


    public void TexturePackButton()
    {
        mainMenu.SetActive(false);
        texturePackMenu.SetActive(true);
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    // Texture Pack
    public void Ginestral1Button()
    {
        GameFlow.selectedAtlas = Global.G1;
        selectedAtlas = (Texture2D)Global.G1.mainTexture;
        ResetWorld();
    }


    public void Planned1Button()
    {
        GameFlow.selectedAtlas = Global.P1;
        selectedAtlas = (Texture2D)Global.P1.mainTexture;
        ResetWorld();
    }


    // General
    public void BackButton()
    {
        mainMenu.SetActive(true);
        texturePackMenu.SetActive(false);
    }


    // Internal
    private void ResetWorld()
    {
        // Destroy existing emiters
        GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
        foreach (GameObject chunkObj in chunks)
            GameObject.Destroy(chunkObj);

        Global.world.Init();
    }


    private void Deactivate()
    {
        GameGUI.GHMainMenu.SetActive(false);
    }
}
