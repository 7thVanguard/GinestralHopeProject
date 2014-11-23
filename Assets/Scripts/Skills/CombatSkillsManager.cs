using UnityEngine;
using System.Collections;

public class CombatSkillsManager
{
    public static float totalCastingTime = 0;
    public static float actualCastingTime = 0;
    public static string methodName = "";
    public static bool casting = false;

    public void Update(Player player, MainCamera mainCamera)
    {
        // Make sure that pressing again a button won't reset the skill
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (methodName != "Fire Ball")
            {
                methodName = "Fire Ball";
                actualCastingTime = 0;
                totalCastingTime = Skill.Dictionary[methodName].castingTime;
                casting = true;
            }
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
            actualCastingTime += Time.deltaTime;
            // Counter ends and the selected skill is launched
            if (actualCastingTime >= totalCastingTime)
            {
                Skill.Dictionary[methodName].CastDirected(null, player.playerObj.transform.position, true);

                // Reset method name
                methodName = "";
                casting = false;
            }
        }
    }
}
