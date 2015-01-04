using UnityEngine;
using System.Collections;

public class GUIDimensionalMarket : MonoBehaviour 
{
    void Awake()
    {
        GameGUI.dimensionalMarket = transform.parent.FindChild("Dimensional Market").gameObject;
        GameGUI.dimensionalMarket.SetActive(false);
    }


    public void WorkbenchPurchase()
    {
        InventoryLib.AddToInventory("Workbench", "Interactive");
    }


    public void ToolsClosetPurchase()
    {
        InventoryLib.AddToInventory("Tools Closet", "Interactive");
    }
}
