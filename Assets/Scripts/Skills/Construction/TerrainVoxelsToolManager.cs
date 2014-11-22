using UnityEngine;
using System.Collections;

public static class TerrainVoxelsToolManager
{
    // Number of the vertex: 0 - backLeft, 1 - backRight, 2 - frontRight, 3 - frontLeft
    private static int voxelVertex;

    // Math variables
    private static int sedimentExcess;
    private static int sedimentPerClick = 3;

    public static void Remove(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
        {
            if (mainCamera.raycast.transform.tag == "Chunk")
            {
                // Remove height to terrain voxels
                switch (voxelVertex)
                {
                    case 0:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.backLeftVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.backRightVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.frontRightVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.frontLeftVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.frontLeftVertex);
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


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
        {
            if (mainCamera.raycast.transform.tag == "Chunk")
            {
                // Add height to terrain voxels
                switch (voxelVertex)
                {
                    case 0:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.backLeftVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.backRightVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.frontRightVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(world, ref DevConstructionSkillsManager.detVoxel.frontLeftVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionSkillsManager.detVoxel.frontLeftVertex);
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


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
        {
            if (mainCamera.raycast.transform.tag == "Chunk")
            {
                float height = 0;

                // Detecting the chunk, voxel and vertex we are aiming at
                DevConstructionSkillsManager.detVertex = new Vector2(Mathf.Round(mainCamera.raycast.point.x), Mathf.Round(mainCamera.raycast.point.z));

                // Detects the vertex we are aiming at and it's height
                if (mainCamera.raycast.point.x < DevConstructionSkillsManager.detVertex.x)
                    if (mainCamera.raycast.point.z < DevConstructionSkillsManager.detVertex.y)
                    {
                        DetectChunkAndVoxel(world, mainCamera, -1, -1);
                        height = DevConstructionSkillsManager.detVoxel.numID.y + DevConstructionSkillsManager.detVoxel.frontRightVertex / world.maxSediment;
                        voxelVertex = 2;
                    }
                    else
                    {
                        DetectChunkAndVoxel(world, mainCamera, -1, 0);
                        height = DevConstructionSkillsManager.detVoxel.numID.y + DevConstructionSkillsManager.detVoxel.backRightVertex / world.maxSediment;
                        voxelVertex = 1;
                    }
                else
                    if (mainCamera.raycast.point.z < DevConstructionSkillsManager.detVertex.y)
                    {
                        DetectChunkAndVoxel(world, mainCamera, 0, -1);
                        height = DevConstructionSkillsManager.detVoxel.numID.y + DevConstructionSkillsManager.detVoxel.frontLeftVertex / world.maxSediment;
                        voxelVertex = 3;
                    }
                    else
                    {
                        DetectChunkAndVoxel(world, mainCamera, 0, 0);
                        height = DevConstructionSkillsManager.detVoxel.numID.y + DevConstructionSkillsManager.detVoxel.backLeftVertex / world.maxSediment;
                        voxelVertex = 0;
                    }

                // Set the sphereMarer to the neares vertex
                HUD.sphereMarker.transform.position = new Vector3(DevConstructionSkillsManager.detVertex.x, height, DevConstructionSkillsManager.detVertex.y);
            }
        }
    }


    private static void DetectChunkAndVoxel(World world, MainCamera mainCamera, int x, int z)
    {
        // Detects the chunk and voxel we are aiming at
        DevConstructionSkillsManager.chunk = world.chunk[(int)Mathf.Round(DevConstructionSkillsManager.detVertex.x + x) / world.chunkSize.x,
                                                   (int)Mathf.Floor(mainCamera.raycast.point.y / world.chunkSize.y),
                                                   (int)Mathf.Round(DevConstructionSkillsManager.detVertex.y + z) / world.chunkSize.z];

        DevConstructionSkillsManager.voxel = DevConstructionSkillsManager.chunk.voxel[(int)Mathf.Round(DevConstructionSkillsManager.detVertex.x + x) % world.chunkSize.x,
                                                                        (int)Mathf.Floor(mainCamera.raycast.point.y % world.chunkSize.y),
                                                                        (int)Mathf.Round(DevConstructionSkillsManager.detVertex.y + z) % world.chunkSize.z];

        DevConstructionSkillsManager.detChunk = DevConstructionSkillsManager.chunk;
        DevConstructionSkillsManager.detVoxel = DevConstructionSkillsManager.voxel;

        // We make sure, we are changing the highest voxel
        while (LVoxel.VoxelExists(world, DevConstructionSkillsManager.detChunk, DevConstructionSkillsManager.detVoxel, 0, 1, 0))
        {
            LVoxel.GetVoxel(world, ref DevConstructionSkillsManager.detChunk, ref DevConstructionSkillsManager.detVoxel, 0, 1, 0);
            if (DevConstructionSkillsManager.detVoxel.entityType != Voxel.EntityType.TERRAIN)
            {
                LVoxel.GetVoxel(world, ref DevConstructionSkillsManager.detChunk, ref DevConstructionSkillsManager.detVoxel, 0, -1, 0);
                break;
            }
        }
        // Detects when all the vertices of the voxel are at max height, but we detect the upper one
        if (LVoxel.VoxelExists(world, DevConstructionSkillsManager.detChunk, DevConstructionSkillsManager.detVoxel, 0, -1, 0))
            if (DevConstructionSkillsManager.detVoxel.entityType != Voxel.EntityType.TERRAIN)
                LVoxel.GetVoxel(world, ref DevConstructionSkillsManager.detChunk, ref DevConstructionSkillsManager.detVoxel, 0, -1, 0);
    }


    private static void Terraform(World world, ref float vertexHeight, int sediment)
    {
        // Adds or removes height from the selected vertex
        vertexHeight += sediment;

        if (vertexHeight < 0)
        {
            // We delete the current voxel and detect the excess of sediment
            world.chunk[DevConstructionSkillsManager.detChunk.numID.x, DevConstructionSkillsManager.detChunk.numID.y, DevConstructionSkillsManager.detChunk.numID.z].voxel[DevConstructionSkillsManager.detVoxel.numID.x, DevConstructionSkillsManager.detVoxel.numID.y, DevConstructionSkillsManager.detVoxel.numID.z]
                    = new Voxel(world, DevConstructionSkillsManager.detVoxel.numID, DevConstructionSkillsManager.detChunk.numID, "Air");
            sedimentExcess = (int)vertexHeight;

            // We get the voxel below for futher terraformation
            if (LVoxel.VoxelExists(world, DevConstructionSkillsManager.detChunk, DevConstructionSkillsManager.detVoxel, 0, -1, 0))
                LVoxel.GetVoxel(world, ref DevConstructionSkillsManager.detChunk, ref DevConstructionSkillsManager.detVoxel, 0, -1, 0);
        }
        else if (vertexHeight > world.maxSediment)
        {
            // We get the voxel above for actual and futher terraformation
            if (LVoxel.VoxelExists(world, DevConstructionSkillsManager.detChunk, DevConstructionSkillsManager.detVoxel, 0, 1, 0))
                LVoxel.GetVoxel(world, ref DevConstructionSkillsManager.detChunk, ref DevConstructionSkillsManager.detVoxel, 0, 1, 0);

            // We place a terrain voxel above and detect the excess of sediment
            world.chunk[DevConstructionSkillsManager.detChunk.numID.x, DevConstructionSkillsManager.detChunk.numID.y, DevConstructionSkillsManager.detChunk.numID.z].voxel[DevConstructionSkillsManager.detVoxel.numID.x, DevConstructionSkillsManager.detVoxel.numID.y, DevConstructionSkillsManager.detVoxel.numID.z]
                    = new Voxel(world, DevConstructionSkillsManager.detVoxel.numID, DevConstructionSkillsManager.detChunk.numID, EGameFlow.selectedTerrain);
            sedimentExcess = (int)vertexHeight;

            LVoxel.GetVoxel(world, ref DevConstructionSkillsManager.detChunk, ref DevConstructionSkillsManager.detVoxel, 0, 0, 0);
        }
    }


    private static void PostTerraform(World world, ref float vertexHeight)
    {
        if (sedimentExcess < 0)
        {
            DevConstructionSkillsManager.detVoxel.backLeftVertex = (int)world.maxSediment;
            DevConstructionSkillsManager.detVoxel.backRightVertex = (int)world.maxSediment;
            DevConstructionSkillsManager.detVoxel.frontLeftVertex = (int)world.maxSediment;
            DevConstructionSkillsManager.detVoxel.frontRightVertex = (int)world.maxSediment;

            vertexHeight = (int)(world.maxSediment + sedimentExcess);

            sedimentExcess = 0;
        }
        else if (sedimentExcess > world.maxSediment)
        {
            DevConstructionSkillsManager.detVoxel.backLeftVertex = 0;
            DevConstructionSkillsManager.detVoxel.backRightVertex = 0;
            DevConstructionSkillsManager.detVoxel.frontLeftVertex = 0;
            DevConstructionSkillsManager.detVoxel.frontRightVertex = 0;

            vertexHeight = (int)(sedimentExcess - world.maxSediment);

            sedimentExcess = 0;
        }
    }
}