using UnityEngine;
using System.Collections;

public class UPlayer : MonoBehaviour
{
    public World world;


    // Mode change relative
    private PlayerMode mode;

    // Movement relative
    private PlayerMovement movement;

    // Combat relative
    public PlayerCombat combat;

    // Skills relative
    private CombatSkills combatSkills;
    private DevCombatSkills devCombatSkills;
    private DevConstructionSkills devConstructionSkills;


	void Start ()
    {
        // Mode change relative
        mode = new PlayerMode();

        // Combat relative
        combat = new PlayerCombat();

        transform.position = new Vector3(4, 35, 4);
        transform.eulerAngles = Vector3.zero;
        transform.localScale = new Vector3(0.675f, 0.7f, 0.675f);
        SPlayer.transform = transform;

        // Skills relative
        combatSkills = new CombatSkills();
        devCombatSkills = new DevCombatSkills();
        devConstructionSkills = new DevConstructionSkills();
	}
	


	void Update ()
    {
        // Pause
        if (Input.GetKeyUp(KeyCode.P))
            EGameFlow.pause = !EGameFlow.pause;

        // Movement relative
        if ((!EGameFlow.pause && UWorldGenerator.gameLoaded) || EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        {
            combat.Update();
            SPlayer.transform = transform;
        }

        // Save relative
        if (Input.GetKeyUp(KeyCode.F5))
            EGameSerializer.Save();
        else if (Input.GetKeyUp(KeyCode.F9))
            EGameSerializer.Load();
	}
}
