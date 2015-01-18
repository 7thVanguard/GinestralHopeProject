using UnityEngine;
using System.Collections;

public class Player
{
    public GameObject playerObj;
    public CharacterController controller;
    public GameObject pointLight;
    public GameObject spotLight;
    public Light pointLightLight;
    public Light spotLightLight;

    // Statistics
    public float maxLife = 20;
    public float currentLife = 20;

    // Movement
    public Vector2 targetPosition;

    public float godModeSpeed = 25;
    public float runSpeed = 6.5f;
    public float walkSpeed = 4;

    public float acceleration = 0.5f;

    public float jumpInitialSpeed = 8;
    public float jumpGravityMultiplier = 2.5f;

    public bool isMoving;

    // Detection
    public int constructionDetection = 5;

    // Animation
    public int damageAnimTime = 5;

    //+ Unlocks

    // Levels

    // Orbs

    // Skills
    public bool unlockedSkillFireBall = true;




    public Player(World world)
    {
        Init(world);
    }


    public void Init(World world)
    {
        //+ Player creation
        GameObject character = (GameObject)Resources.Load("Props/Characters/Player");
        playerObj = GameObject.Instantiate(character) as GameObject;

        // Head atributes
        playerObj.name = "Player";
        playerObj.tag = "Player";
        playerObj.layer = LayerMask.NameToLayer("Player");

        // Set transforms
        playerObj.transform.position = new Vector3(4, 35, 4);
        playerObj.transform.eulerAngles = Vector3.zero;

        // Player components creation
        controller = playerObj.GetComponent<CharacterController>();
        controller.slopeLimit = 46;

        //+ Player initializations
        playerObj.GetComponent<PlayerComponent>().Init(this);

        targetPosition.x = playerObj.transform.position.x;
        targetPosition.y = playerObj.transform.position.z;

        // Lights
        pointLight = new GameObject();
        spotLight = new GameObject();

        pointLight.transform.name = "Point Light";
        spotLight.transform.name = "Spot Light";

        pointLight.transform.parent = playerObj.transform;
        spotLight.transform.parent = playerObj.transform;

        pointLight.transform.localPosition = Vector3.zero;
        spotLight.transform.localPosition = Vector3.zero;

        pointLightLight = pointLight.AddComponent<Light>();
        spotLightLight = spotLight.AddComponent<Light>();

        pointLightLight.type = LightType.Point;
        spotLightLight.type = LightType.Spot;

        pointLightLight.range = 3;
        spotLightLight.range = 35;
        spotLightLight.spotAngle = 32;

        pointLightLight.intensity = 1;
        spotLightLight.intensity = 2.5f;
    }

}
