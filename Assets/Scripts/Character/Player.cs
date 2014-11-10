using UnityEngine;
using System.Collections;

public class Player
{
    private World world;

    public GameObject playerObj;
    public CharacterController controller;

    // Movement
    public float godModeSpeed = 25;
    public float runSpeed = 4.5f;
    public float walkSpeed = 2;
    public float acceleration = 0.2f;

    public float jumpInitialSpeed = 5;

    // Detection
    public int constructionDetection = 300;


    public Player(World world)
    {
        this.world = world;
        Init();
    }


    public void Init()
    {
        //+ Player creation
        playerObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Transform.Destroy(playerObj.GetComponent<CapsuleCollider>());

        playerObj.name = "Player";
        playerObj.tag = "Player";

        // Player components creation
        controller = playerObj.AddComponent<CharacterController>();
        playerObj.AddComponent<SphereCollider>();
        playerObj.AddComponent("UPlayer");
        playerObj.AddComponent("PlayerComponent");

        // Component variables
        playerObj.GetComponent<CharacterController>().slopeLimit = 46;

        playerObj.GetComponent<SphereCollider>().isTrigger = true;
        playerObj.GetComponent<SphereCollider>().radius = 30;
        playerObj.GetComponent<SphereCollider>().center = Vector3.zero;

        playerObj.renderer.material = new Material(Shader.Find("Diffuse"));
    }

}
