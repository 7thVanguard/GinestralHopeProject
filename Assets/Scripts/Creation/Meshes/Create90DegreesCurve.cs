using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Create90DegreesCurve : MonoBehaviour 
{
    // Parameters
    public Vector2 size = new Vector2(10, 10);
    public Vector2 divisions = new Vector2(2, 2);

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


        for (float x = 0; x <= divisions.x; x++)
            for (float y = 0; y <= divisions.y; y++)
            {
                Vertices.Add(new Vector3((y / divisions.y) * Mathf.Sin((90 * x / divisions.x) * Mathf.Deg2Rad), 0, 
                                        (y / divisions.y) * Mathf.Cos((90 * x / divisions.x) * Mathf.Deg2Rad)));
                UV.Add(new Vector2(x / divisions.x, y / divisions.y));
            }


        for (int x = 0; x <= divisions.x; x++)
            for (int y = 0; y <= divisions.y; y++)
            {
                if (x != divisions.x && y != divisions.y)
                {
                    Triangles.Add(x * (int)(divisions.y + 1) + y);
                    Triangles.Add(x * (int)(divisions.y + 1) + y + 1);
                    Triangles.Add((x + 1) * (int)(divisions.y + 1) + y + 1);

                    Triangles.Add(x * (int)(divisions.y + 1) + y);
                    Triangles.Add((x + 1) * (int)(divisions.y + 1) + y + 1);
                    Triangles.Add((x + 1) * (int)(divisions.y + 1) + y);
                }
            }

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
