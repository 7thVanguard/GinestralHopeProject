using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour 
{
    Player player;

    // Developer mode
    private Texture2D developerAtlas;
    private Texture2D developerBox;

    // Atlas
    private Material mineAtlas;

    // gizmos
    public static Texture2D gizmoCircle;
    private Texture2D gizmoCross;
    private Texture2D translucentSelector;

    // Bars
    private Texture2D lifeBar;
    private Texture2D lifeBarBack;

    // GameObjects
    public static GameObject quadMarker;
    public static GameObject cubeMarker;
    public static GameObject sphereMarker;


    // GUI booleans


    // Helpers
    private Vector2 mousePosition;
    private float buttonSize;


    public void Init(Player player, Material mineAtlas, Texture2D developerAtlas, Texture2D developerBox)
    {
        this.player = player;

        this.mineAtlas = mineAtlas;

        this.developerAtlas = developerAtlas;
        this.developerBox = developerBox;

        buttonSize = Screen.height * 6 / 50;
    }


	void Awake () 
    {
        gizmoCross = TextureCreator.CreateCross(gizmoCross);
        gizmoCircle = TextureCreator.CreateCircle(gizmoCircle);

        translucentSelector = TextureCreator.CreatePixel(translucentSelector, new Color(50.0f / 255, 100.0f / 255, 150.0f / 255, 120.0f / 255));    // translucent blue
        lifeBar = TextureCreator.CreatePixel(lifeBar, Color.green);
        lifeBarBack = TextureCreator.CreatePixel(lifeBarBack, Color.red);

        quadMarker = MarkersCreator.CreateQuadMarker(quadMarker, translucentSelector);
        cubeMarker = MarkersCreator.CreateCubeMarker(cubeMarker, translucentSelector);
        sphereMarker = MarkersCreator.CreateSphereMarker(sphereMarker, translucentSelector);
	}
	


	void OnGUI () 
    {
        //+ Gizmos
        GUI.DrawTexture(new Rect(Screen.width / 2 - gizmoCross.width / 2, Screen.height / 2 - gizmoCross.width / 2, gizmoCross.width, gizmoCross.height), gizmoCross);
        
        if (PlayerCombat.target == null)
            GUI.DrawTexture(new Rect(Screen.width / 2 - gizmoCircle.width / 2, Screen.height / 2 - gizmoCircle.width / 2, gizmoCircle.width, gizmoCircle.height), gizmoCircle);
        else
            GUI.DrawTexture(new Rect(PlayerCombat.circleGizmoScreenPos.x - gizmoCircle.width / 2, (Screen.height - PlayerCombat.circleGizmoScreenPos.y) - gizmoCircle.width / 2, gizmoCircle.width, gizmoCircle.height), gizmoCircle);


        //+ Game bars
        // Player Life Bar
        GUI.DrawTexture(new Rect(Screen.width / 8, Screen.height / 1.1f, 200, 20), lifeBarBack);
        GUI.DrawTexture(new Rect(Screen.width / 8, Screen.height / 1.1f, 200 * player.currentLife / player.maxLife, 20), lifeBar);

        // Enemy life bar
        if (PlayerCombat.target != null)
        {
            GUI.DrawTexture(new Rect(Screen.width * 7 / 8, Screen.height / 2, Screen.width * 0.9f / 8, 15), lifeBarBack);
            GUI.DrawTexture(new Rect(Screen.width * 7 / 8, Screen.height / 2,
                (Screen.width * 0.9f / 8) * (PlayerCombat.target.GetComponent<EnemyComponent>().life / PlayerCombat.target.GetComponent<EnemyComponent>().maxLife), 15), lifeBar);
        }


        //+ Skills casting
        if (CombatToolsManager.casting)
        {
            GUI.DrawTexture(new Rect(Screen.width * 3 / 8 - 3, Screen.height * 4 / 5 - 10, Screen.width * 2 / 8 + 6, 20), lifeBarBack);
            GUI.DrawTexture(new Rect(Screen.width * 3 / 8, Screen.height * 4 / 5 - 7,
                (Screen.width * 2 / 8) * (CombatToolsManager.actualCastingTime / CombatToolsManager.totalCastingTime), 14), lifeBar);
        }

        // Set the mouse position in the same direction of the textures
        mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        switch (EGameFlow.gameMode)
        {
            //++ Player HUD
            case EGameFlow.GameMode.PLAYER:
                break;
            //++ GodMode HUD
            case EGameFlow.GameMode.GODMODE:
                break;
            //++ Developer HUD
            case EGameFlow.GameMode.DEVELOPER:
                {
                    //+ Lateral panel
                    // Sun icon
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 10 / 50, buttonSize, buttonSize),
                        developerAtlas,
                        new Rect(1 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));
                    // Voxels icon
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 18 / 50, buttonSize, buttonSize),
                        developerAtlas,
                        new Rect(3 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));
                    // Gadgets icon
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 26 / 50, buttonSize, buttonSize),
                        developerAtlas,
                        new Rect(4 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));
                    // Enemies icon
                    GUI.DrawTextureWithTexCoords
                        (new Rect(Screen.width * 92f / 100, Screen.height * 34 / 50, buttonSize, buttonSize),
                        developerAtlas,
                        new Rect(5 / 8f, 7 / 8f, 1 / 8f, 1 / 8f));

                    //? Tool Control
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 10 / 50, buttonSize, buttonSize), mousePosition))
                                EGameFlow.selectedTool = EGameFlow.SelectedTool.LIGHT;
                            else if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 18 / 50, buttonSize, buttonSize), mousePosition))
                                EGameFlow.selectedTool = EGameFlow.SelectedTool.MINE;
                            else if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 26 / 50, buttonSize, buttonSize), mousePosition))
                                EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;
                            else if (ButtonPressed(new Rect(Screen.width * 92f / 100, Screen.height * 34 / 50, buttonSize, buttonSize), mousePosition))
                                EGameFlow.selectedTool = EGameFlow.SelectedTool.ENEMY;
                        }
                    }


                    //+ Lower pannel
                    switch (EGameFlow.selectedTool)
                    {
                        //+ Light
                        case EGameFlow.SelectedTool.LIGHT:
                            {
                                // Selection
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 92f / 100, Screen.height * 10 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));

                                // Tools
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(0 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));

                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(1 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));

                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 60 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(2 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));

                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 70 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(3 / 8f, 6 / 8f, 1 / 8f, 1 / 8f));
                            }
                            break;
                        //+ Mine
                        case EGameFlow.SelectedTool.MINE:
                            {
                                // Selection
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 92f / 100, Screen.height * 18 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));

                                // Tools
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(0 / 8f, 4 / 8f, 1 / 8f, 1 / 8f));

                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(1 / 8f, 4 / 8f, 1 / 8f, 1 / 8f));


                                switch (EGameFlow.developerMineTools)
                                {
                                    case EGameFlow.DeveloperMineTools.SINGLE:
                                        {
                                            GUI.DrawTextureWithTexCoords
                                                (new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
                                                developerAtlas,
                                                new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                                        }
                                        break;
                                    case EGameFlow.DeveloperMineTools.ORTOEDRIC:
                                        {
                                            GUI.DrawTextureWithTexCoords
                                                (new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, buttonSize, buttonSize),
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
                                    GUI.DrawTexture(new Rect(0, Screen.height * 3 / 8, Screen.height * 5 / 8, Screen.height * 5 / 8), mineAtlas.mainTexture);

                                    if (Input.GetKeyUp(KeyCode.Mouse0))
                                    {
                                        //? SubTool Control
                                        if (ButtonPressed(new Rect(Screen.width * 40 / 100, Screen.height * 42 / 50, buttonSize, buttonSize), mousePosition))
                                            EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.SINGLE;
                                        else if (ButtonPressed(new Rect(Screen.width * 50 / 100, Screen.height * 42 / 50, buttonSize, buttonSize), mousePosition))
                                            EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.ORTOEDRIC;

                                        //! Textures Control
                                        if (ButtonPressed(new Rect(0, Screen.height * 3 / 8, Screen.height * 5 / 8, Screen.height * 5 / 8), mousePosition))
                                            SelectTexture(new Rect(0, Screen.height * 3 / 8, Screen.height * 5 / 8, Screen.height * 5 / 8), mousePosition);
                                    }
                                }
                            }
                            break;
                        //+ Gadget
                        case EGameFlow.SelectedTool.GADGET:
                            {
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 92f / 100, Screen.height * 26 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                            }
                            break;
                        //+ Enemy
                        case EGameFlow.SelectedTool.ENEMY:
                            {
                                GUI.DrawTextureWithTexCoords
                                    (new Rect(Screen.width * 92f / 100, Screen.height * 34 / 50, buttonSize, buttonSize),
                                    developerAtlas,
                                    new Rect(7 / 8f, 0 / 8f, 1 / 8f, 1 / 8f));
                            }
                            break;
                        default:
                            break;
                    }
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
                EGameFlow.selectedMine = "Sand Way";
        }
        else if (selectionY == 1)
        {
            if (selectionX == 0)
                EGameFlow.selectedMine = "Little Rock";
            else if (selectionX == 1)
                EGameFlow.selectedMine = "Large Rock";
            else if (selectionX == 2)
                EGameFlow.selectedMine = "Medium Rock";
            else if (selectionX == 3)
                EGameFlow.selectedMine = "Medium Broken Rock";
            else if (selectionX == 4)
                EGameFlow.selectedMine = "Rock Brick Floor";
            else if (selectionX == 5)
                EGameFlow.selectedMine = "Stripped Rock Wall";
            else if (selectionX == 6)
                EGameFlow.selectedMine = "Irregular Smooth Rock";
            else if (selectionX == 7)
                EGameFlow.selectedMine = "Amethyst Smooth Rock";
        }
        else if (selectionY == 2)
        {
            if (selectionX == 0)
                EGameFlow.selectedMine = "Dark Brown Wood";
            else if (selectionX == 1)
                EGameFlow.selectedMine = "Three Wood Column Mine";
            else if (selectionX == 2)
                EGameFlow.selectedMine = "Two Wood Column Mine";
            else if (selectionX == 3)
                EGameFlow.selectedMine = "Wood base Large Rock";
        }
        else if (selectionY == 3)
        {
            if (selectionX == 0)
                EGameFlow.selectedMine = "Fire large Rock";
            else if (selectionX == 1)
                EGameFlow.selectedMine = "Fire Rock Brick Floor";
            else if (selectionX == 2)
                EGameFlow.selectedMine = "Fire Irregular Smooth Rock";
            else if (selectionX == 3)
                EGameFlow.selectedMine = "Fire Amethyst Smooth Rock";
        }
        else if (selectionY == 4)
        {
            if (selectionX == 0)
                EGameFlow.selectedMine = "Moss Large Rock";
            else if (selectionX == 1)
                EGameFlow.selectedMine = "Moss Medium Rock";
        }
		else if (selectionY == 5)
		{
			if (selectionX == 0)
				EGameFlow.selectedMine = "Brown Trunk Column";
			else if (selectionX == 1)
				EGameFlow.selectedMine = "Brown Trunk Medium Large Rock";
			else if (selectionX == 2)
				EGameFlow.selectedMine = "Brown Trunk Smooth Irregular Rock";
			else if (selectionX == 3)
				EGameFlow.selectedMine = "Smooth Rock";
			else if (selectionX == 4)
				EGameFlow.selectedMine = "Smooth Rock Column";
			else if (selectionX == 5)
				EGameFlow.selectedMine = "Metal Base Smooth Rock";
			else if (selectionX == 6)
				EGameFlow.selectedMine = "Metal Base Brown Trunk Column";
		}
		else if (selectionY == 6)
		{
			if (selectionX == 0)
				EGameFlow.selectedMine = "Two Stone Brick Floor";
			else if (selectionX == 1)
				EGameFlow.selectedMine = "Eight Stone Brick Floor";
			else if (selectionX == 2)
				EGameFlow.selectedMine = "Hexagonal Stone Brick Floor";
			else if (selectionX == 3)
				EGameFlow.selectedMine = "UL Fire Carpet";
			else if (selectionX == 4)
				EGameFlow.selectedMine = "UR Fire Carpet";
			else if (selectionX == 5)
				EGameFlow.selectedMine = "BL Fire Carpet";
			else if (selectionX == 6)
				EGameFlow.selectedMine = "BR Fire Carpet";
		}
		else if (selectionY == 7)
		{
			if (selectionX == 0)
				EGameFlow.selectedMine = "C Fire Carpet";
			else if (selectionX == 1)
				EGameFlow.selectedMine = "L Fire Carpet";
			else if (selectionX == 2)
				EGameFlow.selectedMine = "U Fire Carpet";
			else if (selectionX == 3)
				EGameFlow.selectedMine = "R Fire Carpet";
			else if (selectionX == 4)
				EGameFlow.selectedMine = "B Fire Carpet";
		}
    }
}
