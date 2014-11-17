using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public struct EnemyStruct
{
    public string ID;
    public float positionX;
    public float positionY;
    public float positionZ;
}


[System.Serializable]
public struct GadgetStruct
{
    public string ID;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
}


[System.Serializable]
public class EGameSerializer
{
    
    private EnemyStruct enemyStruct;
    private GadgetStruct gadgetStruct;

    private static List<EnemyStruct> EnemySave;
    private static List<GadgetStruct> GadgetSave;
    private static string[] dataString;


    public void Save(World world, string saveName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Assets/Saves/" + saveName + ".save");

        dataString = new string[world.chunkSize.z];

        EnemySave = new List<EnemyStruct>();
        GadgetSave = new List<GadgetStruct>();

        Encryptor(world, bf, file);
        file.Close();
    }


    public void Load(World world, Player player, MainCamera mainCamera, string saveName)
    {
        if (File.Exists("Assets/Saves/" + saveName + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Assets/Saves/" + saveName + ".save", FileMode.Open);

            dataString = new string[world.chunkSize.z];

            EnemySave = new List<EnemyStruct>();
            GadgetSave = new List<GadgetStruct>();

            Desencrypter(world, player, mainCamera, bf, file);
            file.Close();
        }
    }


    private void Encryptor(World world, BinaryFormatter bf, FileStream file)
    {
        //+ Voxels
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
                                    dataString[z] = world.chunk[cx, cy, cz].voxel[x, y, z].ID;
                                }
                                // Serialization of the arrays
                                bf.Serialize(file, dataString);
                            }
                }


        //+ Enemies
        // Find all enemies in game
        GameObject[] enemiesInGame = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemiesInGame)
        {
            enemyStruct.ID = enemy.name;
            enemyStruct.positionX = enemy.transform.position.x;
            enemyStruct.positionY = enemy.transform.position.y;
            enemyStruct.positionZ = enemy.transform.position.z;
            EnemySave.Add(enemyStruct);
        }
        bf.Serialize(file, EnemySave);


        //+ Gadgets
        // Find all gadgets in game
        GameObject[] gadgetsInGame = GameObject.FindGameObjectsWithTag("Gadget");

        foreach (GameObject gadget in gadgetsInGame)
        {
            gadgetStruct.ID = gadget.name;
            gadgetStruct.positionX = gadget.transform.position.x;
            gadgetStruct.positionY = gadget.transform.position.y;
            gadgetStruct.positionZ = gadget.transform.position.z;
            gadgetStruct.rotationX = gadget.transform.eulerAngles.x;
            gadgetStruct.rotationY = gadget.transform.eulerAngles.y;
            gadgetStruct.rotationZ = gadget.transform.eulerAngles.z;
            GadgetSave.Add(gadgetStruct);
        }
        bf.Serialize(file, GadgetSave);
    }


    private void Desencrypter(World world, Player player, MainCamera mainCamera, BinaryFormatter bf, FileStream file)
    {
        //+ Voxels
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

                                for (int z = 0; z < world.chunkSize.x; z++)
                                {
                                    world.chunk[cx, cy, cz].voxel[x, y, z] =
                                        new Voxel(world, new IntVector3(x, y, z), new IntVector3(cx, cy, cz), dataString[z]);
                                }
                            } 
                } 

        // Reset voxels
        foreach (ChunkGenerator chunk in world.chunk)
        {
            chunk.BuildChunkVertices(world);
            chunk.BuildChunkMesh();
        }


        //+ Enemies
        // Deserialize the enemies listlist
        EnemySave = (List<EnemyStruct>)bf.Deserialize(file);

        // Destroy existing enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
        
        // Load enemies
        foreach (EnemyStruct enemy in EnemySave)
            Enemy.Dictionary[enemy.ID]
                .Place(new Vector3(enemy.positionX - 0.5f, enemy.positionY, enemy.positionZ - 0.5f));

        // Reset enemies list
        EnemySave.Clear();


        //+ Gadgets
        // Deserialize the gadgets listlist
        GadgetSave = (List<GadgetStruct>)bf.Deserialize(file);

        // Destroy existing enemies
        GameObject[] gadgets = GameObject.FindGameObjectsWithTag("Gadget");
        foreach (GameObject gadget in gadgets)
            GameObject.Destroy(gadget);

        // Load enemies
        foreach (GadgetStruct gadget in GadgetSave)
            Gadget.Dictionary[gadget.ID].Place(gadget.ID, 
                new Vector3(gadget.positionX, gadget.positionY, gadget.positionZ), new Vector3(gadget.rotationX, gadget.rotationY, gadget.rotationZ));

        //Reset enemies list
        GadgetSave.Clear();
    }
}
