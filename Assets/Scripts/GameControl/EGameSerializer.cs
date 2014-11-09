using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public static class EGameSerializer
{
    private static string[] dataString;
    private static float[] dataFloat;

    public static void Save()
    {
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create("Assets/Saves/" + SWorld.saveName + ".save");

        //dataString = new string[SWorld.chunkSize.z];
        //dataFloat = new float[SWorld.chunkSize.z * 4];

        //Encryptor(bf, file);
        //file.Close();
    }


    public static void Load()
    {
        //if (File.Exists("Assets/Saves/" + SWorld.saveName + ".save"))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open("Assets/Saves/" + SWorld.saveName + ".save", FileMode.Open);

        //    dataString = new string[SWorld.chunkSize.z];
        //    dataFloat = new float[SWorld.chunkSize.z * 4];

        //    Desencrypter(bf, file);
        //    file.Close();
        //}
    }


    private static void Encryptor(BinaryFormatter bf, FileStream file)
    {
        //// Save SWorld
        //for (int cx = 0; cx < SWorld.chunkNumber.x; cx++)
        //    for (int cy = 0; cy < SWorld.chunkNumber.y; cy++)
        //        for (int cz = 0; cz < SWorld.chunkNumber.z; cz++)
        //        {
        //            if (!SWorld.chunk[cx, cy, cz].empty)
        //                for (int x = 0; x < SWorld.chunkSize.x; x++)
        //                    for (int y = 0; y < SWorld.chunkSize.x; y++)
        //                    {
        //                        for (int z = 0; z < SWorld.chunkSize.x; z++)
        //                        {
        //                            // We allocate all z information in two simple arrays
        //                            dataString[z] = SWorld.chunk[cx, cy, cz].voxel[x, y, z].hashName;
        //                            if (SWorld.chunk[cx, cy, cz].voxel[x, y, z].voxelType == VoxelGenerator.VoxelType.VTERRAIN)
        //                            {
        //                                dataFloat[z * 4] = SWorld.chunk[cx, cy, cz].voxel[x, y, z].backLeftVertex;
        //                                dataFloat[z * 4 + 1] = SWorld.chunk[cx, cy, cz].voxel[x, y, z].backRightVertex;
        //                                dataFloat[z * 4 + 2] = SWorld.chunk[cx, cy, cz].voxel[x, y, z].frontRightVertex;
        //                                dataFloat[z * 4 + 3] = SWorld.chunk[cx, cy, cz].voxel[x, y, z].frontLeftVertex;
        //                            }
        //                        }   // for lop z end

        //                        // Serialization of the arrays
        //                        bf.Serialize(file, dataString);
        //                        bf.Serialize(file, dataFloat);
        //                    }   // for lop y end
        //        }   // for loop cz end, end of chunk
    }


    private static void Desencrypter(BinaryFormatter bf, FileStream file)
    {
        //// Load world
        //for (int cx = 0; cx < SWorld.chunkNumber.x; cx++)
        //    for (int cy = 0; cy < SWorld.chunkNumber.y; cy++)
        //        for (int cz = 0; cz < SWorld.chunkNumber.z; cz++)
        //        {
        //            if (!SWorld.chunk[cx, cy, cz].empty)
        //                for (int x = 0; x < SWorld.chunkSize.x; x++)
        //                    for (int y = 0; y < SWorld.chunkSize.x; y++)
        //                    {
        //                        // Deserialization of the arrays first
        //                        dataString = (string[])bf.Deserialize(file);
        //                        dataFloat = (float[])bf.Deserialize(file);

        //                        for (int z = 0; z < SWorld.chunkSize.x; z++)
        //                        {
        //                            // We assign the variables to the voxels
        //                            SWorld.chunk[cx, cy, cz].voxel[x, y, z] = new VoxelGenerator(new IntVector3(x, y, z), new IntVector3(cx, cy, cz), dataString[z]);

        //                            if (SWorld.chunk[cx, cy, cz].voxel[x, y, z].voxelType == VoxelGenerator.VoxelType.VTERRAIN)
        //                            {
        //                                SWorld.chunk[cx, cy, cz].voxel[x, y, z].backLeftVertex = dataFloat[z * 4];
        //                                SWorld.chunk[cx, cy, cz].voxel[x, y, z].backRightVertex = dataFloat[z * 4 + 1];
        //                                SWorld.chunk[cx, cy, cz].voxel[x, y, z].frontRightVertex = dataFloat[z * 4 + 2];
        //                                SWorld.chunk[cx, cy, cz].voxel[x, y, z].frontLeftVertex = dataFloat[z * 4 + 3];
        //                            }
        //                        }   // for lop z end
        //                    }   // for lop y end
        //        }   // for loop cz end, end of chunk

        //// Reset world
        //UWorldGenerator.TotalReset();
    }
}
