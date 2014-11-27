using UnityEngine;
using System.Collections;

public static class VoxelLib
{
    public static bool VoxelExists(World world, ChunkGenerator detectionChunk, Voxel detectionVoxel, int x, int y, int z)
    {
        if (detectionChunk.numID.x * world.chunkSize.x + detectionVoxel.numID.x + x >= 0 &&
            detectionChunk.numID.x * world.chunkSize.x + detectionVoxel.numID.x + x < world.chunkNumber.x * world.chunkSize.x &&
            detectionChunk.numID.y * world.chunkSize.y + detectionVoxel.numID.y + y >= 0 &&
            detectionChunk.numID.y * world.chunkSize.y + detectionVoxel.numID.y + y < world.chunkNumber.y * world.chunkSize.y &&
            detectionChunk.numID.z * world.chunkSize.z + detectionVoxel.numID.z + z >= 0 &&
            detectionChunk.numID.z * world.chunkSize.z + detectionVoxel.numID.z + z < world.chunkNumber.z * world.chunkSize.z)
            return true;
        else
            return false;
    }


    public static void GetVoxel(World world, ref ChunkGenerator detectionChunk, ref Voxel detectionVoxel, int x, int y, int z)
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
        if (vx == world.chunkSize.x)
        {
            cx++;
            vx = 0;
        }
        else if (vx < 0)
        {
            cx--;
            vx = world.chunkSize.x - 1;
        }

        if (vy == world.chunkSize.y)
        {
            cy++;
            vy = 0;
        }
        else if (vy < 0)
        {
            cy--;
            vy = world.chunkSize.y - 1;
        }

        if (vz == world.chunkSize.z)
        {
            cz++;
            vz = 0;
        }
        else if (vz < 0)
        {
            cz--;
            vz = world.chunkSize.z - 1;
        }

        detectionChunk = world.chunk[cx, cy, cz];
        detectionVoxel = detectionChunk.voxel[vx, vy, vz];
    }


    public static void Explosion(World world, Vector3 position, float damage, int blastRadius)
    {
        ChunkGenerator chunk = null;
        Voxel voxel = null;

        IntVector3 centralVoxel = new IntVector3((int)position.x, (int)position.y, (int)position.z);
        IntVector3 firstPosition;
        IntVector3 lastPosition;
        float recievedDamage;

        // positions for reseting the chunks when explosion finishes

        // The first chunk detected
        firstPosition = new IntVector3((centralVoxel.x - blastRadius) / world.chunkSize.x, 
                                       (centralVoxel.y - blastRadius) / world.chunkSize.y, (centralVoxel.z - blastRadius) / world.chunkSize.z);

        // lower limit of the chunk
        if (centralVoxel.x - blastRadius == 0)
            firstPosition.x--;
        if (centralVoxel.y - blastRadius == 0)
            firstPosition.y--;
        if (centralVoxel.z - blastRadius == 0)
            firstPosition.z--;

        // The last chunk detected
        lastPosition = new IntVector3((centralVoxel.x + blastRadius) / world.chunkSize.x, 
                                       (centralVoxel.y + blastRadius) / world.chunkSize.y, (centralVoxel.z + blastRadius) / world.chunkSize.z);

        // higher limit of the chunk
        if (centralVoxel.x + blastRadius == world.chunkSize.x - 1)
            lastPosition.x++;
        if (centralVoxel.y + blastRadius == world.chunkSize.y - 1)
            lastPosition.y++;
        if (centralVoxel.z + blastRadius == world.chunkSize.z - 1)
            lastPosition.z++;

        // Detect the voxels that will disapear
        for (int x = centralVoxel.x - blastRadius; x <= centralVoxel.x + blastRadius; x++)
            for (int y = centralVoxel.y - blastRadius; y <= centralVoxel.y + blastRadius; y++)
                for (int z = centralVoxel.z - blastRadius; z <= centralVoxel.z + blastRadius; z++)
                {
                    if (GetVoxelWithPositionIfExists(world, new IntVector3(x, y, z), ref chunk, ref voxel))
                    {
                        // Damage recieved by the voxel depending on the distance from the epicenter
                        recievedDamage = (blastRadius - Vector3.Distance(centralVoxel.ToVector3(), new Vector3(x, y, z))) * damage / blastRadius;

                        // Check if the voxel is destroyed
                        if (voxel.blastResistance < Mathf.Floor(recievedDamage))
                        {
                            world.chunk[chunk.numID.x, chunk.numID.y, chunk.numID.z].voxel[voxel.numID.x, voxel.numID.y, voxel.numID.z] = 
                                new Voxel(world, new IntVector3(voxel.numID.x, voxel.numID.y, voxel.numID.z), 
                                new IntVector3(chunk.numID.x, chunk.numID.y, chunk.numID.z), "Air");
                        }
                    }
                }


        // Chunks reset

        // We reset the impacted chunkFirst
        world.chunksToReset.Add(new IntVector3(centralVoxel.x / world.chunkSize.x, centralVoxel.y / world.chunkSize.y, centralVoxel.z / world.chunkSize.z));

        for (int x = firstPosition.x; x <= lastPosition.x; x++)
            for (int y = firstPosition.y; y <= lastPosition.y; y++)
                for (int z = firstPosition.z; z <= lastPosition.z; z++)
                {
                    if (LChunk.ChunkExists(world, new IntVector3(x, y, z)))
                        world.chunksToReset.Add(new IntVector3(x, y, z));
                }
    }


    public static bool GetVoxelWithPositionIfExists(World world, IntVector3 position, ref ChunkGenerator chunk, ref Voxel voxel)
    {
        if (position.x < 0 || position.x >= world.chunkNumber.x * world.chunkSize.x ||
            position.y < 0 || position.y >= world.chunkNumber.y * world.chunkSize.y ||
            position.z < 0 || position.z >= world.chunkNumber.z * world.chunkSize.z)
        {
            return false;
        }

        chunk = world.chunk[(int)position.x / world.chunkSize.x, (int)position.y / world.chunkSize.y, (int)position.z / world.chunkSize.z];
        voxel = chunk.voxel[(int)position.x % world.chunkSize.x, (int)position.y % world.chunkSize.y, (int)position.z % world.chunkSize.z];

        return true;
    }
}
