using UnityEngine;
using System.Collections;

public class LChunk
{
    public static bool ChunkExists(ChunkGenerator detectionChunk, int x, int y, int z)
    {
        if (detectionChunk.numID.x + x < SWorld.chunkNumber.x &&
            detectionChunk.numID.x + x >= 0 &&
            detectionChunk.numID.y + y < SWorld.chunkNumber.y &&
            detectionChunk.numID.y + y >= 0 &&
            detectionChunk.numID.z + z < SWorld.chunkNumber.z &&
            detectionChunk.numID.z + z >= 0)
            return true;
        else
            return false;
    }


    public static void Reset(ChunkGenerator detectionChunk, VoxelGenerator detectionVoxel)
    {
        int xSign, ySign, zSign;

        // Resets the nearer chunks
        if (detectionVoxel.numID.x < SWorld.chunkSize.x / 2)
            xSign = -1;
        else
            xSign = 1;

        if (detectionVoxel.numID.y < SWorld.chunkSize.y / 2)
            ySign = -1;
        else
            ySign = 1;

        if (detectionVoxel.numID.z < SWorld.chunkSize.z / 2)
            zSign = -1;
        else
            zSign = 1;

        // Selected chunk reset
        SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x, detectionChunk.numID.y, detectionChunk.numID.z));

        // x alone
        if (LChunk.ChunkExists(detectionChunk, xSign, 0, 0))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x + xSign, detectionChunk.numID.y, detectionChunk.numID.z));

        // y alone
        if (LChunk.ChunkExists(detectionChunk, 0, ySign, 0))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x, detectionChunk.numID.y + ySign, detectionChunk.numID.z));

        // z alone
        if (LChunk.ChunkExists(detectionChunk, 0, 0, zSign))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x, detectionChunk.numID.y, detectionChunk.numID.z + zSign));

        // x and y
        if (LChunk.ChunkExists(detectionChunk, xSign, ySign, 0))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x + xSign, detectionChunk.numID.y + ySign, detectionChunk.numID.z));

        // x and z
        if (LChunk.ChunkExists(detectionChunk, xSign, 0, zSign))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x + xSign, detectionChunk.numID.y, detectionChunk.numID.z + zSign));

        // y and z
        if (LChunk.ChunkExists(detectionChunk, 0, ySign, zSign))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x, detectionChunk.numID.y + ySign, detectionChunk.numID.z + zSign));

        // x, y and z
        if (LChunk.ChunkExists(detectionChunk, xSign, ySign, zSign))
            SWorld.chunksToReset.Add(new IntVector3(detectionChunk.numID.x + xSign, detectionChunk.numID.y + ySign, detectionChunk.numID.z + zSign));


        // We make sure we reset at least two chunks at the same moment we changed them
        // Reset chunks queue
        if (SWorld.chunksToReset.Count > 0)
        {
            // Check if there is more than one chunk to reset, and reset the second in the list if true
            if (SWorld.chunksToReset.Count > 1)
            {
                // Resets the chunk
                SWorld.chunk[SWorld.chunksToReset[1].x, SWorld.chunksToReset[1].y, SWorld.chunksToReset[1].z].BuildChunkVertices();
                SWorld.chunk[SWorld.chunksToReset[1].x, SWorld.chunksToReset[1].y, SWorld.chunksToReset[1].z].BuildChunkMesh();

                // Removes the reseted chunk from the list
                SWorld.chunksToReset.Remove(SWorld.chunksToReset[1]);
            }

            // Resets the chunk
            SWorld.chunk[SWorld.chunksToReset[0].x, SWorld.chunksToReset[0].y, SWorld.chunksToReset[0].z].BuildChunkVertices();
            SWorld.chunk[SWorld.chunksToReset[0].x, SWorld.chunksToReset[0].y, SWorld.chunksToReset[0].z].BuildChunkMesh();

            // Removes the reseted chunk from the list
            SWorld.chunksToReset.Remove(SWorld.chunksToReset[0]);
        }
    }
}
