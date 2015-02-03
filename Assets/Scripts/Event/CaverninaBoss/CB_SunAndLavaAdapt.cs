using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CB_SunAndLavaAdapt : MonoBehaviour 
{
    List<GameObject> lava = new List<GameObject>();

    void Start()
    {
        Global.sun.sunObj.GetComponent<LightSystemBehaviour>().facePlayer = true;

        RaycastHit impact;

        if (Physics.Raycast(new Vector3(10, 50, 10), new Vector3(0, -10, 0), out impact, 60))
        {
            lava.Add(impact.transform.gameObject);
            impact.transform.position = new Vector3(0, 1.5f, 0);
        }
        if (Physics.Raycast(new Vector3(30, 50, 10), new Vector3(0, -10, 0), out impact, 60))
        {
            lava.Add(impact.transform.gameObject);
            impact.transform.position = new Vector3(20, 1.5f, 0);
        }
        if (Physics.Raycast(new Vector3(10, 50, 30), new Vector3(0, -10, 0), out impact, 60))
        {
            lava.Add(impact.transform.gameObject);
            impact.transform.position = new Vector3(0, 1.5f, 20);
        }
        if (Physics.Raycast(new Vector3(30, 50, 30), new Vector3(0, -10, 0), out impact, 60))
        {
            lava.Add(impact.transform.gameObject);
            impact.transform.position = new Vector3(20, 1.5f, 20);
        }
    }


    void Update()
    {
        Global.sun.sunObj.transform.position = new Vector3(20, Global.player.playerObj.transform.position.y + 20, 20);

        foreach (GameObject lavaSurface in lava)
            lavaSurface.transform.position += new Vector3(0, Time.deltaTime, 0) / 4.5f;
    }
}
