using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GRL_SpawnController : MonoBehaviour 
{
    public List<GameObject> List = new List<GameObject>();

    public bool spawn;


    void Update()
    {

    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                if (spawn)
                    foreach (GameObject gameObject in List)
                        gameObject.SetActive(true);
                else
                    foreach (GameObject gameObject in List)
                        gameObject.SetActive(false);
            }
    }
}
