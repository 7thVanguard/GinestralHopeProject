using UnityEngine;
using System.Collections;

public static class GameFlow
{
    // Game in play
    public enum RunningGame { GINESTRAL_HOPE, CLOUDS_SIGHT, PLANNED_DREAM }
    public static RunningGame runningGame = RunningGame.GINESTRAL_HOPE;

    // Game States
    public enum GameState { MENU, GAME }
    public static GameState gameState = GameState.MENU;


    // Game Modes
    public enum GameMode { PLAYER, GODMODE, DEVELOPER }
    public static GameMode gameMode = GameMode.PLAYER;


    // Tools
    public enum SelectedTool { LIGHT, VOXEL, GEOMETRY, STRUCTURE, INTERACTIVE, ENEMY, EVENT }
    public static SelectedTool selectedTool = SelectedTool.VOXEL;


    // SubTools
    public enum DeveloperVoxelTools { SINGLE, ORTOEDRIC }
    public static DeveloperVoxelTools developerVoxelTools = DeveloperVoxelTools.SINGLE;

    public enum DeveloperWorldTools { EVENT, CHANGECHUNKSIZE }
    public static DeveloperWorldTools developerWorldTools = DeveloperWorldTools.EVENT;


	// Flow
    public static bool pause = false;
    public static bool onInterface = false;
    public static bool loading = false;


    // Selection
    public static string selectedGeometry = "Wooden Bridge 6m";
    public static string selectedInteractive = "Wooden Plank";
    public static string selectedTerrain = "Grass";
    public static string selectedAtlas = "P1";
    public static string selectedVoxel = "P1(0, 7)";
    public static string selectedEnemy = "Normal Slime";
}
