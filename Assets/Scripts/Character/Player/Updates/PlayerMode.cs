using UnityEngine;
using System.Collections;

public class PlayerMode
{
	public void Update () 
    {
        // Game mode
        if (Input.GetKey(KeyCode.F1))
        {
            EGameFlow.gameMode = EGameFlow.GameMode.COMBAT;
            EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
            SPlayer.constructionDetection = 5;
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            EGameFlow.gameMode = EGameFlow.GameMode.CONTRUCTION;
            EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
            SPlayer.constructionDetection = 5;
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            EGameFlow.gameMode = EGameFlow.GameMode.DEVCOMBAT;
            EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
            SPlayer.constructionDetection = 300;
        }
        else if (Input.GetKey(KeyCode.F4))
        {
            EGameFlow.gameMode = EGameFlow.GameMode.DEVCONSTRUCTION;
            EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
            SPlayer.constructionDetection = 300;
        }


        // Tool
        if (Input.GetKey(KeyCode.Alpha1))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.TERRAIN;
        else if (Input.GetKey(KeyCode.Alpha2))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.MINE;
        else if (Input.GetKey(KeyCode.Alpha3))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;
		else if (Input.GetKey(KeyCode.Alpha4))
			EGameFlow.selectedTool = EGameFlow.SelectedTool.ENEMY;

        // SubTool
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
        {
            
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.SINGLE;
            else if (Input.GetKey(KeyCode.DownArrow))
                EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.ORTOEDRIC;
        }


        // Texture selection / Gadget selection
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN) 
		{
			if (Input.GetKey (KeyCode.I))
				SWorld.selectedTerrain = "Grass";
			else if (Input.GetKey (KeyCode.J))
				SWorld.selectedTerrain = "DirtGrass";
		} 
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE) 
		{
			if (Input.GetKey (KeyCode.I))
				SWorld.selectedMine = "Rock";
			else if (Input.GetKey (KeyCode.J))
				SWorld.selectedMine = "BreakRock";
			else if (Input.GetKey (KeyCode.K))
				SWorld.selectedMine = "Wood";
		} 
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET) 
		{
			if (Input.GetKey (KeyCode.I))
				EGameFlow.selectedGadget = EGameFlow.SelectedGadget.PLANK;
			else if (Input.GetKey (KeyCode.J))
				EGameFlow.selectedGadget = EGameFlow.SelectedGadget.WOOD;
			else if (Input.GetKey (KeyCode.K))
				EGameFlow.selectedGadget = EGameFlow.SelectedGadget.NAILS;
		}
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY) 
		{
			if (Input.GetKey (KeyCode.I))
				EGameFlow.selectedEnemy = EGameFlow.SelectedEnemy.NORMALSLIME;
		}
	}
}
