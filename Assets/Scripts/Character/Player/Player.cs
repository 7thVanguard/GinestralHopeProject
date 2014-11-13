using UnityEngine;
using System.Collections;

public class Player
{
    public GameObject playerObj;
    public CharacterController controller;

    // Statistics
    public float maxLife = 20;
    public float currentLife = 20;

    // Movement
    public float godModeSpeed = 25;
    public float runSpeed = 4.5f;
    public float walkSpeed = 2;
    public float acceleration = 0.2f;

    public float jumpInitialSpeed = 5;

    // Detection
    public int constructionDetection = 300;

    // Animation
    public int damageAnimTime = 5;


    public Player()
    {
        Init();
    }


    public void Init()
    {
        //+ Player creation
        playerObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Transform.Destroy(playerObj.GetComponent<CapsuleCollider>());

        // Head atributes
        playerObj.name = "Player";
        playerObj.tag = "Player";

        // Set transforms
        playerObj.transform.position = new Vector3(4, 35, 4);
        playerObj.transform.eulerAngles = Vector3.zero;
        playerObj.transform.localScale = new Vector3(0.675f, 0.7f, 0.675f);

        // Player components creation
        controller = playerObj.AddComponent<CharacterController>();
        playerObj.AddComponent<SphereCollider>();
        playerObj.AddComponent<PlayerComponent>();

        // Component variables
        playerObj.GetComponent<CharacterController>().slopeLimit = 46;

        playerObj.GetComponent<SphereCollider>().isTrigger = true;
        playerObj.GetComponent<SphereCollider>().radius = 30;
        playerObj.GetComponent<SphereCollider>().center = Vector3.zero;

        playerObj.renderer.material = new Material(Shader.Find("Diffuse"));

        //+ Player initializations
        playerObj.GetComponent<PlayerComponent>().Init(this);
    }

}
