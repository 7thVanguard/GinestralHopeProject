using UnityEngine;
using System.Collections;

public static class LTerrainVoxelTool
{
    // Number of the vertex: 0 - backLeft, 1 - backRight, 2 - frontRight, 3 - frontLeft
    private static int voxelVertex;

    // Math variables
    private static int sedimentExcess;
    private static int sedimentPerClick = 3;

    public static void Remove(World world)
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (CameraRaycast.impact.transform.tag == "Chunk")
            {
                // Remove height to terrain voxels
                switch (voxelVertex)
                {
                    case 0:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.backLeftVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.backRightVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.frontRightVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.frontLeftVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.frontLeftVertex);
                        }
                        break;
                    default:
                        break;
                }

                //DevConstructionSkills.detChunk.BuildChunkVertices();
                //DevConstructionSkills.detChunk.BuildChunkMesh();
            }
        }
    }


    public static void Place(World world)
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (CameraRaycast.impact.transform.tag == "Chunk")
            {
                // Add height to terrain voxels
                switch (voxelVertex)
                {
                    case 0:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.backLeftVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.backRightVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.frontRightVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(world, ref DevConstructionSkills.detVoxel.frontLeftVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkills.detVoxel.frontLeftVertex);
                        }
                        break;
                    default:
                        break;
                }

                //DevConstructionSkills.detChunk.BuildChunkVertices();
                //DevConstructionSkills.detChunk.BuildChunkMesh();
            }
        }
    }


    public static void Cancel()
    {

    }


    public static void Detect(World world)
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (CameraRaycast.impact.transform.tag == "Chunk")
            {
                float height = 0;

                // Detecting the chunk, voxel and vertex we are aiming at
                DevConstructionSkills.detVertex = new Vector2(Mathf.Round(CameraRaycast.impact.point.x), Mathf.Round(CameraRaycast.impact.point.z));

                // Detects the vertex we are aiming at and it's height
                if (CameraRaycast.impact.point.x < DevConstructionSkills.detVertex.x)
                    if (CameraRaycast.impact.point.z < DevConstructionSkills.detVertex.y)
                    {
                        DetectChunkAndVoxel(world, -1, -1);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.frontRightVertex / world.maxSediment;
                        voxelVertex = 2;
                    }
                    else
                    {
                        DetectChunkAndVoxel(world, -1, 0);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.backRightVertex / world.maxSediment;
                        voxelVertex = 1;
                    }
                else
                    if (CameraRaycast.impact.point.z < DevConstructionSkills.detVertex.y)
                    {
                        DetectChunkAndVoxel(world, 0, -1);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.frontLeftVertex / world.maxSediment;
                        voxelVertex = 3;
                    }
                    else
                    {
                        DetectChunkAndVoxel(world, 0, 0);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.backLeftVertex / world.maxSediment;
                        voxelVertex = 0;
                    }

                // Set the sphereMarer to the neares vertex
                HUD.sphereMarker.transform.position = new Vector3(DevConstructionSkills.detVertex.x, height, DevConstructionSkills.detVertex.y);
            }
        }
    }


    private static void DetectChunkAndVoxel(World world, int x, int z)
    {
        // Detects the chunk and voxel we are aiming at
        DevConstructionSkills.chunk = world.chunk[(int)Mathf.Round(DevConstructionSkills.detVertex.x + x) / world.chunkSize.x,
                                                   (int)Mathf.Floor(CameraRaycast.impact.point.y / world.chunkSize.y),
                                                   (int)Mathf.Round(DevConstructionSkills.detVertex.y + z) / world.chunkSize.z];

        DevConstructionSkills.voxel = DevConstructionSkills.chunk.voxel[(int)Mathf.Round(DevConstructionSkills.detVertex.x + x) % world.chunkSize.x,
                                                                        (int)Mathf.Floor(CameraRaycast.impact.point.y % world.chunkSize.y),
                                                                        (int)Mathf.Round(DevConstructionSkills.detVertex.y + z) % world.chunkSize.z];

        DevConstructionSkills.detChunk = DevConstructionSkills.chunk;
        DevConstructionSkills.detVoxel = DevConstructionSkills.voxel;

        // We make sure, we are changing the highest voxel
        while (LVoxel.VoxelExists(world, DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, 1, 0))
        {
            LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 1, 0);
            if (DevConstructionSkills.detVoxel.voxelType != VoxelGenerator.VoxelType.VTERRAIN)
            {
                LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);
                break;
            }
        }
        // Detects when all the vertices of the voxel are at max height, but we detect the upper one
        if (LVoxel.VoxelExists(world, DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, -1, 0))
            if (DevConstructionSkills.detVoxel.voxelType != VoxelGenerator.VoxelType.VTERRAIN)
                LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);
    }


    private static void Terraform(World world, ref float vertexHeight, int sediment)
    {
        // Adds or removes height from the selected vertex
        vertexHeight += sediment;

        if (vertexHeight < 0)
        {
            // We delete the current voxel and detect the excess of sediment
            world.chunk[DevConstructionSkills.detChunk.numID.x, DevConstructionSkills.detChunk.numID.y, DevConstructionSkills.detChunk.numID.z].voxel[DevConstructionSkills.detVoxel.numID.x, DevConstructionSkills.detVoxel.numID.y, DevConstructionSkills.detVoxel.numID.z]
                    = new VoxelGenerator(world, DevConstructionSkills.detVoxel.numID, DevConstructionSkills.detChunk.numID, "Air");
            sedimentExcess = (int)vertexHeight;

            // We get the voxel below for futher terraformation
            if (LVoxel.VoxelExists(world, DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, -1, 0))
                LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);
        }
        else if (vertexHeight > world.maxSediment)
        {
            // We get the voxel above for actual and futher terraformation
            if (LVoxel.VoxelExists(world, DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, 1, 0))
                LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 1, 0);

            // We place a terrain voxel above and detect the excess of sediment
            world.chunk[DevConstructionSkills.detChunk.numID.x, DevConstructionSkills.detChunk.numID.y, DevConstructionSkills.detChunk.numID.z].voxel[DevConstructionSkills.detVoxel.numID.x, DevConstructionSkills.detVoxel.numID.y, DevConstructionSkills.detVoxel.numID.z]
                    = new VoxelGenerator(world, DevConstructionSkills.detVoxel.numID, DevConstructionSkills.detChunk.numID, world.selectedTerrain);
            sedimentExcess = (int)vertexHeight;

            LVoxel.GetVoxel(world, ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 0, 0);
        }
    }


    private static void PostTerraform(World world, ref float vertexHeight)
    {
        if (sedimentExcess < 0)
        {
            DevConstructionSkills.detVoxel.backLeftVertex = (int)world.maxSediment;
            DevConstructionSkills.detVoxel.backRightVertex = (int)world.maxSediment;
            DevConstructionSkills.detVoxel.frontLeftVertex = (int)world.maxSediment;
            DevConstructionSkills.detVoxel.frontRightVertex = (int)world.maxSediment;

            vertexHeight = (int)(world.maxSediment + sedimentExcess);

            sedimentExcess = 0;
        }
        else if (sedimentExcess > world.maxSediment)
        {
            DevConstructionSkills.detVoxel.backLeftVertex = 0;
            DevConstructionSkills.detVoxel.backRightVertex = 0;
            DevConstructionSkills.detVoxel.frontLeftVertex = 0;
            DevConstructionSkills.detVoxel.frontRightVertex = 0;

            vertexHeight = (int)(sedimentExcess - world.maxSediment);

            sedimentExcess = 0;
        }
    }
}