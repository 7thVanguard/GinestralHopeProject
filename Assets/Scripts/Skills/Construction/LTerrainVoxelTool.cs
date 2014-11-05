using UnityEngine;
using System.Collections;

public static class LTerrainVoxelTool
{
    private static RaycastHit impact;

    // Number of the vertex: 0 - backLeft, 1 - backRight, 2 - frontRight, 3 - frontLeft
    private static int voxelVertex;

    // Math variables
    private static int sedimentExcess;
    private static int sedimentPerClick = 3;

    public static void Remove()
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (impact.transform.tag == "Chunk")
            {
                // Remove height to terrain voxels
                switch (voxelVertex)
                {
                    case 0:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.backLeftVertex, -sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.backRightVertex, -sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.frontRightVertex, -sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.frontLeftVertex, -sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.frontLeftVertex);
                        }
                        break;
                    default:
                        break;
                }

                DevConstructionSkills.detChunk.BuildChunkVertices();
                DevConstructionSkills.detChunk.BuildChunkMesh();
            }
        }
    }


    public static void Place()
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (impact.transform.tag == "Chunk")
            {
                // Add height to terrain voxels
                switch (voxelVertex)
                {
                    case 0:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.backLeftVertex, sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.backLeftVertex);
                        }
                        break;
                    case 1:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.backRightVertex, sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.backRightVertex);
                        }
                        break;
                    case 2:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.frontRightVertex, sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.frontRightVertex);
                        }
                        break;
                    case 3:
                        {
                            Terraform(ref DevConstructionSkills.detVoxel.frontLeftVertex, sedimentPerClick);
                            PostTerraform(ref DevConstructionSkills.detVoxel.frontLeftVertex);
                        }
                        break;
                    default:
                        break;
                }

                DevConstructionSkills.detChunk.BuildChunkVertices();
                DevConstructionSkills.detChunk.BuildChunkMesh();
            }
        }
    }


    public static void Cancel()
    {

    }


    public static void Detect()
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (impact.transform.tag == "Chunk")
            {
                float height = 0;

                // Detecting the chunk, voxel and vertex we are aiming at
                DevConstructionSkills.detVertex = new Vector2(Mathf.Round(impact.point.x), Mathf.Round(impact.point.z));

                // Detects the vertex we are aiming at and it's height
                if (impact.point.x < DevConstructionSkills.detVertex.x)
                    if (impact.point.z < DevConstructionSkills.detVertex.y)
                    {
                        DetectChunkAndVoxel(-1, -1);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.frontRightVertex / SWorld.maxSediment;
                        voxelVertex = 2;
                    }
                    else
                    {
                        DetectChunkAndVoxel(-1, 0);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.backRightVertex / SWorld.maxSediment;
                        voxelVertex = 1;
                    }
                else
                    if (impact.point.z < DevConstructionSkills.detVertex.y)
                    {
                        DetectChunkAndVoxel(0, -1);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.frontLeftVertex / SWorld.maxSediment;
                        voxelVertex = 3;
                    }
                    else
                    {
                        DetectChunkAndVoxel(0, 0);
                        height = DevConstructionSkills.detVoxel.numID.y + DevConstructionSkills.detVoxel.backLeftVertex / SWorld.maxSediment;
                        voxelVertex = 0;
                    }

                // Set the sphereMarer to the neares vertex
                HUD.sphereMarker.transform.position = new Vector3(DevConstructionSkills.detVertex.x, height, DevConstructionSkills.detVertex.y);
            }
        }
    }


    private static void DetectChunkAndVoxel(int x, int z)
    {
        // Detects the chunk and voxel we are aiming at
        DevConstructionSkills.chunk = SWorld.chunk[(int)Mathf.Round(DevConstructionSkills.detVertex.x + x) / SWorld.chunkSize.x,
                                                   (int)Mathf.Floor(impact.point.y / SWorld.chunkSize.y),
                                                   (int)Mathf.Round(DevConstructionSkills.detVertex.y + z) / SWorld.chunkSize.z];

        DevConstructionSkills.voxel = DevConstructionSkills.chunk.voxel[(int)Mathf.Round(DevConstructionSkills.detVertex.x + x) % SWorld.chunkSize.x,
                                                                        (int)Mathf.Floor(impact.point.y % SWorld.chunkSize.y),
                                                                        (int)Mathf.Round(DevConstructionSkills.detVertex.y + z) % SWorld.chunkSize.z];

        DevConstructionSkills.detChunk = DevConstructionSkills.chunk;
        DevConstructionSkills.detVoxel = DevConstructionSkills.voxel;

        // We make sure, we are changing the highest voxel
        while (LVoxel.VoxelExists(DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, 1, 0))
        {
            LVoxel.GetVoxel(ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 1, 0);
            if (DevConstructionSkills.detVoxel.voxelType != VoxelGenerator.VoxelType.VTERRAIN)
            {
                LVoxel.GetVoxel(ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);
                break;
            }
        }
        // Detects when all the vertices of the voxel are at max height, but we detect the upper one
        if (LVoxel.VoxelExists(DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, -1, 0))
            if (DevConstructionSkills.detVoxel.voxelType != VoxelGenerator.VoxelType.VTERRAIN)
                LVoxel.GetVoxel(ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);
    }


    private static void Terraform(ref float vertexHeight, int sediment)
    {
        // Adds or removes height from the selected vertex
        vertexHeight += sediment;

        if (vertexHeight < 0)
        {
            // We delete the current voxel and detect the excess of sediment
            SWorld.chunk[DevConstructionSkills.detChunk.numID.x, DevConstructionSkills.detChunk.numID.y, DevConstructionSkills.detChunk.numID.z].voxel[DevConstructionSkills.detVoxel.numID.x, DevConstructionSkills.detVoxel.numID.y, DevConstructionSkills.detVoxel.numID.z]
                    = new VoxelGenerator(DevConstructionSkills.detVoxel.numID, DevConstructionSkills.detChunk.numID, "Air");
            sedimentExcess = (int)vertexHeight;

            // We get the voxel below for futher terraformation
            if (LVoxel.VoxelExists(DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, -1, 0))
                LVoxel.GetVoxel(ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, -1, 0);
        }
        else if (vertexHeight > SWorld.maxSediment)
        {
            // We get the voxel above for actual and futher terraformation
            if (LVoxel.VoxelExists(DevConstructionSkills.detChunk, DevConstructionSkills.detVoxel, 0, 1, 0))
                LVoxel.GetVoxel(ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 1, 0);

            // We place a terrain voxel above and detect the excess of sediment
            SWorld.chunk[DevConstructionSkills.detChunk.numID.x, DevConstructionSkills.detChunk.numID.y, DevConstructionSkills.detChunk.numID.z].voxel[DevConstructionSkills.detVoxel.numID.x, DevConstructionSkills.detVoxel.numID.y, DevConstructionSkills.detVoxel.numID.z]
                    = new VoxelGenerator(DevConstructionSkills.detVoxel.numID, DevConstructionSkills.detChunk.numID, SWorld.selectedTerrain);
            sedimentExcess = (int)vertexHeight;

            LVoxel.GetVoxel(ref DevConstructionSkills.detChunk, ref DevConstructionSkills.detVoxel, 0, 0, 0);
        }
    }


    private static void PostTerraform(ref float vertexHeight)
    {
        if (sedimentExcess < 0)
        {
            DevConstructionSkills.detVoxel.backLeftVertex = (int)SWorld.maxSediment;
            DevConstructionSkills.detVoxel.backRightVertex = (int)SWorld.maxSediment;
            DevConstructionSkills.detVoxel.frontLeftVertex = (int)SWorld.maxSediment;
            DevConstructionSkills.detVoxel.frontRightVertex = (int)SWorld.maxSediment;

            vertexHeight = (int)(SWorld.maxSediment + sedimentExcess);

            sedimentExcess = 0;
        }
        else if (sedimentExcess > SWorld.maxSediment)
        {
            DevConstructionSkills.detVoxel.backLeftVertex = 0;
            DevConstructionSkills.detVoxel.backRightVertex = 0;
            DevConstructionSkills.detVoxel.frontLeftVertex = 0;
            DevConstructionSkills.detVoxel.frontRightVertex = 0;

            vertexHeight = (int)(sedimentExcess - SWorld.maxSediment);

            sedimentExcess = 0;
        }
    }
}