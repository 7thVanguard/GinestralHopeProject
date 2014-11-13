using UnityEngine;
using System.Collections;

public static class EGameFlow
{
    // Game Modes
    public enum GeneralMode { PLAYER, DEVELOPER }
    public static GeneralMode generalMode = GeneralMode.DEVELOPER;

    public enum GameMode { COMBAT, CONTRUCTION, DEVCOMBAT, DEVCONSTRUCTION }
    public static GameMode gameMode = GameMode.DEVCONSTRUCTION;


    // Tools
    public enum SelectedTool { TERRAIN, MINE, GADGET, ENEMY }
    public static SelectedTool selectedTool = SelectedTool.MINE;

    public enum DeveloperTerrainTools { VERTEX, MULTIVERTEX }
    public static DeveloperTerrainTools developerTerrainTools = DeveloperTerrainTools.MULTIVERTEX;

    public enum DeveloperMineTools { SINGLE, ORTOEDRIC }
    public static DeveloperMineTools developerMineTools = DeveloperMineTools.SINGLE;


	// Flow
    public static bool pause = false;
    public static bool loading = false;


    // Selection
    public static string selectedGadget = "Wood Pieces";
    public static string selectedTerrain = "Grass";
    public static string selectedMine = "Rock";
    public static string selectedEnemy = "Normal Slime";
}
