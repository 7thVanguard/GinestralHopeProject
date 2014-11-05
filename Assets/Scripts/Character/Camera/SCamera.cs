using UnityEngine;
using System.Collections;

public class SCamera
{
    //camera offset for third person
    public static Vector2 offset;

    // Pitch angle control
    public static float minAngleSight = -90;
    public static float maxAngleSight = 90;

    //distance to the player
    public static float distance = 4;

    // Mouse sensitivity for camera input
    public static float mouseSensitivityX = 5;
    public static float mouseSensitivityY = 5;
    public static float rotationSensitivity = 0.2f;
}
