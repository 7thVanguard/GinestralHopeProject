using UnityEngine;
using System.Collections;

public class Player
{
    public GameObject playerObj;
    public CharacterController controller;
    //public Light light;

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
    }

}
