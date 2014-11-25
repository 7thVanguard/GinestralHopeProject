using UnityEngine;
using System.Collections;

public class DevCombatToolsManager
{
    public void Update(Player player, MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Skill.Dictionary["Fire Ball"].CastDirected(null, player.playerObj.transform.position, true);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Skill.Dictionary["Fire Mine"].CastDirected(null, player.playerObj.transform.position, true);
    }
}
