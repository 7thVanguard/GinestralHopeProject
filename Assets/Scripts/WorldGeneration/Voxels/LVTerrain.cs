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
    public static bool IsFaceVisible(IntVector3 chunkID, IntVector3 voxelID)
    {
        // Setting
        chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;

        if (LVoxel.VoxelExists(detChunk, detVoxel, 0, 1, 0) == true)
        {
            LVoxel.GetVoxel(ref detChunk, ref detVoxel, 0, 1, 0);
            if (detVoxel.botTransparent)
                return true;
            else
                return false;
        }
        else
            return true;
    }


    public static void FaceVertices
        (IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles)
    {
        // Setting
        chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;


        // Definition General Location
        IntVector3 generalLoaction = new IntVector3(SWorld.chunkSize.x * chunkID.x + voxelID.x,
                                                    SWorld.chunkSize.y * chunkID.y + voxelID.y,
                                                    SWorld.chunkSize.z * chunkID.z + voxelID.z);

        // Geometry creation

        // Vertices
        AddVertex(Vertices, generalLoaction, voxel.backLeftVertex, 0, 0);
        AddVertex(Vertices, generalLoaction, voxel.backRightVertex, 1, 0);
        AddVertex(Vertices, generalLoaction, voxel.frontRightVertex, 1, 1);
        AddVertex(Vertices, generalLoaction, voxel.frontLeftVertex, 0, 1);
        
        // The central vertex is calculed using the mean of the heights
        mean = voxel.backLeftVertex + voxel.backRightVertex + voxel.frontRightVertex + voxel.frontLeftVertex;
        Vertices.Add(new Vector3(0.5f + generalLoaction.x, generalLoaction.y + mean / (SWorld.maxSediment * 4), 0.5f + generalLoaction.z));


        // UV
        UV.Add(new Vector2(detVoxel.UVStart.x, detVoxel.UVStart.y));
        UV.Add(new Vector2(detVoxel.UVStart.x + SWorld.textureSize, detVoxel.UVStart.y));
        UV.Add(new Vector2(detVoxel.UVStart.x + SWorld.textureSize, detVoxel.UVStart.y + SWorld.textureSize));
        UV.Add(new Vector2(detVoxel.UVStart.x, detVoxel.UVStart.y + SWorld.textureSize));
        UV.Add(new Vector2(detVoxel.UVStart.x + SWorld.textureSize / 2.0f, detVoxel.UVStart.y + SWorld.textureSize / 2.0f));


        // Triangles
        Triangles.Add(0 + SWorld.vertexCount);
        Triangles.Add(4 + SWorld.vertexCount);
        Triangles.Add(1 + SWorld.vertexCount);

        Triangles.Add(1 + SWorld.vertexCount);
        Triangles.Add(4 + SWorld.vertexCount);
        Triangles.Add(2 + SWorld.vertexCount);

        Triangles.Add(2 + SWorld.vertexCount);
        Triangles.Add(4 + SWorld.vertexCount);
        Triangles.Add(3 + SWorld.vertexCount);

        Triangles.Add(3 + SWorld.vertexCount);
        Triangles.Add(4 + SWorld.vertexCount);
        Triangles.Add(0 + SWorld.vertexCount);


        // Vertex count actualization
        SWorld.vertexCount += 5;
    }


    public static void FaceNormals
        (IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Normals)
    {
        chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;
    }


    private static void AddVertex(List<Vector3> Vertices, IntVector3 gL, float vertex, int x, int z)
    {
        // We put the vertices depending on their basic x and z position, and the height depending on their vertices
        Vertices.Add(new Vector3(x + gL.x, gL.y + vertex / SWorld.maxSediment, z + gL.z));
    }
}
