using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Geometry
{
    public enum PlacedOn { FLOOR, WALL, AIR }

    protected World world;
    protected Player player;
    protected MainCamera mainCamera;


    public static void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale)
    {
        GameObject geometryObj = new GameObject();
        geometryObj.name = ID;
        geometryObj.tag = "Geometry";
        geometryObj.transform.position = pos;
        geometryObj.transform.eulerAngles = rot;
        geometryObj.transform.localScale = scale;
        geometryObj.transform.parent = Global.world.geometryController.transform;
        geometryObj.AddComponent<GeometryComponent>();
    }
}
