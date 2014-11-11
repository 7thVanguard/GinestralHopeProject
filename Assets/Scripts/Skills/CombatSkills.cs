using UnityEngine;
using System.Collections;

public class CombatSkills
{
    public static float totalCastingTime = 0;
    public static float actualCastingTime = 0;
    public static string methodName = "";
    public static bool casting = false;

    public void Update(MainCamera mainCamera)
    {
        // Make sure that pressing again a button won't reset the skill
        if (methodName != "LambertBall")
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                totalCastingTime = 120;
                actualCastingTime = 0;
                methodName = "LambertBall";
                casting = true;
            }


        // Cancel
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            totalCastingTime = 0;
            actualCastingTime = 0;
            methodName = "";
            casting = false;
        }

        // Counter
        if (actualCastingTime < totalCastingTime)
        {
            actualCastingTime++;
            // Counter ends and the selected skill is launched
            if (actualCastingTime == totalCastingTime)
            {
                switch (methodName)
                {
                    case "LambertBall":
                        CreateLambertBall.Cast(mainCamera, SPlayer.transform.position, 25, 30, true);
                        break;
                    default:
                        break;
                }

                // Reset method name
                methodName = "";
                casting = false;
            }
        }
    }
}
