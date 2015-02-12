using UnityEngine;
using System.Collections;

public class NGGH_TutorialCamera : MonoBehaviour 
{
    World world;
    Texture2D tutorial;

    private bool active;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        tutorial = (Texture2D)Resources.Load("GUI/Tutorial GUI/GUICameraTutorial");
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                active = true;
    }


    void OnTriggerExit(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                active = false;
    }


    void OnGUI()
    {
        if (active && !GameFlow.pause && GameFlow.gameState == GameFlow.GameState.GAME)
            GUI.DrawTextureWithTexCoords(new Rect(6 * Screen.width / 10, Screen.height / 6, 2.5f * Screen.width / 10, (2.5f * Screen.width / 10) * 1.4f),
                tutorial, new Rect(0, 0, 1, 1));
    }
}
