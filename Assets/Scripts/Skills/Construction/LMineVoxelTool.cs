using UnityEngine;
using System.Collections;

public class LMineVoxelTool
{
    // Selected voxel in a multi selection tool
    private static ChunkGenerator preDetChunk;
    private static VoxelGenerator preDetVoxel;


    public static void Remove(World world)
    {
        // Single
        if (EGameFlow.developerMineTools == EGameFlow.DeveloperMineTools.SINGLE)
        {
            if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
            {
                if (CameraRaycast.impact.transform.tag == "Chunk")
                {
                    DevConstructionSkills.detChunk = DevConstructionSkills.chunk;
                    DevConstructionSkills.detVoxel = DevConstructionSkills.voxel;

                    // Destroy the selected voxel
                    world.chunk[DevConstructionSkills.detChunk.numID.x, DevConstructionSkills.detChunk.numID.y, DevConstructionSkills.detChunk.numID.z]
                        .voxel[DevConstructionSkills.detVoxel.numID.x, DevConstructionSkills.detVoxel.numID.y, DevConstructionSkills.detVoxel.numID.z]
                        = new VoxelGenerator(world, DevConstructionSkills.detVoxel.numID, DevConstructionSkills.detChunk.numID, "Air");

                    // Reset
                    LChunk.Reset(world, DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel);
                }
            }
        }
        // Multi selection
        else
        {
            // Check if this voxel is the first selection or the second one in multi selection tools
            if (!DevConstructionSkills.selected)
            {
                // Set the first detected voxel
                preDetChunk = DevConstructionSkills.chunk;
                preDetVoxel = DevConstructionSkills.voxel;

                // Begind the fase 2 of multi selection tools
                DevConstructionSkills.selected = true;
            }
            else
            {
                // Ortoedric
                if (EGameFlow.developerMineTools == EGameFlow.DeveloperMineTools.ORTOEDRIC)
                {
                    if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
                    {
                        DevConstructionSkills.detChunk = DevConstructionSkills.chunk;
                        DevConstructionSkills.detVoxel = DevConstructionSkills.voxel;

                        // Places the selectet voxel in the selected ones
                        OrtoedricResolution(world, "Air");

                        // End of fase 2 of multi selection tool
                        DevConstructionSkills.selected = false;
                    }
                }
            }
        }
    }


    public static void Place(World world)
    {
        // Single
        if (EGameFlow.developerMineTools == EGameFlow.DeveloperMineTools.SINGLE)
        {
            if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
            {
                if (CameraRaycast.impact.transform.tag == "Chunk")
                {
                    DevConstructionSkills.detChunk = DevConstructionSkills.chunk;
                    DevConstructionSkills.detVoxel = DevConstructionSkills.voxel;

                    // Detect the face impacted by the ray, and and place the block in front of that face
                    if (CameraRaycast.impact.normal.x > 0.75f)
                        LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 1, 0, 0);
                    else if (CameraRaycast.impact.normal.x < -0.75f)
                        LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, -1, 0, 0);

                    else if (CameraRaycast.impact.normal.y > 0.75f)
                        LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 1, 0);
                    else if (CameraRaycast.impact.normal.y < -0.75f)
                        LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);

                    else if (CameraRaycast.impact.normal.z > 0.75f)
                        LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 0, 1);
                    else if (CameraRaycast.impact.normal.z < -0.75f)
                        LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 0, -1);

                    world.chunk[DevConstructionSkills.detChunk.numID.x, DevConstructionSkills.detChunk.numID.y, DevConstructionSkills.detChunk.numID.z]
                        .voxel[DevConstructionSkills.detVoxel.numID.x, DevConstructionSkills.detVoxel.numID.y, DevConstructionSkills.detVoxel.numID.z]
                        = new VoxelGenerator(world, DevConstructionSkills.detVoxel.numID, DevConstructionSkills.detChunk.numID, world.selectedMine);

                    // Reset
                    LChunk.Reset(world, DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel);
                }
            }
        }
        // Multi selection
        else
        {
            // Check if this voxel is the first selection or the second one in multi selection tools
            if (!DevConstructionSkills.selected)
            {
                // Set the first detected voxel
                preDetChunk = DevConstructionSkills.chunk;
                preDetVoxel = DevConstructionSkills.voxel;

                // Begind the fase 2 of multi selection tools
                DevConstructionSkills.selected = true;
            }
            else
            {
                // Ortoedric
                if (EGameFlow.developerMineTools == EGameFlow.DeveloperMineTools.ORTOEDRIC)
                {
                    if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
                    {
                        DevConstructionSkills.detChunk = DevConstructionSkills.chunk;
                        DevConstructionSkills.detVoxel = DevConstructionSkills.voxel;

                        // Places the selectet voxel in the selected ones
                        OrtoedricResolution(world, world.selectedMine);

                        // End of fase 2 of multi selection tool
                        DevConstructionSkills.selected = false;
                    }
                }
            }
        }
    }


    public static void Cancel()
    {
        DevConstructionSkills.selected = false;
    }


    public static void Detect(World world)
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (CameraRaycast.impact.transform.tag == "Chunk")
            {
                float voxelDisplacementX = 0, voxelDisplacementY = 0, voxelDisplacementZ = 0;

                // Controls when we are aiming at the limit of a voxel, we make sure to detect that voxel and not the next one
                if (CameraRaycast.impact.normal.x > 0.75f)
                    voxelDisplacementX = 0.25f;
                else if (CameraRaycast.impact.normal.y > 0.75f)
                    voxelDisplacementY = 0.25f;
                else if (CameraRaycast.impact.normal.z > 0.75f)
                    voxelDisplacementZ = 0.25f;

                // Detects the vertex we are aiming at
                DevConstructionSkills.chunk = world.chunk[(int)((CameraRaycast.impact.point.x - voxelDisplacementX) / world.chunkSize.x),
                                                           (int)((CameraRaycast.impact.point.y - voxelDisplacementY) / world.chunkSize.y),
                                                           (int)((CameraRaycast.impact.point.z - voxelDisplacementZ) / world.chunkSize.z)];

                DevConstructionSkills.voxel = DevConstructionSkills.chunk.voxel[(int)((CameraRaycast.impact.point.x - voxelDisplacementX) % world.chunkSize.x),
                                                                                (int)((CameraRaycast.impact.point.y - voxelDisplacementY) % world.chunkSize.y),
                                                                                (int)((CameraRaycast.impact.point.z - voxelDisplacementZ) % world.chunkSize.z)];
            }
        }
    }


    private static void OrtoedricResolution(World world, string voxelName)
    {
        // Theese variables will store the chunks we will need to reset
        int chunkInitX, chunkInitY, chunkInitZ;
        int chunkEndX, chunkEndY, chunkEndZ;

        // Theese variables will store the voxels we will need to reset
        int initX, initY, initZ;
        int endX, endY, endZ;

        // Theese variables are used in the for loop, will decide if increment or decrement the variables in the loop
        int xSign, ySign, zSign;


        // Detect where the selection begins and where it ends
        initX = preDetChunk.numID.x * world.chunkSize.x + preDetVoxel.numID.x;
        endX = DevConstructionSkills.detChunk.numID.x * world.chunkSize.x + DevConstructionSkills.detVoxel.numID.x;

        if (initX <= endX)
        {
            xSign = 1;
            chunkInitX = initX / world.chunkSize.x;
            chunkEndX = endX / world.chunkSize.x;
        }
        else
        {
            xSign = -1;
            chunkInitX = endX / world.chunkSize.x;
            chunkEndX = initX / world.chunkSize.x;
        }

        initY = preDetChunk.numID.y * world.chunkSize.y + preDetVoxel.numID.y;
        endY = DevConstructionSkills.detChunk.numID.y * world.chunkSize.y + DevConstructionSkills.detVoxel.numID.y;

        if (initY <= endY)
        {
            ySign = 1;
            chunkInitY = initY / world.chunkSize.y;
            chunkEndY = endY / world.chunkSize.y;
        }
        else
        {
            ySign = -1;
            chunkInitY = endY / world.chunkSize.y;
            chunkEndY = initY / world.chunkSize.y;
        }

        initZ = preDetChunk.numID.z * world.chunkSize.z + preDetVoxel.numID.z;
        endZ = DevConstructionSkills.detChunk.numID.z * world.chunkSize.z + DevConstructionSkills.detVoxel.numID.z;

        if (initZ <= endZ)
        {
            zSign = 1;
            chunkInitZ = initZ / world.chunkSize.z;
            chunkEndZ = endZ / world.chunkSize.z;
        }
        else
        {
            zSign = -1;
            chunkInitZ = endZ / world.chunkSize.z;
            chunkEndZ = initZ / world.chunkSize.z;
        }

        
        // Modify all selected chunks
        for (int x = initX; x != endX + xSign; x += xSign)
            for (int y = initY; y != endY + ySign; y += ySign)
                for (int z = initZ; z != endZ + zSign; z += zSign)
                {
                    // Creates the voxels
                    world.chunk[x / world.chunkSize.x, y / world.chunkSize.y, z / world.chunkSize.z]
                          .voxel[x % world.chunkSize.x, y % world.chunkSize.y, z % world.chunkSize.z]
                        = new VoxelGenerator(world, new IntVector3(x % world.chunkSize.x, y % world.chunkSize.y, z % world.chunkSize.z),
                                    new IntVector3(x / world.chunkSize.x, y / world.chunkSize.y, z / world.chunkSize.z),
                                    voxelName);
                }

        // Reseting all chunks
        for (int x = chunkInitX; x <= chunkEndX; x++)
            for (int y = chunkInitY; y <= chunkEndY; y++)
                for (int z = chunkInitX; z <= chunkEndZ; z++)
                {
                    world.chunksToReset.Add(new IntVector3(x, y, z));
                }
    }
}
