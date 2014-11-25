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
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.backLeftVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.backRightVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.frontRightVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.frontLeftVertex, -sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.frontLeftVertex);
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
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.backLeftVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.backRightVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.frontRightVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(world, ref DevConstructionToolsManager.detVoxel.frontLeftVertex, sedimentPerClick);
                            PostTerraform(world, ref DevConstructionToolsManager.detVoxel.frontLeftVertex);
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
                DevConstructionToolsManager.detVertex = new Vector2(Mathf.Round(mainCamera.raycast.point.x), Mathf.Round(mainCamera.raycast.point.z));

                // Detects the vertex we are aiming at and it's height
                if (mainCamera.raycast.point.x < DevConstructionToolsManager.detVertex.x)
                    if (mainCamera.raycast.point.z < DevConstructionToolsManager.detVertex.y)
                    {
                        DetectChunkAndVoxel(world, mainCamera, -1, -1);
                        height = DevConstructionToolsManager.detVoxel.numID.y + DevConstructionToolsManager.detVoxel.frontRightVertex / world.maxSediment;
                        voxelVertex = 2;
                    }
                    else
                    {
                        DetectChunkAndVoxel(world, mainCamera, -1, 0);
                        height = DevConstructionToolsManager.detVoxel.numID.y + DevConstructionToolsManager.detVoxel.backRightVertex / world.maxSediment;
                        voxelVertex = 1;
                    }
                else
                    if (mainCamera.raycast.point.z < DevConstructionToolsManager.detVertex.y)
                    {
                        DetectChunkAndVoxel(world, mainCamera, 0, -1);
                        height = DevConstructionToolsManager.detVoxel.numID.y + DevConstructionToolsManager.detVoxel.frontLeftVertex / world.maxSediment;
                        voxelVertex = 3;
                    }
                    else
                    {
                        DetectChunkAndVoxel(world, mainCamera, 0, 0);
                        height = DevConstructionToolsManager.detVoxel.numID.y + DevConstructionToolsManager.detVoxel.backLeftVertex / world.maxSediment;
                        voxelVertex = 0;
                    }

                // Set the sphereMarer to the neares vertex
                HUD.sphereMarker.transform.position = new Vector3(DevConstructionToolsManager.detVertex.x, height, DevConstructionToolsManager.detVertex.y);
            }
        }
    }


    private static void DetectChunkAndVoxel(World world, MainCamera mainCamera, int x, int z)
    {
        // Detects the chunk and voxel we are aiming at
        DevConstructionToolsManager.chunk = world.chunk[(int)Mathf.Round(DevConstructionToolsManager.detVertex.x + x) / world.chunkSize.x,
                                                   (int)Mathf.Floor(mainCamera.raycast.point.y / world.chunkSize.y),
                                                   (int)Mathf.Round(DevConstructionToolsManager.detVertex.y + z) / world.chunkSize.z];

        DevConstructionToolsManager.voxel = DevConstructionToolsManager.chunk.voxel[(int)Mathf.Round(DevConstructionToolsManager.detVertex.x + x) % world.chunkSize.x,
                                                                        (int)Mathf.Floor(mainCamera.raycast.point.y % world.chunkSize.y),
                                                                        (int)Mathf.Round(DevConstructionToolsManager.detVertex.y + z) % world.chunkSize.z];

        DevConstructionToolsManager.detChunk = DevConstructionToolsManager.chunk;
        DevConstructionToolsManager.detVoxel = DevConstructionToolsManager.voxel;

        // We make sure, we are changing the highest voxel
        while (VoxelLib.VoxelExists(world, DevConstructionToolsManager.detChunk, DevConstructionToolsManager.detVoxel, 0, 1, 0))
        {
            VoxelLib.GetVoxel(world, ref DevConstructionToolsManager.detChunk, ref DevConstructionToolsManager.detVoxel, 0, 1, 0);
            if (DevConstructionToolsManager.detVoxel.entityType != Voxel.EntityType.TERRAIN)
            {
                VoxelLib.GetVoxel(world, ref DevConstructionToolsManager.detChunk, ref DevConstructionToolsManager.detVoxel, 0, -1, 0);
                break;
            }
        }
        // Detects when all the vertices of the voxel are at max height, but we detect the upper one
        if (VoxelLib.VoxelExists(world, DevConstructionToolsManager.detChunk, DevConstructionToolsManager.detVoxel, 0, -1, 0))
            if (DevConstructionToolsManager.detVoxel.entityType != Voxel.EntityType.TERRAIN)
                VoxelLib.GetVoxel(world, ref DevConstructionToolsManager.detChunk, ref DevConstructionToolsManager.detVoxel, 0, -1, 0);
    }


    private static void Terraform(World world, ref float vertexHeight, int sediment)
    {
        // Adds or removes height from the selected vertex
        vertexHeight += sediment;

        if (vertexHeight < 0)
        {
            // We delete the current voxel and detect the excess of sediment
            world.chunk[DevConstructionToolsManager.detChunk.numID.x, DevConstructionToolsManager.detChunk.numID.y, DevConstructionToolsManager.detChunk.numID.z].voxel[DevConstructionToolsManager.detVoxel.numID.x, DevConstructionToolsManager.detVoxel.numID.y, DevConstructionToolsManager.detVoxel.numID.z]
                    = new Voxel(world, DevConstructionToolsManager.detVoxel.numID, DevConstructionToolsManager.detChunk.numID, "Air");
            sedimentExcess = (int)vertexHeight;

            // We get the voxel below for futher terraformation
            if (VoxelLib.VoxelExists(world, DevConstructionToolsManager.detChunk, DevConstructionToolsManager.detVoxel, 0, -1, 0))
                VoxelLib.GetVoxel(world, ref DevConstructionToolsManager.detChunk, ref DevConstructionToolsManager.detVoxel, 0, -1, 0);
        }
        else if (vertexHeight > world.maxSediment)
        {
            // We get the voxel above for actual and futher terraformation
            if (VoxelLib.VoxelExists(world, DevConstructionToolsManager.detChunk, DevConstructionToolsManager.detVoxel, 0, 1, 0))
                VoxelLib.GetVoxel(world, ref DevConstructionToolsManager.detChunk, ref DevConstructionToolsManager.detVoxel, 0, 1, 0);

            // We place a terrain voxel above and detect the excess of sediment
            world.chunk[DevConstructionToolsManager.detChunk.numID.x, DevConstructionToolsManager.detChunk.numID.y, DevConstructionToolsManager.detChunk.numID.z].voxel[DevConstructionToolsManager.detVoxel.numID.x, DevConstructionToolsManager.detVoxel.numID.y, DevConstructionToolsManager.detVoxel.numID.z]
                    = new Voxel(world, DevConstructionToolsManager.detVoxel.numID, DevConstructionToolsManager.detChunk.numID, EGameFlow.selectedTerrain);
            sedimentExcess = (int)vertexHeight;

            VoxelLib.GetVoxel(world, ref DevConstructionToolsManager.detChunk, ref DevConstructionToolsManager.detVoxel, 0, 0, 0);
        }
    }


    private static void PostTerraform(World world, ref float vertexHeight)
    {
        if (sedimentExcess < 0)
        {
            DevConstructionToolsManager.detVoxel.backLeftVertex = (int)world.maxSediment;
            DevConstructionToolsManager.detVoxel.backRightVertex = (int)world.maxSediment;
            DevConstructionToolsManager.detVoxel.frontLeftVertex = (int)world.maxSediment;
            DevConstructionToolsManager.detVoxel.frontRightVertex = (int)world.maxSediment;

            vertexHeight = (int)(world.maxSediment + sedimentExcess);

            sedimentExcess = 0;
        }
        else if (sedimentExcess > world.maxSediment)
        {
            DevConstructionToolsManager.detVoxel.backLeftVertex = 0;
            DevConstructionToolsManager.detVoxel.backRightVertex = 0;
            DevConstructionToolsManager.detVoxel.frontLeftVertex = 0;
            DevConstructionToolsManager.detVoxel.frontRightVertex = 0;

            vertexHeight = (int)(sedimentExcess - world.maxSediment);

            sedimentExcess = 0;
        }
    }
}