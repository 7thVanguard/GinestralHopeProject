using UnityEngine;
using System.Collections;

public class NGGH_EndLevel : MonoBehaviour 
{
    private Texture2D sevenV;
    private Texture2D blackSpace;

    private float alphaCounterBlackScreen = 0;
    private float alphaCounter7V = 0;
    private bool active = false;
    private bool inTrigger = false;


    void Start()
    {
        sevenV = (Texture2D)Resources.Load("GUI/Ginestral Hope GUI/7V");
        blackSpace = (Texture2D)Resources.Load("GUI/Ginestral Hope GUI/BlackScreen");
    }


    void Update()
    {
        if (active)
        {
            if (alphaCounterBlackScreen < 255)
                alphaCounterBlackScreen += 50 * Time.deltaTime;

            if (alphaCounterBlackScreen > 255)
                alphaCounterBlackScreen = 255;

            if (alphaCounterBlackScreen >= 254)
            {
                if (alphaCounter7V < 255)
                    alphaCounter7V += 50 * Time.deltaTime;

                if (alphaCounter7V > 255)
                    alphaCounter7V = 255;
            }
        }
    }


    void OnGUI()
    {
        if (active)
        {
            GUI.color = new Color32(0, 0, 0, (byte)alphaCounterBlackScreen);
            GUI.DrawTextureWithTexCoords(new Rect(0, 0, Screen.width, Screen.height), blackSpace, new Rect(0, 0, 1, 1));

            GUI.color = new Color32(255, 255, 255, (byte)alphaCounter7V);
            GUI.DrawTextureWithTexCoords(new Rect(Screen.width / 4, Screen.height / 3, Screen.width / 2, Screen.height / 6), sevenV, new Rect(0, 0, 1, 1));
        }
        else
        {
            if (inTrigger)
                EventsLib.DrawInteractivity();
        }
    }


	void OnTriggerStay (Collider other)
    {
        inTrigger = true;

        if (Input.GetKeyDown(KeyCode.E))
            if (other.tag == "Player")
                active = true;
	}


    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}
