using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum VoxelState { SOLID, FLUID, GAS }
public enum VoxelType { TERRAIN, ORGANIC, CUBIC, FLUID, AIR }

public struct VoxelData
{
    public VoxelState state;
    public VoxelType type;

    public string name;

    public Vector2 topUVBegin;
    public Vector2 rightUVBegin;
    public Vector2 frontUVBegin;
    public Vector2 leftUVBegin;
    public Vector2 backUVBegin;
    public Vector2 botUVBegin;

    public bool topTransparent;
    public bool rightTransparent;
    public bool frontTransparent;
    public bool leftTransparent;
    public bool backTransparent;
    public bool botTransparent;

    public int blastResistance;
    public Texture2D icon;
}


public class VoxelsList
{
    public static Dictionary<string, VoxelData> dictionary = new Dictionary<string, VoxelData>();
    public static VoxelData selectedVoxel;

	//Order: Top / Right / Front / Left / Back / Bot
    public static void Init()
    {
        //Dirt
		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(0, 0)",
		                          0, 7, false, 0, 7, false, 0, 7, false,
		                          0, 7, false, 0, 7, false, 0, 7, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Rock
        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(1, 0)",
		                          0, 3, false, 0, 3, false, 0, 3, false,
                                    0, 3, false, 0, 3, false, 0, 3, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Grass
        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(2, 0)",
                                    1, 6, false, 1, 5, false, 1, 5, false,
                                    1, 5, false, 1, 5, false, 1, 7, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Gravel
        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(3, 0)",
                                    0, 3, false, 0, 3, false, 0, 3, false, 
                                    0, 3, false, 0, 3, false, 0, 3, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

		//StoneBrick
		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(4, 0)",
		                          4, 6, false, 4, 6, false, 4, 6, false,
		                          4, 6, false, 4, 6, false, 4, 6, false,
		                          10);
		dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Wood Column
		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.CUBIC, "(5, 0)",
		                          3, 1, false, 3, 1, false, 3, 1, false,
		                          3, 1, false, 3, 1, false, 3, 1, false,
		                          10);
		dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Wood Column Base
		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(6, 0)",
		                          3, 0, false, 3, 0, false, 3, 0, false,
		                          3, 0, false, 3, 0, false, 3, 0, false,
		                          10);
		dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Tiles Brown
		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(7, 0)",
		                          6, 6, false, 6, 6, false, 6, 6, false,
		                          6, 6, false, 6, 6, false, 6, 6, false,
		                          10);
		dictionary.Add(selectedVoxel.name, selectedVoxel);

		//Tiles Grey
		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(0, 1)",
		                          6, 7, false, 6, 7, false, 6, 7, false,
		                          6, 7, false, 6, 7, false, 6, 7, false,
		                          10);
		dictionary.Add(selectedVoxel.name, selectedVoxel);

		selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(1, 1)",
		                          4, 6, false, 4, 6, false, 4, 6, false,
		                          4, 6, false, 4, 6, false, 4, 6, false,
		                          10);
		dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(2, 1)",
                                  3, 7, false, 0, 3, false, 0, 3, false,
                                  0, 3, false, 0, 3, false, 0, 3, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.CUBIC, "(3, 1)",
                                  1, 4, false, 1, 4, false, 1, 4, false,
                                  1, 4, false, 1, 4, false, 1, 4, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.CUBIC, "(4, 1)",
                                  2, 4, false, 2, 4, false, 2, 4, false,
                                  2, 4, false, 2, 4, false, 2, 4, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.CUBIC, "(5, 1)",
                                  3, 4, false, 3, 4, false, 3, 4, false,
                                  3, 4, false, 3, 4, false, 3, 4, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(6, 1)",
                                  4, 4, false, 4, 4, false, 4, 4, false,
                                  4, 4, false, 4, 4, false, 4, 4, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(7, 1)",
                                  3, 6, false, 0, 3, false, 0, 3, false,
                                  0, 3, false, 0, 3, false, 0, 3, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);
    }


    public static void PostInit(World world, MainCamera mainCamera)
    {
        List<Vector3> Vertices = new List<Vector3>();
        List<Vector2> UV = new List<Vector2>();
        List<int> Triangles = new List<int>();

        int actualVoxel = 0;
        int vertexCount = 0;

        foreach(KeyValuePair<string, VoxelData> entry in dictionary)
        {
            SetVertices(Vertices, new Vector2(((actualVoxel + 0) % 8) * 1.3f, ((int)((actualVoxel + 0) / 8)) * 1.2f));
            SetUV(world, UV, entry);
            SetTriangles(Triangles, vertexCount);

            vertexCount += 24;
            actualVoxel++;
        }
        CreateMesh(mainCamera, Vertices, UV, Triangles);
    }


    private static VoxelData InitVoxel(VoxelState state, VoxelType type, string name,
                                        int topX, float topY, bool topTrans, float rightX, float rightY, bool rightTrans,
                                        float frontX, float frontY, bool frontTrans, float leftX, float leftY, bool leftTrans,
                                        float backX, float backY, bool backTrans, float botX, float botY, bool botTrans,
                                        int blastResis)
    {
        VoxelData voxel = new VoxelData();

        voxel.state = state;
        voxel.type = type;

        voxel.name = name;

        voxel.topUVBegin.x = topX * 0.125f;
        voxel.topUVBegin.y = topY * 0.125f;

        voxel.rightUVBegin.x = rightX * 0.125f;
        voxel.rightUVBegin.y = rightY * 0.125f;

        voxel.frontUVBegin.x = frontX * 0.125f;
        voxel.frontUVBegin.y = frontY * 0.125f;

        voxel.leftUVBegin.x = leftX * 0.125f;
        voxel.leftUVBegin.y = leftY * 0.125f;

        voxel.backUVBegin.x = backX * 0.125f;
        voxel.backUVBegin.y = backY * 0.125f;

        voxel.botUVBegin.x = botX * 0.125f;
        voxel.botUVBegin.y = botY * 0.125f;

        voxel.topTransparent = topTrans;
        voxel.rightTransparent = rightTrans;
        voxel.frontTransparent = frontTrans;
        voxel.leftTransparent = leftTrans;
        voxel.backTransparent = backTrans;
        voxel.botTransparent = botTrans;

        voxel.blastResistance = blastResis;

        return voxel;
    }


    private static void SetVertices(List<Vector3> Vertices, Vector2 displacement)
    {
        // Top
        Vertices.Add(new Vector3(0.5f + displacement.x, 0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, 0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, 0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, 0.5f + displacement.y, -0.5f));

        // Front
        Vertices.Add(new Vector3(0.5f + displacement.x, -0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, 0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, 0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, -0.5f + displacement.y, -0.5f));

        // Right
        Vertices.Add(new Vector3(0.5f + displacement.x, -0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, 0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, 0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, -0.5f + displacement.y, -0.5f));

        // Back
        Vertices.Add(new Vector3(-0.5f + displacement.x, -0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, 0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, 0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, -0.5f + displacement.y, 0.5f));

        // Left
        Vertices.Add(new Vector3(-0.5f + displacement.x, -0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, 0.5f + displacement.y, - 0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, 0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, -0.5f + displacement.y, 0.5f));

        // Bot
        Vertices.Add(new Vector3(0.5f + displacement.x, -0.5f + displacement.y, 0.5f));
        Vertices.Add(new Vector3(0.5f + displacement.x, -0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, -0.5f + displacement.y, -0.5f));
        Vertices.Add(new Vector3(-0.5f + displacement.x, -0.5f + displacement.y, 0.5f));
    }


    private static void SetUV(World world, List<Vector2> UV, KeyValuePair<string, VoxelData> entry)
    {
        // Top
        UV.Add(new Vector2(entry.Value.topUVBegin.x, entry.Value.topUVBegin.y));
        UV.Add(new Vector2(entry.Value.topUVBegin.x, entry.Value.topUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.topUVBegin.x + world.textureSize, entry.Value.topUVBegin.y  + world.textureSize));
        UV.Add(new Vector2(entry.Value.topUVBegin.x + world.textureSize, entry.Value.topUVBegin.y));

        // Front
        UV.Add(new Vector2(entry.Value.frontUVBegin.x, entry.Value.frontUVBegin.y));
        UV.Add(new Vector2(entry.Value.frontUVBegin.x, entry.Value.frontUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.frontUVBegin.x + world.textureSize, entry.Value.frontUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.frontUVBegin.x + world.textureSize, entry.Value.frontUVBegin.y));

        // Right
        UV.Add(new Vector2(entry.Value.rightUVBegin.x, entry.Value.rightUVBegin.y));
        UV.Add(new Vector2(entry.Value.rightUVBegin.x, entry.Value.rightUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.rightUVBegin.x + world.textureSize, entry.Value.rightUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.rightUVBegin.x + world.textureSize, entry.Value.rightUVBegin.y));

        // Back
        UV.Add(new Vector2(entry.Value.backUVBegin.x, entry.Value.backUVBegin.y));
        UV.Add(new Vector2(entry.Value.backUVBegin.x, entry.Value.backUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.backUVBegin.x + world.textureSize, entry.Value.backUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.backUVBegin.x + world.textureSize, entry.Value.backUVBegin.y));

        // Left
        UV.Add(new Vector2(entry.Value.leftUVBegin.x, entry.Value.leftUVBegin.y));
        UV.Add(new Vector2(entry.Value.leftUVBegin.x, entry.Value.leftUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.leftUVBegin.x + world.textureSize, entry.Value.leftUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.leftUVBegin.x + world.textureSize, entry.Value.leftUVBegin.y));

        // Bot
        UV.Add(new Vector2(entry.Value.botUVBegin.x, entry.Value.botUVBegin.y));
        UV.Add(new Vector2(entry.Value.botUVBegin.x, entry.Value.botUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.botUVBegin.x + world.textureSize, entry.Value.botUVBegin.y + world.textureSize));
        UV.Add(new Vector2(entry.Value.botUVBegin.x + world.textureSize, entry.Value.botUVBegin.y));
    }


    private static void SetTriangles(List<int> Triangles, int vertexCount)
    {
        Triangles.Add(vertexCount + 0);
        Triangles.Add(vertexCount + 2);
        Triangles.Add(vertexCount + 1);

        Triangles.Add(vertexCount + 0);
        Triangles.Add(vertexCount + 3);
        Triangles.Add(vertexCount + 2);


        Triangles.Add(vertexCount + 4);
        Triangles.Add(vertexCount + 6);
        Triangles.Add(vertexCount + 5);

        Triangles.Add(vertexCount + 4);
        Triangles.Add(vertexCount + 7);
        Triangles.Add(vertexCount + 6);


        Triangles.Add(vertexCount + 8);
        Triangles.Add(vertexCount + 10);
        Triangles.Add(vertexCount + 9);

        Triangles.Add(vertexCount + 8);
        Triangles.Add(vertexCount + 11);
        Triangles.Add(vertexCount + 10);


        Triangles.Add(vertexCount + 12);
        Triangles.Add(vertexCount + 14);
        Triangles.Add(vertexCount + 13);

        Triangles.Add(vertexCount + 12);
        Triangles.Add(vertexCount + 15);
        Triangles.Add(vertexCount + 14);


        Triangles.Add(vertexCount + 16);
        Triangles.Add(vertexCount + 18);
        Triangles.Add(vertexCount + 17);

        Triangles.Add(vertexCount + 16);
        Triangles.Add(vertexCount + 19);
        Triangles.Add(vertexCount + 18);


        Triangles.Add(vertexCount + 20);
        Triangles.Add(vertexCount + 22);
        Triangles.Add(vertexCount + 21);

        Triangles.Add(vertexCount + 20);
        Triangles.Add(vertexCount + 23);
        Triangles.Add(vertexCount + 22);
    }


    private static void CreateMesh(MainCamera mainCamera, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles)
    {
        GameObject voxels = new GameObject();

        voxels.AddComponent<MeshRenderer>();

        // Create arrays with the information of the lists
        Vector3[] verticesVector = new Vector3[Vertices.Count];
        Vector2[] UVVecor = new Vector2[UV.Count];
        int[] trianglesVector = new int[Triangles.Count];


        // Assign vertices
        for (int i = 0; i < Vertices.Count; i++)
        {
            verticesVector[i] = Vertices[i];
            UVVecor[i] = UV[i];
        }
        // Assign triangles
        for (int i = 0; i < Triangles.Count; i++)
            trianglesVector[i] = Triangles[i];


        // Clear the lists
        Vertices.Clear();
        UV.Clear();
        Triangles.Clear();

        // Make sure there is a MeshFilter
        if (voxels.GetComponent<MeshFilter>() == null)
            voxels.AddComponent<MeshFilter>();
        else
            voxels.GetComponent<MeshFilter>().mesh.Clear();

        // Assign the information in the arrays to the mesh
        voxels.GetComponent<MeshFilter>().mesh.vertices = verticesVector;
        voxels.GetComponent<MeshFilter>().mesh.uv = UVVecor;
        voxels.GetComponent<MeshFilter>().mesh.triangles = trianglesVector;

        voxels.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        // Material
        voxels.renderer.material = (Material)Resources.Load("Generic Materials/DefaultUnlitMat");
        voxels.renderer.material.mainTexture = GameFlow.selectedAtlas.mainTexture;

        // To camera
        voxels.transform.localScale = Vector3.one / 25f;

        voxels.transform.parent = mainCamera.cameraObj.transform;

        voxels.transform.localPosition = new Vector3(-0.46f, -0.25f, 0.5f);

        mainCamera.voxelsObj = voxels;
        mainCamera.voxelsObj.SetActive(false);
    }
}
