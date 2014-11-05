using UnityEngine;
using System.Collections;

public class NSlimeMovement
{
    private GameObject enemy;
    private CharacterController enemyController;

    private Vector3 objectiveDirection;

    public void Start(GameObject enemy)
    {
        this.enemy = enemy;
        enemyController = enemy.GetComponent<CharacterController>();
    }


    public void Update()
    {
        if (!enemyController.isGrounded)
            objectiveDirection += new Vector3(0, -EGamePhysics.gravity * 1.5f, 0) * Time.deltaTime;

        enemyController.Move(objectiveDirection * Time.deltaTime);
    }
}
