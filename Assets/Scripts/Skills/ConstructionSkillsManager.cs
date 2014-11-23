using UnityEngine;
using System.Collections;

public class ConstructionSkillsManager
{
    // Detecting variables
    // Base detections
    public static ChunkGenerator chunk;
    public static Voxel voxel;

    // Auxiliar
    public static ChunkGenerator detChunk;
    public static Voxel detVoxel;
    public static Vector2 detVertex;


    public void Update(World world, Player player, MainCamera mainCamera)
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Remove(player, mainCamera);
            else if (Input.GetKeyDown(KeyCode.Mouse1))
                Place(world, player, mainCamera);
            else if (Input.GetKeyDown(KeyCode.Mouse2))
                Cancel();
            else
                Detect(world, player, mainCamera);
        }
    }


    private void Remove(Player player, MainCamera mainCamera)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            GadgetsToolManager.Remove(player, mainCamera);
    }


    private void Place(World world, Player player, MainCamera mainCamera)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            GadgetsToolManager.Place(world, player, mainCamera);
    }


    private void Cancel()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            GadgetsToolManager.Cancel();
    }


    private void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            GadgetsToolManager.Detect(world, player, mainCamera);
    }
}
