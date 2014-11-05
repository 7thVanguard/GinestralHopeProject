using UnityEngine;
using System.Collections;

public class UPlayer : MonoBehaviour
{
    // Mode change relative
    private PlayerMode mode;

    // Movement relative
    private PlayerMovement movement;

    // Combat relative
    public PlayerCombat combat;

    // Skills relative
    private DevCombatSkills devCombatSkills;
    private DevConstructionSkills devConstructionSkills;


	void Start ()
    {
        // Mode change relative
        mode = new PlayerMode();

        // Movement relative
        movement = new PlayerMovement();

        // Combat relative
        combat = new PlayerCombat();

        transform.position = new Vector3(4, 35, 4);
        transform.eulerAngles = Vector3.zero;
        transform.localScale = new Vector3(0.8f, 0.85f, 0.8f);
        SPlayer.transform = transform;

        movement.Start(gameObject);

        // Skills relative
        devCombatSkills = new DevCombatSkills();
        devConstructionSkills = new DevConstructionSkills();
	}
	


	void Update ()
    {
        // Mode change relative
        mode.Update();

        // Pause
        if (Input.GetKeyUp(KeyCode.P))
            EGameFlow.pause = !EGameFlow.pause;

        // Movement relative
        if ((!EGameFlow.pause && UWorldGenerator.gameLoaded) || EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        {
            movement.Update();
            combat.Update();
            SPlayer.transform = transform;
        }

        // Skills relative (GameMode relative)
        if (!EGameFlow.pause && UWorldGenerator.gameLoaded)
        {
            switch (EGameFlow.gameMode)
            {
                case EGameFlow.GameMode.COMBAT:
                    devCombatSkills.Update();
                    break;
                case EGameFlow.GameMode.CONTRUCTION:
                    devConstructionSkills.Update();
                    break;
                case EGameFlow.GameMode.DEVCOMBAT:
                    devCombatSkills.Update();
                    break;
                case EGameFlow.GameMode.DEVCONSTRUCTION:
                    devConstructionSkills.Update();
                    break;
                default:
                    break;
            }
        }

        // Save relative
        if (Input.GetKeyUp(KeyCode.F5))
            EGameSerializer.Save();
        else if (Input.GetKeyUp(KeyCode.F9))
            EGameSerializer.Load();
	}
}
