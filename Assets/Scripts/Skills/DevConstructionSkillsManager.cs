using UnityEngine;
using System.Collections;

public class DevConstructionSkillsManager
{
    // Detecting variables
    // Base detections
    public static ChunkGenerator chunk;
    public static VoxelGenerator voxel;

    // Auxiliar
    public static ChunkGenerator detChunk;
    public static VoxelGenerator detVoxel;
    public static Vector2 detVertex;

    // Multi selection tools
    public static bool selected = false;

    // Number of the vertex: 0 - backLeft, 1 - backRight, 2 - frontRight, 3 - frontLeft
    private static int voxelVertex;


    // Math variables
    private static int sedimentExcess;
    private static int sedimentPerClick = 3;

    public void Update(World world, Player player, MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Remove(world, player, mainCamera);
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            Place(world, player, mainCamera);
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            Cancel();
        else
            Detect(world, player, mainCamera);
    }


    private void Remove(World world, Player player, MainCamera mainCamera)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Remove(world, player, mainCamera);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Remove(world, player, mainCamera);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Remove(player, mainCamera);
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Remove();
    }


    private void Place(World world, Player player, MainCamera mainCamera)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Place(world, player, mainCamera);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Place(world, player, mainCamera);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Place(world, player, mainCamera);
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
            LEnemyTool.Place(world, player, mainCamera);
    }


    private void Cancel()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Cancel();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Cancel();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Cancel();
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Cancel();
    }


    private void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Detect(world, player, mainCamera);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Detect(world, player, mainCamera);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Detect(world, player, mainCamera);
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
            LEnemyTool.Detect(world, player, mainCamera);
    }
}
