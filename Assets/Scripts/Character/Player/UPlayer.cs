using UnityEngine;
using System.Collections;

public class UPlayer : MonoBehaviour
{
	void Start ()
    {
        transform.position = new Vector3(4, 35, 4);
        transform.eulerAngles = Vector3.zero;
        transform.localScale = new Vector3(0.675f, 0.7f, 0.675f);
        SPlayer.transform = transform;
	}
	


	void Update ()
    {
        //// Movement relative
        //if ((!EGameFlow.pause && UWorldGenerator.gameLoaded) || EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        //{
        //    SPlayer.transform = transform;
        //}
	}
}
