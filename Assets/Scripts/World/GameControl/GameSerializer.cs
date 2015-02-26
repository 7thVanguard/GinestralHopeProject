using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public struct PlayerStruct
{
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float cameraObjective;
    public float cameraAngleSight;
    public bool unlockedSkillFireBall;
}


[System.Serializable]
public struct ChunkStruct
{
    public int chunkNumberX;
    public int chunkNumberY;
    public int chunkNumberZ;
    public int chunkSizeX;
    public int chunkSizeY;
    public int chunkSizeZ;
}


[System.Serializable]
public struct SunStruct
{
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    public float lightColorR;
    public float lightColorG;
    public float lightColorB;
    public float lightColorA;

    public float flareColorR;
    public float flareColorG;
    public float flareColorB;
    public float flareColorA;

    public float ambientLightColorR;
    public float ambientLightColorG;
    public float ambientLightColorB;
    public float ambientLightColorA;

    public float backGroundColorR;
    public float backGroundColorG;
    public float backGroundColorB;
    public float backGroundColorA;

    public float intensity;
}


[System.Serializable]
public struct VoxelStruct
{
    public string name;
    public int number;
}


[System.Serializable]
public struct EmitterStruct
{
    public float positionX;
    public float positionY;
    public float positionZ;
    public float intensity;
    public float range;
    public float r;
    public float g;
    public float b;
}


[System.Serializable]
public struct EnemyStruct
{
    public string ID;
    public float positionX;
    public float positionY;
    public float positionZ;
}


[System.Serializable]
public struct GeometryStruct
{
    public string ID;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public float scaleX;
    public float scaleY;
    public float scaleZ;
}


[System.Serializable]
public struct InteractiveStruct
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
public struct EventStruct
{
    public string ID;
    public float positionX;
    public float positionY;
    public float positionZ;
    public float colliderScaleX;
    public float colliderScaleY;
    public float colliderScaleZ;
}



[System.Serializable]
public class GameSerializer
{
    private PlayerStruct playerStructSave;
    private ChunkStruct chunkStructSave;
    private SunStruct sunStructSave;
    private VoxelStruct voxelStructSave;
    private EmitterStruct emitterStructSave;
    private GeometryStruct geometryStructSave;
    private InteractiveStruct interactiveStructSave;
    private EnemyStruct enemyStructSave;
    private EventStruct eventStructSave;


    private static List<VoxelStruct> VoxelSave;
    private static List<EmitterStruct> EmitterSave;
    private static List<GeometryStruct> GeometrySave;
    private static List<InteractiveStruct> InteractiveSave;
    private static List<EnemyStruct> EnemySave;
    private static List<EventStruct> EventSave;

    // Voxel RLE Compression related
    private static string actualName;
    private static int actualNumber;


    public void Save(World world, Player player, string saveName)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("Assets/Saves/" + saveName + ".save");

        actualNumber = 1;

        VoxelSave = new List<VoxelStruct>();
        EmitterSave = new List<EmitterStruct>();
        GeometrySave = new List<GeometryStruct>();
        InteractiveSave = new List<InteractiveStruct>();
        EnemySave = new List<EnemyStruct>();
        EventSave = new List<EventStruct>();

        Encryptor(world, player, bf, file);
        file.Close();
    }


    public void Load(World world, Player player, string saveName)
    {
        if (File.Exists("Assets/Saves/" + saveName + ".save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("Assets/Saves/" + saveName + ".save", FileMode.Open);

            actualNumber = 1;

            VoxelSave = new List<VoxelStruct>();
            EmitterSave = new List<EmitterStruct>();
            GeometrySave = new List<GeometryStruct>();
            InteractiveSave = new List<InteractiveStruct>();
            EnemySave = new List<EnemyStruct>();
            EventSave = new List<EventStruct>();

            Desencrypter(world, player, bf, file);
            file.Close();

            // Music
            GameMusic.SelectClips(saveName);
            Global.player.playerObj.transform.FindChild("MusicPlayer").audio.volume = 0;
            GameMusic.fadingIn = true;

            // Orbs
            Global.player.orbsCollected = 0;
        }
    }


    private void Encryptor(World world, Player player, BinaryFormatter bf, FileStream file)
    {
        //+ Player
        // Find all players in game
        GameObject playerOnGame = GameObject.FindGameObjectWithTag("Player");

        playerStructSave.positionX = playerOnGame.transform.position.x;
        playerStructSave.positionY = playerOnGame.transform.position.y + 0.05f;
        playerStructSave.positionZ = playerOnGame.transform.position.z;
        playerStructSave.rotationX = playerOnGame.transform.eulerAngles.x;
        playerStructSave.rotationY = playerOnGame.transform.eulerAngles.y;
        playerStructSave.rotationZ = playerOnGame.transform.eulerAngles.z;
        playerStructSave.cameraObjective = Global.mainCamera.objectivePosition;
        playerStructSave.cameraAngleSight = Global.mainCamera.angleSight;
        playerStructSave.unlockedSkillFireBall = player.unlockedSkillFireBall;

        bf.Serialize(file, playerStructSave);


        //+ Chunks
        chunkStructSave.chunkNumberX = world.chunkNumber.x;
        chunkStructSave.chunkNumberY = world.chunkNumber.y;
        chunkStructSave.chunkNumberZ = world.chunkNumber.z;
        chunkStructSave.chunkSizeX = world.chunkSize.x;
        chunkStructSave.chunkSizeY = world.chunkSize.y;
        chunkStructSave.chunkSizeZ = world.chunkSize.z;

        bf.Serialize(file, chunkStructSave);

        //+ Sun
        sunStructSave.positionX = Global.sun.sunObj.transform.position.x;
        sunStructSave.positionY = Global.sun.sunObj.transform.position.y;
        sunStructSave.positionZ = Global.sun.sunObj.transform.position.z;
        sunStructSave.rotationX = Global.sun.sunObj.transform.eulerAngles.x;
        sunStructSave.rotationY = Global.sun.sunObj.transform.eulerAngles.y;
        sunStructSave.rotationZ = Global.sun.sunObj.transform.eulerAngles.z;

        sunStructSave.lightColorR = Global.sun.light.color.r;
        sunStructSave.lightColorG = Global.sun.light.color.g;
        sunStructSave.lightColorB = Global.sun.light.color.b;
        sunStructSave.lightColorA = Global.sun.light.color.a;

        sunStructSave.flareColorR = Global.sun.lensFlare.color.r;
        sunStructSave.flareColorG = Global.sun.lensFlare.color.g;
        sunStructSave.flareColorB = Global.sun.lensFlare.color.b;
        sunStructSave.flareColorA = Global.sun.lensFlare.color.a;

        sunStructSave.ambientLightColorR = RenderSettings.ambientLight.r;
        sunStructSave.ambientLightColorG = RenderSettings.ambientLight.g;
        sunStructSave.ambientLightColorB = RenderSettings.ambientLight.b;
        sunStructSave.ambientLightColorA = RenderSettings.ambientLight.a;

        sunStructSave.backGroundColorR = Camera.main.backgroundColor.r;
        sunStructSave.backGroundColorG = Camera.main.backgroundColor.g;
        sunStructSave.backGroundColorB = Camera.main.backgroundColor.b;
        sunStructSave.backGroundColorA = Camera.main.backgroundColor.a;

        sunStructSave.intensity = Global.sun.light.intensity;
        bf.Serialize(file, sunStructSave);

        //+ Voxels
        bool firstVoxel = true;

        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                    if (!world.chunk[cx, cy, cz].empty)
                        for (int x = 0; x < world.chunkSize.x; x++)
                            for (int y = 0; y < world.chunkSize.y; y++)
                                for (int z = 0; z < world.chunkSize.z; z++)
                                {
                                    if (firstVoxel)
                                    {
                                        firstVoxel = false;
                                        actualName = world.chunk[cx, cy, cz].voxel[x, y, z].ID;
                                    }
                                    else
                                    {
                                        if (actualName == world.chunk[cx, cy, cz].voxel[x, y, z].ID)
                                            actualNumber++;
                                        else
                                        {
                                            voxelStructSave.name = actualName;
                                            voxelStructSave.number = actualNumber;
                                            VoxelSave.Add(voxelStructSave);

                                            actualNumber = 1;
                                            actualName = world.chunk[cx, cy, cz].voxel[x, y, z].ID;
                                        }
                                    }
                                }

        // The last struct is not detected in the loop
        voxelStructSave.name = actualName;
        voxelStructSave.number = actualNumber;
        VoxelSave.Add(voxelStructSave);

        // Serialization of the lists
        bf.Serialize(file, VoxelSave);
        VoxelSave.Clear();


        //+ Emitters
        // Find all emiters in game
        GameObject[] emittersInGame = GameObject.FindGameObjectsWithTag("Emiter");

        foreach (GameObject emitterObj in emittersInGame)
        {
            emitterStructSave.positionX = emitterObj.transform.position.x;
            emitterStructSave.positionY = emitterObj.transform.position.y;
            emitterStructSave.positionZ = emitterObj.transform.position.z;
            emitterStructSave.intensity = emitterObj.light.intensity;
            emitterStructSave.range = emitterObj.light.range;
            emitterStructSave.r = emitterObj.light.color.r;
            emitterStructSave.g = emitterObj.light.color.g;
            emitterStructSave.b = emitterObj.light.color.b;
            EmitterSave.Add(emitterStructSave);
        }
        bf.Serialize(file, EmitterSave);
        EmitterSave.Clear();


        //+ Geometry
        // Find all geometries in game
        GameObject[] geometryInGame = GameObject.FindGameObjectsWithTag("Geometry");

        foreach (GameObject geometry in geometryInGame)
        {
            geometryStructSave.ID = geometry.name;
            geometryStructSave.positionX = geometry.transform.position.x;
            geometryStructSave.positionY = geometry.transform.position.y;
            geometryStructSave.positionZ = geometry.transform.position.z;
            geometryStructSave.rotationX = geometry.transform.eulerAngles.x;
            geometryStructSave.rotationY = geometry.transform.eulerAngles.y;
            geometryStructSave.rotationZ = geometry.transform.eulerAngles.z;
            geometryStructSave.scaleX = geometry.transform.localScale.x;
            geometryStructSave.scaleY = geometry.transform.localScale.y;
            geometryStructSave.scaleZ = geometry.transform.localScale.z;
            GeometrySave.Add(geometryStructSave);
        }
        bf.Serialize(file, GeometrySave);
        GeometrySave.Clear();


        //+ Interactives
        // Find all interactives in game
        GameObject[] interactivesInGame = GameObject.FindGameObjectsWithTag("Interactive");

        foreach (GameObject interactive in interactivesInGame)
        {
            interactiveStructSave.ID = interactive.name;
            interactiveStructSave.positionX = interactive.transform.position.x;
            interactiveStructSave.positionY = interactive.transform.position.y;
            interactiveStructSave.positionZ = interactive.transform.position.z;
            interactiveStructSave.rotationX = interactive.transform.eulerAngles.x;
            interactiveStructSave.rotationY = interactive.transform.eulerAngles.y;
            interactiveStructSave.rotationZ = interactive.transform.eulerAngles.z;
            InteractiveSave.Add(interactiveStructSave);
        }
        bf.Serialize(file, InteractiveSave);
        InteractiveSave.Clear();


        //+ Enemies
        // Find all enemies in game
        GameObject[] enemiesInGame = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemiesInGame)
        {
            enemyStructSave.ID = enemy.name;
            enemyStructSave.positionX = enemy.transform.position.x;
            enemyStructSave.positionY = enemy.transform.position.y;
            enemyStructSave.positionZ = enemy.transform.position.z;
            EnemySave.Add(enemyStructSave);
        }
        bf.Serialize(file, EnemySave);
        EnemySave.Clear();


        //+ Events
        // Find all events in game
        GameObject[] eventsInGame = GameObject.FindGameObjectsWithTag("Event");

        foreach (GameObject eventObj in eventsInGame)
        {
            eventStructSave.ID = eventObj.name;
            eventStructSave.positionX = eventObj.transform.position.x;
            eventStructSave.positionY = eventObj.transform.position.y;
            eventStructSave.positionZ = eventObj.transform.position.z;
            eventStructSave.colliderScaleX = eventObj.GetComponent<BoxCollider>().size.x;
            eventStructSave.colliderScaleY = eventObj.GetComponent<BoxCollider>().size.y;
            eventStructSave.colliderScaleZ = eventObj.GetComponent<BoxCollider>().size.z;
            EventSave.Add(eventStructSave);
        }
        bf.Serialize(file, EventSave);
        EventSave.Clear();
    }


    private void Desencrypter(World world, Player player, BinaryFormatter bf, FileStream file)
    {
        //+ Player
        // Deserialize the players
        playerStructSave = (PlayerStruct)bf.Deserialize(file);

        GameObject playerOnGame = GameObject.FindGameObjectWithTag("Player");

        playerOnGame.transform.position = new Vector3(playerStructSave.positionX, playerStructSave.positionY, playerStructSave.positionZ);
        playerOnGame.transform.eulerAngles = new Vector3(playerStructSave.rotationX, playerStructSave.rotationY, playerStructSave.rotationZ);
        player.unlockedSkillFireBall = playerStructSave.unlockedSkillFireBall;


        //+ Chunks
        // Deserialize the chunk struct
        chunkStructSave = (ChunkStruct)bf.Deserialize(file);
        // ------------------------------------------------------------------------------- Converter
        if (world.chunkNumber.x != chunkStructSave.chunkNumberX || world.chunkSize.x != chunkStructSave.chunkSizeX ||
            world.chunkNumber.y != chunkStructSave.chunkNumberY || world.chunkSize.y != chunkStructSave.chunkSizeY ||
            world.chunkNumber.z != chunkStructSave.chunkNumberZ || world.chunkSize.z != chunkStructSave.chunkSizeZ)
        {
            world.chunkNumber.x = chunkStructSave.chunkNumberX;
            world.chunkNumber.y = chunkStructSave.chunkNumberY;
            world.chunkNumber.z = chunkStructSave.chunkNumberZ;
            world.chunkSize.x = chunkStructSave.chunkSizeX;
            world.chunkSize.y = chunkStructSave.chunkSizeY;
            world.chunkSize.z = chunkStructSave.chunkSizeZ;

            // Destroy existing chunks
            GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
            foreach (GameObject chunkObj in chunks)
                GameObject.Destroy(chunkObj);

            // Reset the world
            world.Init();
        }


        //+ Sun
        sunStructSave = (SunStruct)bf.Deserialize(file);

        Global.sun.sunObj.transform.position = new Vector3(sunStructSave.positionX, sunStructSave.positionY, sunStructSave.positionZ);
        Global.sun.sunObj.transform.eulerAngles = new Vector3(sunStructSave.rotationX, sunStructSave.rotationY, sunStructSave.rotationZ);

        Global.sun.light.color = new Color(sunStructSave.lightColorR, sunStructSave.lightColorG, sunStructSave.lightColorB, sunStructSave.lightColorA);
        Global.sun.lensFlare.color = new Color(sunStructSave.flareColorR, sunStructSave.flareColorG, sunStructSave.flareColorB, sunStructSave.flareColorA);
        RenderSettings.ambientLight = new Color(sunStructSave.ambientLightColorR, sunStructSave.ambientLightColorG, sunStructSave.ambientLightColorB, sunStructSave.ambientLightColorA);
        Camera.main.backgroundColor = new Color(sunStructSave.backGroundColorR, sunStructSave.backGroundColorG, sunStructSave.backGroundColorB, sunStructSave.backGroundColorA);

        Global.sun.light.intensity = sunStructSave.intensity;

        //+ Voxels
        // Deserialize the voxels list
        VoxelSave = (List<VoxelStruct>)bf.Deserialize(file);

        int listPosition = -1;
        int downCounter = 0;

        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                    if (!world.chunk[cx, cy, cz].empty)
                        for (int x = 0; x < world.chunkSize.x; x++)
                            for (int y = 0; y < world.chunkSize.y; y++)
                                for (int z = 0; z < world.chunkSize.z; z++)
                                {
                                    if (downCounter > 0)
                                    {
                                        //string name;

                                        //if (VoxelSave[listPosition].name == "(0, 7)")
                                        //    name = "(0, 0)";
                                        //else if (VoxelSave[listPosition].name == "(1, 6)")
                                        //    name = "(2, 0)";
                                        //else
                                        //    name = VoxelSave[listPosition].name;

                                        world.chunk[cx, cy, cz].voxel[x, y, z] =
                                            new Voxel(world, new IntVector3(x, y, z), new IntVector3(cx, cy, cz), VoxelSave[listPosition].name);

                                        downCounter--;
                                    }
                                    else
                                    {
                                        listPosition++;
                                        downCounter = VoxelSave[listPosition].number - 1;

                                        //string name;

                                        //if (VoxelSave[listPosition].name == "(0, 7)")
                                        //    name = "(0, 0)";
                                        //else if (VoxelSave[listPosition].name == "(1, 6)")
                                        //    name = "(2, 0)";
                                        //else
                                        //    name = VoxelSave[listPosition].name;

                                        world.chunk[cx, cy, cz].voxel[x, y, z] =
                                            new Voxel(world, new IntVector3(x, y, z), new IntVector3(cx, cy, cz), VoxelSave[listPosition].name);
                                    }
                                }


        VoxelSave.Clear();

        // Reset voxels
        foreach (Chunk chunk in world.chunk)
        {
            chunk.BuildChunkVertices(world);
            chunk.BuildChunkMesh();
        }


        //+ Emitters
        // Deserialize the emiters list
        EmitterSave = (List<EmitterStruct>)bf.Deserialize(file);

        // Destroy existing emiters
        GameObject[] emitters = GameObject.FindGameObjectsWithTag("Emiter");
        foreach (GameObject emitterObj in emitters)
            GameObject.Destroy(emitterObj);

        // Load emiters
        foreach (EmitterStruct emitterObj in EmitterSave)
            Emiter.Place(world, new Vector3(emitterObj.positionX, emitterObj.positionY, emitterObj.positionZ),
                                    emitterObj.intensity, emitterObj.range, emitterObj.r, emitterObj.g, emitterObj.b);

        // Reset emiters list
        EmitterSave.Clear();


        //+ Geometry
        // Deserialize the geometry list
        GeometrySave = (List<GeometryStruct>)bf.Deserialize(file);

        // Destroy existing gadgets
        GameObject[] geometries = GameObject.FindGameObjectsWithTag("Geometry");
        foreach (GameObject geometry in geometries)
            GameObject.Destroy(geometry);

        // Load gadgets
        foreach (GeometryStruct geometry in GeometrySave)
            Geometry.Place(geometry.ID, new Vector3(geometry.positionX, geometry.positionY, geometry.positionZ),
                                        new Vector3(geometry.rotationX, geometry.rotationY, geometry.rotationZ),
                                        new Vector3(geometry.scaleX, geometry.scaleY, geometry.scaleZ));

        //Reset gadgets list
        GeometrySave.Clear();


        //+ Interactives
        // Deserialize the interactives list
        InteractiveSave = (List<InteractiveStruct>)bf.Deserialize(file);

        // Destroy existing interactives
        GameObject[] interactives = GameObject.FindGameObjectsWithTag("Interactive");
        foreach (GameObject interactive in interactives)
            GameObject.Destroy(interactive);

        // Load interactives
        foreach (InteractiveStruct interactive in InteractiveSave)
            Interactive.Dictionary[interactive.ID].Place(interactive.ID,
                new Vector3(interactive.positionX, interactive.positionY, interactive.positionZ),
                new Vector3(interactive.rotationX, interactive.rotationY, interactive.rotationZ), false);


        //Reset interactives list
        InteractiveSave.Clear();


        //+ Enemies
        // Deserialize the enemies list
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


        //+ Events
        // Deserialize the events list
        EventSave = (List<EventStruct>)bf.Deserialize(file);

        // Destroy existing events
        GameObject[] events = GameObject.FindGameObjectsWithTag("Event");
        foreach (GameObject eventObj in events)
            GameObject.Destroy(eventObj);

        // Load events
        foreach (EventStruct eventObj in EventSave)
            Event.Place(world, player, eventObj.ID, new Vector3(eventObj.positionX, eventObj.positionY, eventObj.positionZ),
                                                    new Vector3(eventObj.colliderScaleX, eventObj.colliderScaleY, eventObj.colliderScaleZ));

        // Reset events list
        EventSave.Clear();

        // Destroy existing emiters
        GameObject[] creations = GameObject.FindGameObjectsWithTag("Creation");
        foreach (GameObject creation in creations)
            GameObject.Destroy(creation);
    }
}
