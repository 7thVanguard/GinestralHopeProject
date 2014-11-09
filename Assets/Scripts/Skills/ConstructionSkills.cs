using UnityEngine;
using System.Collections;

public class ConstructionSkills
{
    // Detecting variables
    // Base detections
    public static ChunkGenerator chunk;
    public static VoxelGenerator voxel;

    // Auxiliar
    public static ChunkGenerator detChunk;
    public static VoxelGenerator detVoxel;
    public static Vector2 detVertex;


    public void Update(World world, Player player)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Remove(player);
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            Place(world, player);
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            Cancel();
        else
            Detect(world, player);
    }


    private void Remove(Player player)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Remove(player);
    }


    private void Place(World world, Player player)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Place(world, player);
    }


    private void Cancel()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Cancel();
    }


    private void Detect(World world, Player player)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Detect(world, player);
    }
}
