using UnityEngine;
using System.Collections;

public static class GameFlow
{
    // Game in play
    public enum RunningGame { GINESTRAL_HOPE, CLOUDS_SIGHT, PLANNED_DREAM }
    public static RunningGame runningGame = RunningGame.CLOUDS_SIGHT;

    // Game States
    public enum GameState { MENU, GAME }
    public static GameState gameState = GameState.MENU;


    // Game Modes
    public enum GameMode { PLAYER, GODMODE, DEVELOPER }
    public static GameMode gameMode = GameMode.PLAYER;


    // Tools
    public enum SelectedTool { LIGHT, MINE, GEOMETRY, STRUCTURE, INTERACTIVE, ENEMY, EVENT }
    public static SelectedTool selectedTool = SelectedTool.MINE;

    public enum DeveloperTerrainTools { VERTEX, MULTIVERTEX }
    public static DeveloperTerrainTools developerTerrainTools = DeveloperTerrainTools.MULTIVERTEX;

    public enum DeveloperMineTools { SINGLE, ORTOEDRIC }
    public static DeveloperMineTools developerMineTools = DeveloperMineTools.SINGLE;


	// Flow
    public static bool pause = false;
    public static bool onInterface = false;
    public static bool loading = false;


    // Selection
    public static string selectedGeometry = "Wooden Bridge 6m";
    public static string selectedInteractive = "Wooden Plank";
    public static string selectedTerrain = "Grass";
    public static string selectedMine = "Large Rock";
    public static string selectedEnemy = "Normal Slime";
}
