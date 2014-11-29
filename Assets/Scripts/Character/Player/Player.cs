using UnityEngine;
using System.Collections;

public class Player
{
    public GameObject playerObj;
    public CharacterController controller;
    public Light light;

    // Statistics
    public float maxLife = 20;
    public float currentLife = 20;

    // Movement
    public float godModeSpeed = 25;
    public float runSpeed = 6.5f;
    public float walkSpeed = 4;
    public float acceleration = 0.2f;
    public float jumpInitialSpeed = 6;
    public float jumpGravityMultiplier = 2.5f;
    public bool isMoving;

    // Detection
    public int constructionDetection = 300;

    // Animation
    public int damageAnimTime = 5;


    public Player(World world)
    {
        Init(world);
    }


    public void Init(World world)
    {
        //+ Player creation
        Transform character = Object.Instantiate(world.character) as Transform;

        playerObj = character.gameObject;

        // Head atributes
        playerObj.name = "Player";
        playerObj.tag = "Player";

        // Set transforms
        playerObj.transform.position = new Vector3(4, 35, 4);
        playerObj.transform.eulerAngles = Vector3.zero;
        //playerObj.transform.localScale = new Vector3(0.575f, 0.7f, 0.575f);

        // Player components creation
        controller = playerObj.GetComponent<CharacterController>();
        playerObj.AddComponent<PlayerComponent>();
        light = playerObj.AddComponent<Light>();

        // Component variables
        playerObj.GetComponent<CharacterController>().slopeLimit = 46;
        //playerObj.renderer.material = new Material(Shader.Find("Diffuse"));
        light.type = LightType.Point;
        light.color = Color.white;
        light.range = 20;
        light.intensity = 1.5f;

        //+ Player initializations
        playerObj.GetComponent<PlayerComponent>().Init(this);
    }

}
