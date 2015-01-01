using UnityEngine;
using System.Collections;

public class ToolsClosetGUI : MonoBehaviour 
{
    GUISkin GHSkin;



    void Start()
    {
        GHSkin = transform.GetComponent<InteractiveComponent>().world.GHSkin;
    }



    void OnGUI()
    {
        if (transform.GetComponent<InteractiveComponent>().interacting)
        {
            GUI.skin = GHSkin;

            GUIStyle interactiveWindowStyle = GUI.skin.GetStyle("interactiveWindow");
            GUI.Window(0, new Rect(50, 50, Screen.width / 3 - 50, Screen.height * 3.5f / 5 - 50), DoInteractiveWindow, "", interactiveWindowStyle);
            GUI.BeginGroup(new Rect(0, 0, 100, 100));
            GUI.EndGroup();
        }
    }


    private void DoInteractiveWindow(int id)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Tool Closet");
        GUILayout.Label("", "Divider");
        GUILayout.BeginHorizontal();
        GUILayout.Label("Item", "PlainText");
        GUILayout.Label("Price", "PlainText");
        GUILayout.Label("", "PlainText");
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
}
