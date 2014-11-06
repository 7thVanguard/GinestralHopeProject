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


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Remove();
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            Place();
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            Cancel();
        else
            Detect();
    }


    private void Remove()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Remove();
    }


    private void Place()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Place();
    }


    private void Cancel()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Cancel();
    }


    private void Detect()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Detect();
    }
}
