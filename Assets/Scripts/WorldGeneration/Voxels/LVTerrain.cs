using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LVTerrain
{
    private static ChunkGenerator chunk;
    private static VoxelGenerator voxel;

    private static ChunkGenerator detChunk;
    private static VoxelGenerator detVoxel;

    private static float mean;


    // Check if the terrain is visible
    public static bool IsFaceVisible(World world, IntVector3 chunkID, IntVector3 voxelID)
    {
        // Setting
        chunk = world.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;

        if (LVoxel.VoxelExists(world, detChunk, detVoxel, 0, 1, 0) == true)
        {
            LVoxel.GetVoxel(world, ref detChunk, ref detVoxel, 0, 1, 0);
            if (detVoxel.botTransparent)
                return true;
            else
                return false;
        }
        else
            return true;
    }


    public static void FaceVertices
        (World world, IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, ref int vertexCount)
    {
        // Setting
        chunk = world.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;


        // Definition General Location
        IntVector3 generalLoaction = new IntVector3(world.chunkSize.x * chunkID.x + voxelID.x,
                                                    world.chunkSize.y * chunkID.y + voxelID.y,
                                                    world.chunkSize.z * chunkID.z + voxelID.z);

        // Geometry creation

        // Vertices
        AddVertex(world, Vertices, generalLoaction, voxel.backLeftVertex, 0, 0);
        AddVertex(world, Vertices, generalLoaction, voxel.backRightVertex, 1, 0);
        AddVertex(world, Vertices, generalLoaction, voxel.frontRightVertex, 1, 1);
        AddVertex(world, Vertices, generalLoaction, voxel.frontLeftVertex, 0, 1);
        
        // The central vertex is calculed using the mean of the heights
        mean = voxel.backLeftVertex + voxel.backRightVertex + voxel.frontRightVertex + voxel.frontLeftVertex;
        Vertices.Add(new Vector3(0.5f + generalLoaction.x, generalLoaction.y + mean / (world.maxSediment * 4), 0.5f + generalLoaction.z));


        // UV
        UV.Add(new Vector2(detVoxel.UVStart.x, detVoxel.UVStart.y));
        UV.Add(new Vector2(detVoxel.UVStart.x + world.textureSize, detVoxel.UVStart.y));
        UV.Add(new Vector2(detVoxel.UVStart.x + world.textureSize, detVoxel.UVStart.y + world.textureSize));
        UV.Add(new Vector2(detVoxel.UVStart.x, detVoxel.UVStart.y + world.textureSize));
        UV.Add(new Vector2(detVoxel.UVStart.x + world.textureSize / 2.0f, detVoxel.UVStart.y + world.textureSize / 2.0f));


        // Triangles
        Triangles.Add(0 + vertexCount);
        Triangles.Add(4 + vertexCount);
        Triangles.Add(1 + vertexCount);

        Triangles.Add(1 + vertexCount);
        Triangles.Add(4 + vertexCount);
        Triangles.Add(2 + vertexCount);

        Triangles.Add(2 + vertexCount);
        Triangles.Add(4 + vertexCount);
        Triangles.Add(3 + vertexCount);

        Triangles.Add(3 + vertexCount);
        Triangles.Add(4 + vertexCount);
        Triangles.Add(0 + vertexCount);


        // Vertex count actualization
        vertexCount += 5;
    }


    public static void FaceNormals
        (World world, IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Normals)
    {
        chunk = world.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;
    }


    private static void AddVertex(World world, List<Vector3> Vertices, IntVector3 gL, float vertex, int x, int z)
    {
        // We put the vertices depending on their basic x and z position, and the height depending on their vertices
        Vertices.Add(new Vector3(x + gL.x, gL.y + vertex / world.maxSediment, z + gL.z));
    }
}
