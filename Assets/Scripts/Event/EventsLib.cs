using UnityEngine;
using System.Collections;

public static class EventsLib
{
    public static void EraseVoxels(World world, IntVector3 firstPosition, IntVector3 secondPosition)
    {
        VoxelGenericFunctionality(world, "Air", firstPosition, secondPosition);
    }


    public static void FillWithVoxels(World world, string replacingVoxels, IntVector3 firstPosition, IntVector3 secondPosition)
    {
        VoxelGenericFunctionality(world, replacingVoxels, firstPosition, secondPosition);
    }


    private static void VoxelGenericFunctionality(World world, string replacingVoxels, IntVector3 firstPosition, IntVector3 secondPosition)
    {
        ChunkGenerator chunk = null;
        Voxel voxel = null;

        IntVector3 initPos, endPos;
        IntVector3 chunkInitPos, chunkEndPos;

        // Initialize
        initPos = new IntVector3();
        endPos = new IntVector3();

        // Organizing the voxel positions
        initPos.x = Mathf.Min(firstPosition.x, secondPosition.x);
        endPos.x = Mathf.Max(firstPosition.x, secondPosition.x);
        initPos.y = Mathf.Min(firstPosition.y, secondPosition.y);
        endPos.y = Mathf.Max(firstPosition.y, secondPosition.y);
        initPos.z = Mathf.Min(firstPosition.z, secondPosition.z);
        endPos.z = Mathf.Max(firstPosition.z, secondPosition.z);

        // Organizing the chunk positions
        chunkInitPos = new IntVector3(initPos.x / world.chunkSize.x, initPos.y / world.chunkSize.y, initPos.z / world.chunkSize.z);
        chunkEndPos = new IntVector3(endPos.x / world.chunkSize.x, endPos.y / world.chunkSize.y, endPos.z / world.chunkSize.z);

        // Lower limit of the chunk
        if (initPos.x == 0)
            chunkInitPos.x--;
        if (initPos.y == 0)
            chunkInitPos.y--;
        if (initPos.z == 0)
            chunkInitPos.z--;

        // Lower limit of the chunk
        if (endPos.x == world.chunkSize.x - 1)
            chunkEndPos.x++;
        if (endPos.y == world.chunkSize.y - 1)
            chunkEndPos.y++;
        if (endPos.z == world.chunkSize.z - 1)
            chunkEndPos.z++;


        // Destroy chunks
        for (int x = initPos.x; x <= endPos.x; x++)
            for (int y = initPos.y; y <= endPos.y; y++)
                for (int z = initPos.z; z <= endPos.z; z++)
                {
                    if (VoxelLib.GetVoxelWithPositionIfExists(world, new IntVector3(x, y, z), ref chunk, ref voxel))
                    {
                        world.chunk[chunk.numID.x, chunk.numID.y, chunk.numID.z].voxel[voxel.numID.x, voxel.numID.y, voxel.numID.z] =
                                new Voxel(world, new IntVector3(voxel.numID.x, voxel.numID.y, voxel.numID.z),
                                new IntVector3(chunk.numID.x, chunk.numID.y, chunk.numID.z), replacingVoxels);
                    }
                }


        // Destroy chunks
        for (int x = chunkInitPos.x; x <= chunkEndPos.x; x++)
            for (int y = chunkInitPos.y; y <= chunkEndPos.y; y++)
                for (int z = chunkInitPos.z; z <= chunkEndPos.z; z++)
                {
                    if (LChunk.ChunkExists(world, new IntVector3(x, y, z)))
                        world.chunksToReset.Add(new IntVector3(x, y, z));
                }
    }
}
