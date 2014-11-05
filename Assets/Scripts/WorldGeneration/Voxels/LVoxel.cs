using UnityEngine;
using System.Collections;

public static class LVoxel
{
    public static bool VoxelExists(ChunkGenerator detectionChunk, VoxelGenerator detectionVoxel, int x, int y, int z)
    {
        if (detectionChunk.numID.x * SWorld.chunkSize.x + detectionVoxel.numID.x + x >= 0 &&
            detectionChunk.numID.x * SWorld.chunkSize.x + detectionVoxel.numID.x + x < SWorld.chunkNumber.x * SWorld.chunkSize.x &&
            detectionChunk.numID.y * SWorld.chunkSize.y + detectionVoxel.numID.y + y >= 0 &&
            detectionChunk.numID.y * SWorld.chunkSize.y + detectionVoxel.numID.y + y < SWorld.chunkNumber.y * SWorld.chunkSize.y &&
            detectionChunk.numID.z * SWorld.chunkSize.z + detectionVoxel.numID.z + z >= 0 &&
            detectionChunk.numID.z * SWorld.chunkSize.z + detectionVoxel.numID.z + z < SWorld.chunkNumber.z * SWorld.chunkSize.z)
            return true;
        else
            return false;
    }


    public static void GetVoxel(ref ChunkGenerator detectionChunk, ref VoxelGenerator detectionVoxel, int x, int y, int z)
    {
        int cx, cy, cz;
        int vx, vy, vz;


        // Voxel adapt
        vx = detectionVoxel.numID.x + x;
        vy = detectionVoxel.numID.y + y;
        vz = detectionVoxel.numID.z + z;

        // Chunk adapt
        cx = detectionChunk.numID.x;
        cy = detectionChunk.numID.y;
        cz = detectionChunk.numID.z;


        // slices
        if (vx == SWorld.chunkSize.x)
        {
            cx++;
            vx = 0;
        }
        else if (vx < 0)
        {
            cx--;
            vx = SWorld.chunkSize.x - 1;
        }

        if (vy == SWorld.chunkSize.y)
        {
            cy++;
            vy = 0;
        }
        else if (vy < 0)
        {
            cy--;
            vy = SWorld.chunkSize.y - 1;
        }

        if (vz == SWorld.chunkSize.z)
        {
            cz++;
            vz = 0;
        }
        else if (vz < 0)
        {
            cz--;
            vz = SWorld.chunkSize.z - 1;
        }

        detectionChunk = SWorld.chunk[cx, cy, cz];
        detectionVoxel = detectionChunk.voxel[vx, vy, vz];
    }
}
