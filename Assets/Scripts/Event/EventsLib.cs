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


    //+ Efects
    public static bool GoAroundPlayer(GameObject obj)
    {
        float distance = Vector3.Distance(obj.transform.position, obj.transform.parent.position + new Vector3(0, 0.5f, 0));

        // Set player as parent of the Orb
        obj.transform.parent = Global.player.playerObj.transform;

        // Rotate around player, incrementing speed while getting near
        obj.transform.RotateAround(obj.transform.parent.position, Vector3.up,
            (200 + (3 - distance) * 175) * Time.deltaTime);


        // Lerp towards player
        obj.transform.position = Vector3.Lerp(obj.transform.position, 
                                  new Vector3(obj.transform.parent.position.x, obj.transform.parent.position.y + 0.5f, obj.transform.position.z),
                                  0.02f + (3 - distance) * 0.012f);

        // Change size depending on the distance to the player
        if (distance < 3)
        {
            obj.transform.FindChild("Ball").GetComponent<ParticleSystem>().startSize =
                            Mathf.Lerp(obj.transform.FindChild("Ball").GetComponent<ParticleSystem>().startSize,
                            obj.transform.FindChild("Ball").GetComponent<ParticleSystem>().startSize * (distance / 3),
                            0.3f);

            obj.transform.FindChild("Trail").GetComponent<ParticleSystem>().startSize =
                            Mathf.Lerp(obj.transform.FindChild("Trail").GetComponent<ParticleSystem>().startSize,
                            obj.transform.FindChild("Trail").GetComponent<ParticleSystem>().startSize * (distance / 3),
                            0.3f);

            if (obj.transform.FindChild("Ball").GetComponent<ParticleSystem>().startSize < 0.35f)
                obj.transform.FindChild("Glow").localScale = Vector3.zero;
        }

        if (Vector3.Distance(obj.transform.position, obj.transform.parent.position + new Vector3(0, 0.5f, 0)) < 0.1f)
        {
            GameObject.Destroy(obj);
            return true;
        }
        else
            return false;
    }
}
