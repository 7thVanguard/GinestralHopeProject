using UnityEngine;
using System.Collections;

public class EventsToolManager
{
    public static void Remove(World world, Player player, MainCamera mainCamera)
    {
        if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.CHANGECHUNKSIZE)
        {
                if (mainCamera.raycast.point.x > (Global.world.chunkNumber.x - 1) * Global.world.chunkSize.x)
                    ReSizeWorldDown(world, 1, 0);
                else if (mainCamera.raycast.point.z > (Global.world.chunkNumber.z - 1) * Global.world.chunkSize.z)
                    ReSizeWorldDown(world, 0, 1);
        }
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.EVENT)
        {
        Vector3 position;

            if (mainCamera.raycast.normal.y > 0.75f)
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, mainCamera.raycast.point.y + 0.5f, ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.y < -0.75f)
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, mainCamera.raycast.point.y - 0.5f, ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.x > 0.75f)
                position = new Vector3(mainCamera.raycast.point.x + 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.x < -0.75f)
                position = new Vector3(mainCamera.raycast.point.x - 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.z > 0.75f)
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), mainCamera.raycast.point.z + 0.5f);
            else
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), mainCamera.raycast.point.z - 0.5f);

            Event.Place(world, player, "none", position);
        }
        else if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.CHANGECHUNKSIZE)
        {
            if (mainCamera.raycast.point.x > (Global.world.chunkNumber.x - 1) * Global.world.chunkSize.x)
                ReSizeWorldUp(world, 1, 0);
            else if (mainCamera.raycast.point.z > (Global.world.chunkNumber.z - 1) * Global.world.chunkSize.z)
                ReSizeWorldUp(world, 0, 1);
        }
    }


    public static void Cancel()
    {
        
    }


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.CHANGECHUNKSIZE)
        {
            if (mainCamera.raycast.point.x > (Global.world.chunkNumber.x - 1) * Global.world.chunkSize.x)
            {
                HUD.cubeMarker.transform.position = new Vector3((Global.world.chunkNumber.x - 0.5f) * Global.world.chunkSize.x,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y / 2,
                                                                Global.world.chunkNumber.z * Global.world.chunkSize.z / 2);

                HUD.cubeMarker.transform.localScale = new Vector3(Global.world.chunkSize.x + 0.02f,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y + 0.02f,
                                                                Global.world.chunkNumber.z * Global.world.chunkSize.z + 0.02f);
            }
            else if (mainCamera.raycast.point.z > (Global.world.chunkNumber.z - 1) * Global.world.chunkSize.z)
            {
                HUD.cubeMarker.transform.position = new Vector3(Global.world.chunkNumber.x * Global.world.chunkSize.x / 2,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y / 2,
                                                                (Global.world.chunkNumber.z - 0.5f) * Global.world.chunkSize.z);

                HUD.cubeMarker.transform.localScale = new Vector3(Global.world.chunkNumber.x * Global.world.chunkSize.x + 0.02f,
                                                                 Global.world.chunkNumber.y * Global.world.chunkSize.y + 0.02f,
                                                                 Global.world.chunkSize.z + 0.02f);
            }
            else
            {
                HUD.cubeMarker.transform.position = new Vector3(0, -10000, 0);
            }
        }
        else
        {

        }
    }


    private static void ReSizeWorldUp(World world, int incrementX, int incrementZ)
    {
        Chunk[, ,] chunk = new Chunk[world.chunkNumber.x + incrementX, world.chunkNumber.y, world.chunkNumber.z + incrementZ];

        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                    chunk[cx, cy, cz] = world.chunk[cx, cy, cz];

        world.chunkNumber.x += incrementX;
        world.chunkNumber.z += incrementZ;
        world.Init();

        for (int cx = 0; cx < world.chunkNumber.x - incrementX; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z - incrementZ; cz++)
                    world.chunk[cx, cy, cz] = chunk[cx, cy, cz];

        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                    world.chunksToReset.Add(new IntVector3(cx, cy, cz));
    }


    private static void ReSizeWorldDown(World world, int decrementX, int decrementZ)
    {
        Chunk[, ,] chunk = new Chunk[world.chunkNumber.x - decrementX, world.chunkNumber.y, world.chunkNumber.z - decrementZ];

        for (int cx = 0; cx < world.chunkNumber.x - decrementX; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z - decrementZ; cz++)
                    chunk[cx, cy, cz] = world.chunk[cx, cy, cz];

        GameObject[] chunks = GameObject.FindGameObjectsWithTag("Chunk");
        foreach (GameObject chunkObj in chunks)
        {
            if (decrementX == 1)
            {
                if (chunkObj.name.Contains("(" + (world.chunkNumber.x - 1).ToString() + ", "))
                    GameObject.Destroy(chunkObj);
            }
            else if (decrementZ == 1)
            {
                if (chunkObj.name.Contains(", " + (world.chunkNumber.z - 1).ToString() + ")"))
                    GameObject.Destroy(chunkObj);
            }
        }

        world.chunkNumber.x -= decrementX;
        world.chunkNumber.z -= decrementZ;
        world.Init();

        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                    world.chunk[cx, cy, cz] = chunk[cx, cy, cz];

        for (int cx = 0; cx < world.chunkNumber.x; cx++)
            for (int cy = 0; cy < world.chunkNumber.y; cy++)
                for (int cz = 0; cz < world.chunkNumber.z; cz++)
                    world.chunksToReset.Add(new IntVector3(cx, cy, cz));
    }
}
