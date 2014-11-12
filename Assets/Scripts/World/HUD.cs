using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour 
{
    public static Texture2D gizmoCircle;
    Texture2D gizmoCross;
    Texture2D translucentSelector;

    Texture2D lifeBar;
    Texture2D lifeBarBack;

    public static GameObject quadMarker;
    public static GameObject cubeMarker;
    public static GameObject sphereMarker;


	void Awake () 
    {
        gizmoCross = TextureCreator.CreateCross(gizmoCross);
        gizmoCircle = TextureCreator.CreateCircle(gizmoCircle);

        translucentSelector = TextureCreator.CreatePixel(translucentSelector, new Color(50.0f / 255, 100.0f / 255, 150.0f / 255, 120.0f / 255));    // translucent blue
        lifeBar = TextureCreator.CreatePixel(lifeBar, Color.green);
        lifeBarBack = TextureCreator.CreatePixel(lifeBarBack, Color.red);

        quadMarker = MarkersCreator.CreateQuadMarker(quadMarker, translucentSelector);
        cubeMarker = MarkersCreator.CreateCubeMarker(cubeMarker, translucentSelector);
        sphereMarker = MarkersCreator.CreateSphereMarker(sphereMarker, translucentSelector);
	}
	


	void OnGUI () 
    {
        //+ Gizmos
        GUI.DrawTexture(new Rect(Screen.width / 2 - gizmoCross.width / 2, Screen.height / 2 - gizmoCross.width / 2, gizmoCross.width, gizmoCross.height), gizmoCross);
        
        if (PlayerCombat.target == null)
            GUI.DrawTexture(new Rect(Screen.width / 2 - gizmoCircle.width / 2, Screen.height / 2 - gizmoCircle.width / 2, gizmoCircle.width, gizmoCircle.height), gizmoCircle);
        else
            GUI.DrawTexture(new Rect(PlayerCombat.circleGizmoScreenPos.x - gizmoCircle.width / 2, (Screen.height - PlayerCombat.circleGizmoScreenPos.y) - gizmoCircle.width / 2, gizmoCircle.width, gizmoCircle.height), gizmoCircle);


        //+ Game bars
        // Player Life Bar
        GUI.DrawTexture(new Rect(Screen.width / 8, Screen.height / 1.1f, 200, 20), lifeBarBack);
        GUI.DrawTexture(new Rect(Screen.width / 8, Screen.height / 1.1f, 200 * SPlayer.currentLife / SPlayer.maxLife, 20), lifeBar);

        // Enemy life bar
        if (PlayerCombat.target != null)
        {
            GUI.DrawTexture(new Rect(Screen.width * 7 / 8, Screen.height / 2, Screen.width * 0.9f / 8, 15), lifeBarBack);
            GUI.DrawTexture(new Rect(Screen.width * 7 / 8, Screen.height / 2,
                (Screen.width * 0.9f / 8) * (PlayerCombat.target.GetComponent<EnemyComponent>().life / PlayerCombat.target.GetComponent<EnemyComponent>().maxLife), 15), lifeBar);
        }


        //+ Skills casting
        if (CombatSkillsManager.casting)
        {
            GUI.DrawTexture(new Rect(Screen.width * 3 / 8 - 3, Screen.height * 4 / 5 - 10, Screen.width * 2 / 8 + 6, 20), lifeBarBack);
            GUI.DrawTexture(new Rect(Screen.width * 3 / 8, Screen.height * 4 / 5 - 7,
                (Screen.width * 2 / 8) * (CombatSkillsManager.actualCastingTime / CombatSkillsManager.totalCastingTime), 14), lifeBar);
        }
    }
}
