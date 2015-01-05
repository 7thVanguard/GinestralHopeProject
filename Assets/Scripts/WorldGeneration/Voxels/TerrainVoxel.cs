using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainVoxel
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
        frontFull = VisibilityCalculation(world, 0, 0, 1);
        leftFull = VisibilityCalculation(world, -1, 0, 0);
        backFull = VisibilityCalculation(world, 0, 0, -1);
        topFull = VisibilityCalculation(world, 0, 1, 0);
        botFull = VisibilityCalculation(world, 0, -1, 0);
    }


    public static void FaceVertices
        (World world, IntVector3 chunkID, IntVector3 voxelID, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles,
        ref int vertexCount)
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

        // Check the positions of the vertices we are going to create
        topFrontRightVertex = VertexPosition(world, 1, 1, 1, rightFull, topFull, frontFull);
        topFrontLeftVertex = VertexPosition(world, -1, 1, 1, leftFull, topFull, frontFull);
        topBackRightVertex = VertexPosition(world, 1, 1, -1, rightFull, topFull, backFull);
        topBackLeftVertex = VertexPosition(world, -1, 1, -1, leftFull, topFull, backFull);
        botFrontRightVertex = VertexPosition(world, 1, -1, 1, rightFull, botFull, frontFull);
        botFrontLeftVertex = VertexPosition(world, -1, -1, 1, leftFull, botFull, frontFull);
        botBackRightVertex = VertexPosition(world, 1, -1, -1, rightFull, botFull, backFull);
        botBackLeftVertex = VertexPosition(world, -1, -1, -1, leftFull, botFull, backFull);


        // Create the voxel depending ont he vertices we found before
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, botBackRightVertex, botFrontRightVertex, topFrontRightVertex, topBackRightVertex, ref vertexCount, rightFull);
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, botFrontRightVertex, botFrontLeftVertex, topFrontLeftVertex, topFrontRightVertex, ref vertexCount, frontFull);
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, botFrontLeftVertex, botBackLeftVertex, topBackLeftVertex, topFrontLeftVertex, ref vertexCount, leftFull);
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, botBackLeftVertex, botBackRightVertex, topBackRightVertex, topBackLeftVertex, ref vertexCount, backFull);
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, topBackLeftVertex, topBackRightVertex, topFrontRightVertex, topFrontLeftVertex, ref vertexCount, topFull);
        PlaceVertices(world, Vertices, UV, Triangles, generalLoaction, botFrontLeftVertex, botFrontRightVertex, botBackRightVertex, botBackLeftVertex, ref vertexCount, botFull);
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

        if (VoxelLib.VoxelExists(world, detChunk, detVoxel, x, y, z) == true)
        {
            VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, x, y, z);

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


    private static Vector3 VertexPosition(World world, int x, int y, int z, bool voxelFullX, bool voxelFullY, bool voxelFullZ)
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
            if (VoxelLib.VoxelExists(world, detChunk, detVoxel, x, y, 0))
            {
                VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, x, y, 0);

                if (detVoxel.state == VoxelState.SOLID)
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
            if (VoxelLib.VoxelExists(world, detChunk, detVoxel, x, 0, z))
            {
                VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, x, 0, z);

                if (detVoxel.state == VoxelState.SOLID)
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
            if (VoxelLib.VoxelExists(world, detChunk, detVoxel, 0, y, z))
            {
                VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, 0, y, z);

                if (detVoxel.state == VoxelState.SOLID)
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
            if (VoxelLib.VoxelExists(world, detChunk, detVoxel, x, y, z))
            {
                VoxelLib.GetVoxel(world, ref detChunk, ref detVoxel, x, y, z);

                if (detVoxel.state == VoxelState.SOLID)
                {
                    vertexPosition.x = 2 * x;
                    vertexPosition.y = 2 * y;
                    vertexPosition.z = 2 * z;
                }

                detChunk = chunk;
                detVoxel = voxel;
            }


        // Terrain correction
        if (vertexPosition.x != 2 * x)
            vertexPosition.x = 0;
        if (vertexPosition.y != 2 * y)
            vertexPosition.y = 0;
        if (vertexPosition.z != 2 * z)
            vertexPosition.z = 0;

        return vertexPosition;
    }


    private static void PlaceVertices(World world, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, Vector3 genLoc,
                                    Vector3 addPos1, Vector3 addPos2, Vector3 addPos3, Vector3 addPos4, ref int vertexCount, bool voxelFull)
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
            UV.Add(new Vector2(detVoxel.UVStartTop.x, detVoxel.UVStartTop.y + world.textureSize));
            UV.Add(new Vector2(detVoxel.UVStartTop.x + world.textureSize, detVoxel.UVStartTop.y + world.textureSize));
            UV.Add(new Vector2(detVoxel.UVStartTop.x + world.textureSize, detVoxel.UVStartTop.y));
            UV.Add(new Vector2(detVoxel.UVStartTop.x, detVoxel.UVStartTop.y));

            Triangles.Add(vertexCount + 0);
            Triangles.Add(vertexCount + 2);
            Triangles.Add(vertexCount + 1);

            Triangles.Add(vertexCount + 0);
            Triangles.Add(vertexCount + 3);
            Triangles.Add(vertexCount + 2);

            vertexCount += 4;
        }
    }
}