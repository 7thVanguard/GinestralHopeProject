using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LVMine
{
    private static ChunkGenerator chunk;
    private static VoxelGenerator voxel;

    private static ChunkGenerator detChunk;
    private static VoxelGenerator detVoxel;

    private static bool rightFull = false;
    private static bool frontFull = false;
    private static bool leftFull = false;
    private static bool backFull = false;
    private static bool topFull = false;
    private static bool botFull = false;

    private static Vector3 topFrontRightVertex = Vector3.zero;
    private static Vector3 topFrontLeftVertex = Vector3.zero;
    private static Vector3 topBackRightVertex = Vector3.zero;
    private static Vector3 topBackLeftVertex = Vector3.zero;
    private static Vector3 botFrontRightVertex = Vector3.zero;
    private static Vector3 botFrontLeftVertex = Vector3.zero;
    private static Vector3 botBackRightVertex = Vector3.zero;
    private static Vector3 botBackLeftVertex = Vector3.zero;

    private static int aux;


    // Check if the voxel is visible
    // Faces 1 - Right, 2 - Front, 3 - Left, 4 - Back, 5 - Top, 6 - Bot
    public static void DetectSorroundings(IntVector3 chunkID, IntVector3 voxelID)
    {
        // Setting
        chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;

        // Detect the sorrounding blocks
        rightFull = VisibilityCalculation(1, 0, 0);
        frontFull = VisibilityCalculation(0, 0, 1);
        leftFull = VisibilityCalculation(-1, 0, 0);
        backFull = VisibilityCalculation(0, 0, -1);
        topFull = VisibilityCalculation(0, 1, 0);
        botFull = VisibilityCalculation(0, -1, 0);
    }


    public static void FaceVertices
        (IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles)
    {
        // Setting
        chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;

        // Get the center of the voxel
        Vector3 generalLoaction = new Vector3(SWorld.chunkSize.x * chunkID.x + voxelID.x + 0.5f,
                                              SWorld.chunkSize.y * chunkID.y + voxelID.y + 0.5f,
                                              SWorld.chunkSize.z * chunkID.z + voxelID.z + 0.5f);

        // Check the positions of the vertices we are going to create
        topFrontRightVertex = VertexPosition(1, 1, 1, rightFull, topFull, frontFull);
        topFrontLeftVertex = VertexPosition(-1, 1, 1, leftFull, topFull, frontFull);
        topBackRightVertex = VertexPosition(1, 1, -1, rightFull, topFull, backFull);
        topBackLeftVertex = VertexPosition(-1, 1, -1, leftFull, topFull, backFull);
        botFrontRightVertex = VertexPosition(1, -1, 1, rightFull, botFull, frontFull);
        botFrontLeftVertex = VertexPosition(-1, -1, 1, leftFull, botFull, frontFull);
        botBackRightVertex = VertexPosition(1, -1, -1, rightFull, botFull, backFull);
        botBackLeftVertex = VertexPosition(-1, -1, -1, leftFull, botFull, backFull);


        // Check if the voxel beside is a visible terrain voxel and after that check if covers this voxel
        if (rightFull)
            rightFull = NerbyTerrainCalculation(1, 0, 0);
        if (frontFull)
            frontFull = NerbyTerrainCalculation(0, 0, 1);
        if (leftFull)
            leftFull = NerbyTerrainCalculation(-1, 0, 0);
        if (backFull)
            backFull = NerbyTerrainCalculation(0, 0, -1);
        if (topFull)
            topFull = NerbyTerrainCalculation(0, 1, 0);
        if (botFull)
            botFull = NerbyTerrainCalculation(0, -1, 0);


        // Create the voxel depending ont he vertices we found before
        PlaceVertices(Vertices, UV, Triangles, generalLoaction, botBackRightVertex, botFrontRightVertex, topFrontRightVertex, topBackRightVertex, rightFull);
        PlaceVertices(Vertices, UV, Triangles, generalLoaction, botFrontRightVertex, botFrontLeftVertex, topFrontLeftVertex, topFrontRightVertex, frontFull);
        PlaceVertices(Vertices, UV, Triangles, generalLoaction, botFrontLeftVertex, botBackLeftVertex, topBackLeftVertex, topFrontLeftVertex, leftFull);
        PlaceVertices(Vertices, UV, Triangles, generalLoaction, botBackLeftVertex, botBackRightVertex, topBackRightVertex, topBackLeftVertex, backFull);
        PlaceVertices(Vertices, UV, Triangles, generalLoaction, topBackLeftVertex, topBackRightVertex, topFrontRightVertex, topFrontLeftVertex, topFull);
        PlaceVertices(Vertices, UV, Triangles, generalLoaction, botFrontLeftVertex, botFrontRightVertex, botBackRightVertex, botBackLeftVertex, botFull);
    }


    public static void FaceNormals
        (IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Normals)
    {
        chunk = SWorld.chunk[chunkID.x, chunkID.y, chunkID.z];
        voxel = chunk.voxel[voxelID.x, voxelID.y, voxelID.z];

        detChunk = chunk;
        detVoxel = voxel;
    }


    private static bool VisibilityCalculation(int x, int y, int z)
    {
        bool transparency = false;
        detChunk = chunk;
        detVoxel = voxel;

        if (LVoxel.VoxelExists(detChunk, detVoxel, x, y, z) == true)
        {
            LVoxel.GetVoxel(ref detChunk, ref detVoxel, x, y, z);

            if (x > 0)
                transparency = detVoxel.leftTransparent;
            else if (x < 0)
                transparency = detVoxel.rightTransparent;
            else if (y > 0)
                transparency = detVoxel.botTransparent;
            else if (y < 0)
                transparency = detVoxel.topTransparent;
            else if (z > 0)
                transparency = detVoxel.backTransparent;
            else if (z < 0)
                transparency = detVoxel.frontTransparent;

            if (transparency)
                return false;
            else
                return true;
        }
        else
            return false;
    }


    private static Vector3 VertexPosition(int x, int y, int z, bool voxelFullX, bool voxelFullY, bool voxelFullZ)
    {
        Vector3 vertexPosition = Vector3.one;
        vertexPosition.x = x;
        vertexPosition.y = y;
        vertexPosition.z = z;


        bool xDone = false;
        bool yDone = false;
        bool zDone = false;

        
        if (voxelFullX)
        {
            vertexPosition.x = 2 * x;
            xDone = true;
        }

        if (voxelFullY)
        {
            vertexPosition.y = 2 * y;
            yDone = true;
        }

        if (voxelFullZ)
        {
            vertexPosition.z = 2 * z;
            zDone = true;
        }

        if (xDone != yDone)
            if (LVoxel.VoxelExists(detChunk, detVoxel, x, y, 0))
            {
                LVoxel.GetVoxel(ref detChunk, ref detVoxel, x, y, 0);

                if (detVoxel.voxelState == VoxelGenerator.VoxelState.SOLID)
                {
                    vertexPosition.x = 2 * x;
                    vertexPosition.y = 2 * y;
                    xDone = true;
                    yDone = true;
                }

                detChunk = chunk;
                detVoxel = voxel;
            }

        if (xDone != zDone)
            if (LVoxel.VoxelExists(detChunk, detVoxel, x, 0, z))
            {
                LVoxel.GetVoxel(ref detChunk, ref detVoxel, x, 0, z);

                if (detVoxel.voxelState == VoxelGenerator.VoxelState.SOLID)
                {
                    vertexPosition.x = 2 * x;
                    vertexPosition.z = 2 * z;
                    xDone = true;
                    zDone = true;
                }

                detChunk = chunk;
                detVoxel = voxel;
            }

        if (yDone != zDone)
            if (LVoxel.VoxelExists(detChunk, detVoxel, 0, y, z))
            {
                LVoxel.GetVoxel(ref detChunk, ref detVoxel, 0, y, z);

                if (detVoxel.voxelState == VoxelGenerator.VoxelState.SOLID)
                {
                    vertexPosition.y = 2 * y;
                    vertexPosition.z = 2 * z;
                    yDone = true;
                    zDone = true;
                }

                detChunk = chunk;
                detVoxel = voxel;
            }

        if (xDone != yDone || xDone != zDone || yDone != zDone)
            if (LVoxel.VoxelExists(detChunk, detVoxel, x, y, z))
            {
                LVoxel.GetVoxel(ref detChunk, ref detVoxel, x, y, z);

                if (detVoxel.voxelState == VoxelGenerator.VoxelState.SOLID)
                {
                    vertexPosition.x = 2 * x;
                    vertexPosition.y = 2 * y;
                    vertexPosition.z = 2 * z;
                }

                detChunk = chunk;
                detVoxel = voxel;
            }

        return vertexPosition;
    }


    private static bool NerbyTerrainCalculation(int x, int y, int z)
    {
        detChunk = chunk;
        detVoxel = voxel;

        LVoxel.GetVoxel(ref detChunk, ref detVoxel, x, y, z);
        if (detVoxel.voxelType == VoxelGenerator.VoxelType.VTERRAIN)
        {
            if (LVoxel.VoxelExists(detChunk, detVoxel, 0, 1, 0) == true)
            {
                LVoxel.GetVoxel(ref detChunk, ref detVoxel, 0, 1, 0);

                if (detVoxel.botTransparent)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        return true;
    }


    private static void PlaceVertices(List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, Vector3 genLoc,
                                           Vector3 addPos1, Vector3 addPos2, Vector3 addPos3, Vector3 addPos4, bool voxelFull)
    {
        detChunk = chunk;
        detVoxel = voxel;

        // If the face is visible
        if (!voxelFull)
        {
            // Vertices
            Vertices.Add(new Vector3(genLoc.x + addPos1.x * 0.25f, genLoc.y + addPos1.y * 0.25f, genLoc.z + addPos1.z * 0.25f));
            Vertices.Add(new Vector3(genLoc.x + addPos2.x * 0.25f, genLoc.y + addPos2.y * 0.25f, genLoc.z + addPos2.z * 0.25f));
            Vertices.Add(new Vector3(genLoc.x + addPos3.x * 0.25f, genLoc.y + addPos3.y * 0.25f, genLoc.z + addPos3.z * 0.25f));
            Vertices.Add(new Vector3(genLoc.x + addPos4.x * 0.25f, genLoc.y + addPos4.y * 0.25f, genLoc.z + addPos4.z * 0.25f));

            // UV
            UV.Add(new Vector2(detVoxel.UVStart.x, detVoxel.UVStart.y + SWorld.textureSize));
            UV.Add(new Vector2(detVoxel.UVStart.x + SWorld.textureSize, detVoxel.UVStart.y + SWorld.textureSize));
            UV.Add(new Vector2(detVoxel.UVStart.x + SWorld.textureSize, detVoxel.UVStart.y));
            UV.Add(new Vector2(detVoxel.UVStart.x, detVoxel.UVStart.y));

            Triangles.Add(SWorld.vertexCount + 0);
            Triangles.Add(SWorld.vertexCount + 2);
            Triangles.Add(SWorld.vertexCount + 1);

            Triangles.Add(SWorld.vertexCount + 0);
            Triangles.Add(SWorld.vertexCount + 3);
            Triangles.Add(SWorld.vertexCount + 2);

            SWorld.vertexCount += 4;
        }
    }
}
