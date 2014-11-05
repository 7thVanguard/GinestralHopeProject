using UnityEngine;
using System.Collections;

public static class ObjectCreator
{
    public static void WorldSet(GameObject world)
    {
        // World
        world.name = "World";

        // Set world transforms
        world.transform.position = Vector3.zero;
        world.transform.eulerAngles = Vector3.zero;
        world.transform.localScale = Vector3.one;

        world.AddComponent("GUISystem");
        world.AddComponent("HUD");
    }


    public static void PlayerCreation()
    {
        // Player
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Transform.Destroy(player.GetComponent<CapsuleCollider>());

        player.name = "Player";
        player.tag = "Player";
        player.layer = LayerMask.NameToLayer("Ignore Raycast");

        // Player components creation
        player.AddComponent<CharacterController>();
        player.AddComponent<SphereCollider>();
        player.AddComponent("UPlayer");

        // Component variables
        player.GetComponent<CharacterController>().slopeLimit = 46;

        player.GetComponent<SphereCollider>().isTrigger = true;
        player.GetComponent<SphereCollider>().radius = 30;
        player.GetComponent<SphereCollider>().center = Vector3.zero;


        // Camera
        GameObject mainCamera = new GameObject();

        mainCamera.name = "MainCamera";
        mainCamera.tag = "MainCamera";

        // Camera components creation
        mainCamera.AddComponent<Camera>();
        mainCamera.AddComponent<CharacterController>();
        mainCamera.AddComponent("UCamera");

        mainCamera.AddComponent("FlareLayer");
    }


    public static void SunCreation(Flare sunFlare)
    {
        // Sun
        GameObject sun = new GameObject();

        sun.name = "Sun";

        // Set sun transforms
        sun.transform.position = Vector3.zero;
        sun.transform.eulerAngles = new Vector3(50, 30, 0);
        sun.transform.localScale = Vector3.one;


        // Light components creation
        sun.AddComponent<Light>();
        sun.AddComponent<LensFlare>();
        sun.AddComponent("ULightSystem");

        sun.light.type = LightType.Directional;
        sun.light.shadows = LightShadows.Hard;

        sun.GetComponent<LensFlare>().flare = sunFlare;
    }
}
