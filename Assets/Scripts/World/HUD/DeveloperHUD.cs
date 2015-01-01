using UnityEngine;
using System.Collections;

public class DeveloperHUD
{
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


    public void Update(Material mineAtlas, Texture2D developerAtlas)
    {
        // Set the mouse position in the same direction of the textures
        mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        //+ Lateral panel
        // Sun icon
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 92f / 100, Screen.height * 10 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(1 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));
        // Voxels icon
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 92f / 100, Screen.height * 18 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(3 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));
        // Gadgets icon
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 92f / 100, Screen.height * 26 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(4 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));
        // Enemies icon
        GUI.DrawTextureWithTexCoords
            (new Rect(Screen.width * 92f / 100, Screen.height * 34 / 50, lateralButtonSize, lateralButtonSize),
            developerAtlas,
            new Rect(5 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));

        //? Tool Control
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 10 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                    GameFlow.selectedTool = GameFlow.SelectedTool.LIGHT;
                else if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 18 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                    GameFlow.selectedTool = GameFlow.SelectedTool.MINE;
                else if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 26 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                    GameFlow.selectedTool = GameFlow.SelectedTool.INTERACTIVE;
                else if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 34 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                    GameFlow.selectedTool = GameFlow.SelectedTool.ENEMY;
            }
        }

        
        //+ Lower pannel
        switch (GameFlow.selectedTool)
        {
            //+ Light
            case GameFlow.SelectedTool.LIGHT:
                {
                    // Selection
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 10 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));

                    // Tools
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(0 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(1 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 60 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(2 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 70 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(3 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));
                }
                break;
            //+ Mine
            case GameFlow.SelectedTool.MINE:
                {
                    // Selection
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 18 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));

                    // Tools
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(0 / 8f, 4 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(1 / 8f, 4 / 8f, 1 / 8f, 1 / 8f));


                    switch (GameFlow.developerMineTools)
                    {
                        case GameFlow.DeveloperMineTools.SINGLE:
                            {
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                                    developerAtlas,
                                    new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                            }
                            break;
                        case GameFlow.DeveloperMineTools.ORTOEDRIC:
                            {
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize),
                                    developerAtlas,
                                    new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                            }
                            break;
                        default:
                            break;
                    }


                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        // Draw textures
                        GUI.DrawTexture(new Rect(0, Screen.height - atlasLength, atlasLength, atlasLength), mineAtlas.mainTexture);

                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            //? SubTool Control
                            if (ButtonPressed(new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                                GameFlow.developerMineTools = GameFlow.DeveloperMineTools.SINGLE;
                            else if (ButtonPressed(new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, lateralButtonSize, lateralButtonSize), mousePosition))
                                GameFlow.developerMineTools = GameFlow.DeveloperMineTools.ORTOEDRIC;

                            //! Textures Control
                            if (ButtonPressed(new Rect(0, Screen.height - atlasLength, atlasLength, atlasLength), mousePosition))
                                SelectTexture(new Rect(0, Screen.height - atlasLength, atlasLength, atlasLength), mousePosition);
                        }

                        // Draw selected texture
                        GUI.DrawTextureWithTexCoords(new Rect(textureSelection.x, textureSelection.y, atlasLength / 8, atlasLength / 8),
                                                        developerAtlas,
                                                        new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                    }
                }
                break;
            //+ Gadget
            case GameFlow.SelectedTool.INTERACTIVE:
                {
                    // Selection
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 26 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));

                    // Gadgets
                    GUI.DrawTextureWithTexCoords
                        (new Rect(0, Screen.height * 3 / 8, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(0 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.height * 5 / 32, Screen.height * 3 / 8, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(1 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.height * 10 / 32, Screen.height * 3 / 8, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(2 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.height * 15 / 32, Screen.height * 3 / 8, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(3 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(0, Screen.height * 3 / 8 + Screen.height * 5 / 32, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(4 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.height * 5 / 32, Screen.height * 3 / 8 + Screen.height * 5 / 32, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(5 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.height * 10 / 32, Screen.height * 3 / 8 + Screen.height * 5 / 32, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(6 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));

                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.height * 15 / 32, Screen.height * 3 / 8 + Screen.height * 5 / 32, Screen.height * 5 / 32, Screen.height * 5 / 32),
                        developerAtlas,
                        new Rect(7 / 8f, 3 / 8f, 1 / 8f, 1 / 8f));
                }
                break;
            //+ Enemy
            case GameFlow.SelectedTool.ENEMY:
                {
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 34 / 50, lateralButtonSize, lateralButtonSize),
                        developerAtlas,
                        new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                }
                break;
            default:
                break;
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

        if (selectionY == 0)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Sand Way";
        }
        else if (selectionY == 1)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Little Rock";
            else if (selectionX == 1)
                GameFlow.selectedMine = "Large Rock";
            else if (selectionX == 2)
                GameFlow.selectedMine = "Medium Rock";
            else if (selectionX == 3)
                GameFlow.selectedMine = "Medium Broken Rock";
            else if (selectionX == 4)
                GameFlow.selectedMine = "Rock Brick Floor";
            else if (selectionX == 5)
                GameFlow.selectedMine = "Stripped Rock Wall";
            else if (selectionX == 6)
                GameFlow.selectedMine = "Irregular Smooth Rock";
            else if (selectionX == 7)
                GameFlow.selectedMine = "Amethyst Smooth Rock";
        }
        else if (selectionY == 2)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Dark Brown Wood";
            else if (selectionX == 1)
                GameFlow.selectedMine = "Three Wood Column Mine";
            else if (selectionX == 2)
                GameFlow.selectedMine = "Two Wood Column Mine";
            else if (selectionX == 3)
                GameFlow.selectedMine = "Wood base Large Rock";
        }
        else if (selectionY == 3)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Fire large Rock";
            else if (selectionX == 1)
                GameFlow.selectedMine = "Fire Rock Brick Floor";
            else if (selectionX == 2)
                GameFlow.selectedMine = "Fire Irregular Smooth Rock";
            else if (selectionX == 3)
                GameFlow.selectedMine = "Fire Amethyst Smooth Rock";
        }
        else if (selectionY == 4)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Moss Large Rock";
            else if (selectionX == 1)
                GameFlow.selectedMine = "Moss Medium Rock";
        }
        else if (selectionY == 5)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Brown Trunk Column";
            else if (selectionX == 1)
                GameFlow.selectedMine = "Brown Trunk Medium Large Rock";
            else if (selectionX == 2)
                GameFlow.selectedMine = "Brown Trunk Smooth Irregular Rock";
            else if (selectionX == 3)
                GameFlow.selectedMine = "Smooth Rock";
            else if (selectionX == 4)
                GameFlow.selectedMine = "Smooth Rock Column";
            else if (selectionX == 5)
                GameFlow.selectedMine = "Metal Base Smooth Rock";
            else if (selectionX == 6)
                GameFlow.selectedMine = "Metal Base Brown Trunk Column";
        }
        else if (selectionY == 6)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "Two Stone Brick Floor";
            else if (selectionX == 1)
                GameFlow.selectedMine = "Eight Stone Brick Floor";
            else if (selectionX == 2)
                GameFlow.selectedMine = "Hexagonal Stone Brick Floor";
            else if (selectionX == 3)
                GameFlow.selectedMine = "UL Fire Carpet";
            else if (selectionX == 4)
                GameFlow.selectedMine = "UR Fire Carpet";
            else if (selectionX == 5)
                GameFlow.selectedMine = "BL Fire Carpet";
            else if (selectionX == 6)
                GameFlow.selectedMine = "BR Fire Carpet";
        }
        else if (selectionY == 7)
        {
            if (selectionX == 0)
                GameFlow.selectedMine = "C Fire Carpet";
            else if (selectionX == 1)
                GameFlow.selectedMine = "L Fire Carpet";
            else if (selectionX == 2)
                GameFlow.selectedMine = "U Fire Carpet";
            else if (selectionX == 3)
                GameFlow.selectedMine = "R Fire Carpet";
            else if (selectionX == 4)
                GameFlow.selectedMine = "B Fire Carpet";
        }

        textureSelection = new Vector2(selectionX * atlasLength / 8, Screen.height + selectionY * atlasLength / 8 - atlasLength);
    }
}
