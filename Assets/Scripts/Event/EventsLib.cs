using UnityEngine;
using System.Collections;

public static class EventsLib
{
    //+ Ambient
    private static Color objectiveColor;
    public static void SetRenderambient(Color color) 
    { 
        objectiveColor = color; 
    }
    public static void UpdateRenderambient()
    {
        RenderSettings.ambientLight = RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, objectiveColor, 0.005f);
    }


    //+ Doors
    private static GameObject door1;
    private static GameObject door2;
    private static Vector3 objectivePosition1;
    private static Vector3 objectivePosition2;
    public static void SetDoorOpenDoubleSlider(GameObject firstDoor, Vector3 firstDoorObjectivePosition, GameObject secondDoor, Vector3 secondDoorObjectivePosition)
    {
        door1 = firstDoor;
        door2 = secondDoor;
        objectivePosition1 = firstDoorObjectivePosition;
        objectivePosition2 = secondDoorObjectivePosition;
    }
    public static void UpdateDoorOpenDoubleSlider()
    {
        door1.transform.position = Vector3.Slerp(door1.transform.position, objectivePosition1, 0.02f);
        door2.transform.position = Vector3.Slerp(door2.transform.position, objectivePosition2, 0.02f);
    }
}
