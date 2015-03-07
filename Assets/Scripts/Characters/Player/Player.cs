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
    public bool lightsOn = false;

    public GameObject lookAtObjective;
    public GameObject ringMarker;

    // Statistics
    public float maxLife = 3;
    public float currentLife = 3;
    public int orbsCollected = 0;

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

    // Skills
    public bool unlockedSkillFireBall = false;




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

        pointLight.transform.localPosition = new Vector3(0.5f, 0.8f, -0.6f);
        spotLight.transform.localPosition = new Vector3(0.3f, 0.8f, 0);

        pointLightLight = pointLight.AddComponent<Light>();
        spotLightLight = spotLight.AddComponent<Light>();

        pointLightLight.type = LightType.Point;
        spotLightLight.type = LightType.Spot;

        pointLightLight.color = new Color(169, 143, 99, 255) / 255f;
        spotLightLight.color = new Color(169, 143, 99, 255) / 255f;

        pointLightLight.range = 1.5f;
        spotLightLight.range = 25;
        spotLightLight.spotAngle = 90;

        pointLightLight.intensity = 1f;
        spotLightLight.intensity = 2.5f;

        // Objectives and particles
        lookAtObjective = new GameObject();
        lookAtObjective.name = "Player Look At Objective";
        lookAtObjective.transform.parent = playerObj.transform;
        lookAtObjective.transform.localPosition = Vector3.zero;
        lookAtObjective.transform.localEulerAngles = Vector3.zero;
        lookAtObjective.transform.localScale = Vector3.zero;

        ringMarker = (GameObject)Resources.Load("Particle Systems/Clouds Sight/Ring Marker/Ring Marker");
    }

}
