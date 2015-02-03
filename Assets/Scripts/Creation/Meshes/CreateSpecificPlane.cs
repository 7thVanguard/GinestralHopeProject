using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSpecificPlane : MonoBehaviour 
{
    // Parameters
    public Vector2 size = new Vector2(10, 10);
    public Vector2 divisionsMultiplier = new Vector2(1, 1);
    public Vector2 tiling = Vector2.one;

    public bool create = false;


    void Update()
    {
        if (create)
        {
            Create();
            create = false;
        }
    }


    private void Create()
    {
        // Internal
        List<Vector3> Vertices = new List<Vector3>();
        List<Vector2> UV = new List<Vector2>();
        List<int> Triangles = new List<int>();

        for (float tx = 0; tx < tiling.x; tx++)
            for (float ty = 0; ty < tiling.y; ty++)
            {
                float index = tx * ((divisionsMultiplier.x + 1) * (divisionsMultiplier.y + 1) * tiling.y) + ty * ((divisionsMultiplier.x + 1) * (divisionsMultiplier.y + 1));

                for (float dx = 0; dx <= divisionsMultiplier.x; dx++)
                    for (float dy = 0; dy <= divisionsMultiplier.y; dy++)
                    {
                        Vertices.Add(new Vector3(tx / tiling.x + dx / (divisionsMultiplier.x * tiling.x), 0,
                                                 ty / tiling.y + dy / (divisionsMultiplier.y * tiling.y)));

                        UV.Add(new Vector2(dx / divisionsMultiplier.x, dy / divisionsMultiplier.y));

                        if (dx != divisionsMultiplier.x && dy != divisionsMultiplier.y)
                        {
                            Triangles.Add((int)(dx * (divisionsMultiplier.y + 1) + dy + index));
                            Triangles.Add((int)(dx * (divisionsMultiplier.y + 1) + dy + 1 + index));
                            Triangles.Add((int)((dx + 1) * (divisionsMultiplier.y + 1) + dy + 1 + index));

                            Triangles.Add((int)(dx * (divisionsMultiplier.y + 1) + dy + index));
                            Triangles.Add((int)((dx + 1) * (divisionsMultiplier.y + 1) + dy + 1 + index));
                            Triangles.Add((int)((dx + 1) * (divisionsMultiplier.y + 1) + dy + index));
                        }
                    }
            }


        //for (int x = 0; x <= tiling.x * divisionsMultiplier.x; x++)
        //    for (int y = 0; y <= tiling.y * divisionsMultiplier.y; y++)
        //    {
        //        if (x != tiling.x * divisionsMultiplier.x && y != tiling.y * divisionsMultiplier.y)
        //        {
        //            Triangles.Add(x * (int)(divisionsMultiplier.y + 1) + y);
        //            Triangles.Add(x * (int)(divisionsMultiplier.y + 1) + y + 1);
        //            Triangles.Add((x + 1) * (int)(divisionsMultiplier.y + 1) + y + 1);

        //            Triangles.Add(x * (int)(divisionsMultiplier.y + 1) + y);
        //            Triangles.Add((x + 1) * (int)(divisionsMultiplier.y + 1) + y + 1);
        //            Triangles.Add((x + 1) * (int)(divisionsMultiplier.y + 1) + y);
        //        }
        //    }

        CreateMesh(Vertices, UV, Triangles);
    }


    private void CreateMesh(List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles)
    {
        GameObject curve = gameObject;

        if (curve.GetComponent<MeshRenderer>() == null)
            curve.AddComponent<MeshRenderer>();

        curve.renderer.material = GameFlow.selectedAtlas;

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
        if (curve.GetComponent<MeshFilter>() == null)
            curve.AddComponent<MeshFilter>();
        else
            curve.GetComponent<MeshFilter>().mesh.Clear();

        // Assign the information in the arrays to the mesh
        curve.GetComponent<MeshFilter>().mesh.vertices = verticesVector;
        curve.GetComponent<MeshFilter>().mesh.uv = UVVecor;
        curve.GetComponent<MeshFilter>().mesh.triangles = trianglesVector;

        curve.GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }
}
