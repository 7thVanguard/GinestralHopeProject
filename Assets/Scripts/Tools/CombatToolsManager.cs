using UnityEngine;
using System.Collections;

public class CombatToolsManager
{
    public static float totalCastingTime = 0;
    public static float actualCastingTime = 0;
    public static string methodName = "";
    public static bool casting = false;

    public void Update(Player player, MainCamera mainCamera)
    {
        switch (GameFlow.runningGame)
        {
            case GameFlow.RunningGame.GINESTRAL_HOPE:
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        if (player.unlockedSkillFireBall)
                            // Make sure that pressing again a button won't reset the skill
                            if (methodName != "Fire Ball")
                            {
                                methodName = "Fire Ball";
                                actualCastingTime = 0;
                                totalCastingTime = Skill.Dictionary[methodName].castingTime;
                                casting = true;
                            }
                    }
                }
                break;
            case GameFlow.RunningGame.CLOUDS_SIGHT:
                {
                    if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.Mouse0))
                    {
                        // Make sure that pressing again a button won't reset the skill
                        if (methodName != "Frost Bolt")
                        {
                            methodName = "Frost Bolt";
                            actualCastingTime = 0;
                            totalCastingTime = Skill.Dictionary[methodName].castingTime;
                            casting = true;
                        }
                    }
                    else if (Input.GetKey(KeyCode.Alpha1))
                    {
                        if (player.unlockedSkillFireBall)
                            // Make sure that pressing again a button won't reset the skill
                            if (methodName != "Fire Ball")
                            {
                                methodName = "Fire Ball";
                                actualCastingTime = 0;
                                totalCastingTime = Skill.Dictionary[methodName].castingTime;
                                casting = true;
                            }
                    }
                }
                break;
            case GameFlow.RunningGame.PLANNED_DREAM:
                break;
            default:
                break;
        }

        // Cancel
        if (Input.GetKeyDown(KeyCode.Alpha7))
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

        if (casting)
        {
            player.playerObj.transform.LookAt(mainCamera.raycast.point);
            player.playerObj.transform.eulerAngles = new Vector3(0, player.playerObj.transform.eulerAngles.y, 0);
        }
    }
}
