using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class EGameSerializer
{
    private static string[] dataString;
    private static float[] dataFloat;

    public void Save(World world, string saveName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Assets/Saves/" + saveName + ".save");

        dataString = new string[world.chunkSize.z];
        dataFloat = new float[world.chunkSize.z * 4];

        Encryptor(world, bf, file);
        file.Close();
    }


    public void Load(World world, string saveName)
    {
        if (File.Exists("Assets/Saves/" + saveName + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Assets/Saves/" + saveName + ".save", FileMode.Open);

            dataString = new string[world.chunkSize.z];
            dataFloat = new float[world.chunkSize.z * 4];

            Desencrypter(world, bf, file);
            file.Close();
        }
    }


    private void Encryptor(World world, BinaryFormatter bf, FileStream file)
    {
        // Save SWorld
        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                {
                    if (!world.chunk[cx, cy, cz].empty)
                        for (int x = 0; x < world.chunkSize.x; x++)
                            for (int y = 0; y < world.chunkSize.x; y++)
                            {
                                for (int z = 0; z < world.chunkSize.x; z++)
                                {
                                    // We allocate all z information in two simple arrays
                                    dataString[z] = world.chunk[cx, cy, cz].voxel[x, y, z].hashName;
                                    if (world.chunk[cx, cy, cz].voxel[x, y, z].voxelType == VoxelGenerator.VoxelType.VTERRAIN)
                                    {
                                        dataFloat[z * 4] = world.chunk[cx, cy, cz].voxel[x, y, z].backLeftVertex;
                                        dataFloat[z * 4 + 1] = world.chunk[cx, cy, cz].voxel[x, y, z].backRightVertex;
                                        dataFloat[z * 4 + 2] = world.chunk[cx, cy, cz].voxel[x, y, z].frontRightVertex;
                                        dataFloat[z * 4 + 3] = world.chunk[cx, cy, cz].voxel[x, y, z].frontLeftVertex;
                                    }
                                }   // for lop z end

                                // Serialization of the arrays
                                bf.Serialize(file, dataString);
                                bf.Serialize(file, dataFloat);
                            }   // for lop y end
                }   // for loop cz end, end of chunk
    }


    private void Desencrypter(World world, BinaryFormatter bf, FileStream file)
    {
        // Load world
        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                {
                    if (!world.chunk[cx, cy, cz].empty)
                        for (int x = 0; x < world.chunkSize.x; x++)
                            for (int y = 0; y < world.chunkSize.x; y++)
                            {
                                // Deserialization of the arrays first
                                dataString = (string[])bf.Deserialize(file);
                                dataFloat = (float[])bf.Deserialize(file);

                                for (int z = 0; z < world.chunkSize.x; z++)
                                {
                                    // We assign the variables to the voxels
                                    world.chunk[cx, cy, cz].voxel[x, y, z] = new VoxelGenerator(world, new IntVector3(x, y, z), new IntVector3(cx, cy, cz), dataString[z]);

                                    if (world.chunk[cx, cy, cz].voxel[x, y, z].voxelType == VoxelGenerator.VoxelType.VTERRAIN)
                                    {
                                        world.chunk[cx, cy, cz].voxel[x, y, z].backLeftVertex = dataFloat[z * 4];
                                        world.chunk[cx, cy, cz].voxel[x, y, z].backRightVertex = dataFloat[z * 4 + 1];
                                        world.chunk[cx, cy, cz].voxel[x, y, z].frontRightVertex = dataFloat[z * 4 + 2];
                                        world.chunk[cx, cy, cz].voxel[x, y, z].frontLeftVertex = dataFloat[z * 4 + 3];
                                    }
                                }   // for lop z end
                            }   // for lop y end
                }   // for loop cz end, end of chunk

        // Reset world
        foreach (ChunkGenerator chunk in world.chunk)
        {
            chunk.BuildChunkVertices(world);
            chunk.BuildChunkMesh();
        }
    }
}
