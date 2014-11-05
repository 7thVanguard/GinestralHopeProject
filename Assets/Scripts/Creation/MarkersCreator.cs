using UnityEngine;
using System.Collections;

public static class MarkersCreator
{
    public static GameObject CreateQuadMarker(GameObject quadMarker, Texture2D translucentSelector)
    {
        Material quadTranslucentMaterial;

        quadMarker = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quadMarker.name = "QuadMarker";
        quadMarker.transform.position = new Vector3(0, -10000, 0);
        quadMarker.transform.eulerAngles = new Vector3(0, 0, 0);
        quadMarker.layer = LayerMask.NameToLayer("Ignore Raycast");

        quadTranslucentMaterial = new Material(Shader.Find("Particles/Additive"));
        quadTranslucentMaterial.mainTexture = translucentSelector;

        quadMarker.renderer.material = quadTranslucentMaterial;

        return quadMarker;
    }


    public static GameObject CreateCubeMarker(GameObject cubeMarker, Texture2D translucentSelector)
    {
        Material cubeTranslucentMaterial;

        cubeMarker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeMarker.name = "CubeMarker";
        cubeMarker.transform.position = new Vector3(0, -10000, 0);
        cubeMarker.transform.eulerAngles = new Vector3(0, 0, 0);
        cubeMarker.layer = LayerMask.NameToLayer("Ignore Raycast");

        cubeTranslucentMaterial = new Material(Shader.Find("Particles/Additive"));
        cubeTranslucentMaterial.mainTexture = translucentSelector;

        cubeMarker.renderer.material = cubeTranslucentMaterial;

        return cubeMarker;
    }


    public static GameObject CreateSphereMarker(GameObject sphereMarker, Texture2D translucentSelector)
    {
        Material sphereTranslucentMaterial;

        sphereMarker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphereMarker.name = "SphereMarker";
        sphereMarker.transform.position = new Vector3(0, -10000, 0);
        sphereMarker.transform.eulerAngles = new Vector3(0, 0, 0);
        sphereMarker.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        sphereMarker.layer = LayerMask.NameToLayer("Ignore Raycast");

        sphereTranslucentMaterial = new Material(Shader.Find("Particles/Additive"));
        sphereTranslucentMaterial.mainTexture = translucentSelector;

        sphereMarker.renderer.material = sphereTranslucentMaterial;

        return sphereMarker;
    }
}
