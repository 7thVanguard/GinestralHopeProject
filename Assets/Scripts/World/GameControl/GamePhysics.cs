using UnityEngine;
using System.Collections;

public static class GamePhysics
{
    public static float gravity = 9.81f;

    public static void BoundedLerp(ref float actual, float objective, ref float speed, float maxSpeed, float sensitivity)
    {
        float distance = Mathf.Abs(objective - actual);

        if (distance < 2)
            maxSpeed *= distance / 2;

        if (speed < maxSpeed)
            speed += sensitivity * Time.deltaTime;
        else if (speed > maxSpeed)
            speed = maxSpeed;

        actual += speed;
    }
    public static Vector3 BoundedLerp(Vector3 actual, Vector3 objective, ref float speed, float maxSpeed, float sensitivity)
    {
        float distance = Vector3.Distance(actual, objective);

        if (distance < 2)
            maxSpeed *= distance / 2;

        if (speed < maxSpeed)
            speed += sensitivity * Time.deltaTime;
        else if (speed > maxSpeed)
            speed = maxSpeed;

        actual += Vector3.Normalize(objective - actual) * speed;

        return actual;
    }
}
