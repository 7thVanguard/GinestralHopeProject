﻿using UnityEngine;
using System.Collections;

public class NSlimeEnemyMovement
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
            objectiveDirection += new Vector3(0, -GamePhysics.gravity * 1.5f, 0) * Time.deltaTime;

        // Rotation
        enemy.transform.eulerAngles += new Vector3(0, 30 * Time.deltaTime, 0);

        enemyController.Move(objectiveDirection * Time.deltaTime);
    }
}
