﻿using UnityEngine;
using System.Collections;

public class DeveloperHUD
{
    Texture2D atlas;

    private Vector2 mousePosition;
    private Vector2 textureSelection = new Vector2((Screen.height * 5 / 8) / 8, Screen.height * 3 / 8);
    private float lateralButtonSize = Screen.height * 6 / 50;

    private int atlasLength;


    public void Init()
    {
        for (int i = 6; i <= 15; i++)
        {
            if (Mathf.Pow(2, i) > Screen.height)
            {
                atlasLength = (int)Mathf.Pow(2, i - 1);
                break;
            }
        }
    }


    public void Update()
    {
        // Set the mouse position in the same direction of the textures
        mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        
        //+ Lower pannel
        if (GameFlow.selectedTool == GameFlow.SelectedTool.VOXEL)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                // Draw textures
                Global.mainCamera.voxelsObj.SetActive(true);
                //Global.mainCamera.voxelsObj.transform.localEulerAngles = new Vector3(30, Time.time * 100, 0);

                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    //? SubTool Control
                    if (ButtonPressed(new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                        GameFlow.developerVoxelTools = GameFlow.DeveloperVoxelTools.SINGLE;
                    else if (ButtonPressed(new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                        GameFlow.developerVoxelTools = GameFlow.DeveloperVoxelTools.ORTOEDRIC;

                    //! Textures Control
                    if (ButtonPressed(new Rect(0, Screen.height - atlasLength, atlasLength, atlasLength), mousePosition))
                        SelectTexture(new Rect(0, Screen.height - atlasLength, atlasLength, atlasLength), mousePosition);
                }
            }
            else
                Global.mainCamera.voxelsObj.SetActive(false);
        }
    }


    private bool ButtonPressed(Rect rect, Vector2 point)
    {
        if (point.x > rect.x && point.x < rect.x + rect.width && point.y > rect.y && point.y < rect.y + rect.height)
            return true;
        else
            return false;
    }


    private void SelectTexture(Rect rect, Vector2 point)
    {
        int selectionX = (int)(point.x / (rect.width / 8));
        int selectionY = (int)((point.y - rect.y) / ((rect.height) / 8));


        GameFlow.selectedVoxel = "(" + selectionX.ToString() + ", " + (7 - selectionY).ToString() + ")";
    }
}
