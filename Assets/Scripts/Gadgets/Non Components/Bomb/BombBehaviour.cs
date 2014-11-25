using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour 
{
    World world;

    private GameObject runes;
    private GameObject glow;

    private int damage;
    private int blastRadius;
    private float downCounter;


	public void Init(World world)
    {
        this.world = world;

        runes = transform.FindChild("AnimatedRunes").gameObject;
        glow = transform.FindChild("AnimatedRunes").FindChild("RunesGlow").gameObject;

        damage = 6;
        blastRadius = 12;
        downCounter = 5;
    }


	void Update () 
    {
        downCounter -= Time.deltaTime;

        if (downCounter <= 0)
        {
            VoxelLib.Explosion(world, transform.position, damage, blastRadius);
            Destroy(this.gameObject);
        }

        transform.FindChild("AnimatedRunes").eulerAngles += new Vector3(0, 150 * Time.deltaTime, 0);
	}
}
