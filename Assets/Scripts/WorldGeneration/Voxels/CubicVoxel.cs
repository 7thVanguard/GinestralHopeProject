﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubicVoxel : MonoBehaviour 
{
    private static Chunk chunk;
    private static Voxel voxel;

    private static Chunk detChunk;
    private static Voxel detVoxel;

    private static bool rightFull = false;
    private static bool frontFull = false;
    private static bool leftFull = false;
    private static bool backFull = false;
    private static bool topFull = false;
    private static bool botFull = false;

    private static int aux;


    // Check if the voxel is visible
    // Faces 1 - Right, 2 - Front, 3 - Left, 4 - Back, 5 - Top, 6 - Bot
    public static void DetectSorroundings(World world, IntVector3 chunkID, IntVector3 voxelID)
    {
        // Setting
        //chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        chunk = world.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;

        // Detect the sorrounding blocks
        rightFull = VisibilityCalculation(world, 1, 0, 0);
        frontFull = VisibilityCalculation(world, 0, 0, -1);
        leftFull = VisibilityCalculation(world, -1, 0, 0);
        backFull = VisibilityCalculation(world, 0, 0, 1);
        topFull = VisibilityCalculation(world, 0, 1, 0);
        botFull = VisibilityCalculation(world, 0, -1, 0);
    }


    public static void FaceVertices
        (World world, IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, ref int vertexCount)
    {
        // Setting
        chunk = world.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;

        // Get the center of the voxel
        Vector3 generalLoaction = new Vector3(world.chunkSize.x * chunkID.x + voxelID.x + 0.5f,
                                              world.chunkSize.y * chunkID.y + voxelID.y + 0.5f,
                                              world.chunkSize.z * chunkID.z + voxelID.z + 0.5f);


        // Create the voxel using a displaced general location and the constant dimension marked as 0
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, ref vertexCount);
    }


    public static void FaceNormals
        (World world, IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Normals)
    {
        chunk = world.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;
    }


    private static bool VisibilityCalculation(World world, int x, int y, int z)
    {
        bool transparency = false;
        detChunk = chunk;
        detVoxel = voxel;

        if (VoxelLib.VoxelExists(world, detChunk, detVoxel, x, y, z))
        {
            VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, x, y, z);

            if (x > 0)
                transparency = TransparencyCalculation(world, detVoxel.leftTransparent);
            else if (x < 0)
                transparency = TransparencyCalculation(world, detVoxel.rightTransparent);
            else if (y > 0)
                transparency = detVoxel.botTransparent;
            else if (y < 0)
                transparency = detVoxel.topTransparent;
            else if (z > 0)
                transparency = TransparencyCalculation(world, detVoxel.frontTransparent);
            else if (z < 0)
                transparency = TransparencyCalculation(world, detVoxel.backTransparent);

            if (transparency)
                return false;
            else
                return true;
        }
        else
            return false;
    }


    private static bool TransparencyCalculation(World world, bool relatedTransparent)
    {
        if (detVoxel.type != VoxelType.CUBIC && detVoxel.state == VoxelState.SOLID)
        {
            if (VoxelLib.VoxelExists(world, detChunk, detVoxel, 0, 1, 0))
            {
                VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, 0, 1, 0);

                if (detVoxel.state == VoxelState.SOLID)
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        else
            return relatedTransparent;
    }


    private static void PlaceVertices(World world, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, Vector3 genLoc, ref int vertexCount)
    {
        detChunk = chunk;
        detVoxel = voxel;

        // If the face is visible
        if (!rightFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y - 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y - 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y + 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y + 0.5f, genLoc.z - 0.5f));

            SetVertexComponents(world, UV, Triangles, detVoxel.UVStartRight, ref vertexCount);
        }

        if (!frontFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y - 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y - 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y + 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y + 0.5f, genLoc.z - 0.5f));

            SetVertexComponents(world, UV, Triangles, detVoxel.UVStartFront, ref vertexCount);
        }
                                                     
        if (!leftFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y - 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y - 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y + 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y + 0.5f, genLoc.z + 0.5f));

            SetVertexComponents(world, UV, Triangles, detVoxel.UVStartLeft, ref vertexCount);
        }

        if (!backFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y - 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y - 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y + 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y + 0.5f, genLoc.z + 0.5f));

            SetVertexComponents(world, UV, Triangles, detVoxel.UVStartBack, ref vertexCount);
        }

        if (!topFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y + 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y + 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y + 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y + 0.5f, genLoc.z + 0.5f));

            SetVertexComponents(world, UV, Triangles, detVoxel.UVStartTop, ref vertexCount);
        }

        if (!botFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y - 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y - 0.5f, genLoc.z + 0.5f));
            Vertices.Add(new Vector3(genLoc.x + 0.5f, genLoc.y - 0.5f, genLoc.z - 0.5f));
            Vertices.Add(new Vector3(genLoc.x - 0.5f, genLoc.y - 0.5f, genLoc.z - 0.5f));

            SetVertexComponents(world, UV, Triangles, detVoxel.UVStartBot, ref vertexCount);
        }
            
    }


    private static void SetVertexComponents(World world, List<Vector2> UV, List<int> Triangles, Vector2 UVToApply, ref int vertexCount)
    {
        // UV
        UV.Add(new Vector2(UVToApply.x, UVToApply.y + world.textureSize));
        UV.Add(new Vector2(UVToApply.x + world.textureSize, UVToApply.y + world.textureSize));
        UV.Add(new Vector2(UVToApply.x + world.textureSize, UVToApply.y));
        UV.Add(new Vector2(UVToApply.x, UVToApply.y));

        // Triangles
        Triangles.Add(vertexCount + 0);
        Triangles.Add(vertexCount + 2);
        Triangles.Add(vertexCount + 1);

        Triangles.Add(vertexCount + 0);
        Triangles.Add(vertexCount + 3);
        Triangles.Add(vertexCount + 2);

        vertexCount += 4;
    }
}
