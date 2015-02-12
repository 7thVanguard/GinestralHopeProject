using UnityEngine;
using System.Collections;

public class NGGH_TutorialJump : MonoBehaviour 
{
    World world;
    Texture2D tutorial;

    private float framesCounterOnStay = 1;
    private float framesCounter = 0;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        tutorial = (Texture2D)Resources.Load("GUI/Tutorial GUI/GUIJumpTutorial");
    }


    void Update()
    {
        framesCounter = EventsLib.FadeOut(framesCounter);
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                framesCounter = EventsLib.FadeIn(framesCounter, framesCounterOnStay);
    }


    void OnGUI()
    {
        EventsLib.DrawTutorial(tutorial, framesCounter);
    }
}
