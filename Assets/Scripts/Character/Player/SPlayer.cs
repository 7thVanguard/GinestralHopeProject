using UnityEngine;
using System.Collections;



public static class SPlayer
{
    //PlayerStatistics
    public static float maxLife = 20;
    public static float currentLife = 20;
    
    // Movement
    public static float acceleration = 0.2f;

    public static float godModeSpeed = 25;
    public static float walkSpeed = 2;
    public static float runSpeed = 4.5f;

    public static float playerAcceleration = 5;
    public static float jumpInitialSpeed = 5;

    public static Transform transform;

    // Damage
    public static int damageAnimTime = 5;
}
