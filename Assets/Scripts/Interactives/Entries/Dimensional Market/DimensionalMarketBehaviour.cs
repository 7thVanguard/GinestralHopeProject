using UnityEngine;
using System.Collections;

public class DimensionalMarketBehaviour : MonoBehaviour 
{
    private GameObject inRadar;
    private GameObject outRadar;


	void Start ()
    {
        inRadar = transform.FindChild("In Radar").gameObject;
        outRadar = transform.FindChild("Out Radar").gameObject;
	}
	


	void Update () 
    {
        if (!GameFlow.pause)
        {
            inRadar.transform.Rotate(new Vector3(0, 30 * Time.deltaTime, 0));
            outRadar.transform.Rotate(new Vector3(0, -120 * Time.deltaTime, 0));
        }


        if (transform.GetComponent<InteractiveComponent>().interacting)
            Interacting();
	}


    public void Interacting()
    {
        GameFlow.onInterface = true;
        GameGUI.dimensionalMarket.SetActive(true);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameFlow.onInterface = false;
            transform.GetComponent<InteractiveComponent>().interacting = false;
            GameGUI.dimensionalMarket.SetActive(false);
        }
    }
}
