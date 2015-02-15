using UnityEngine;
using System.Collections;

public class CFL_YellowOrb : MonoBehaviour 
{
    World world;
    GameObject yellowOrb;

    private bool active;
    private bool finished;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        yellowOrb = GameObject.Instantiate((GameObject)Resources.Load("Particle Systems/Ginestral Hope/Yellow Orb/Yellow Orb")) as GameObject;
        yellowOrb.transform.parent = this.transform;
        yellowOrb.transform.localPosition = Vector3.zero;
    }


    void Update()
    {
        if (!finished)
            if (active)
                finished = (EventsLib.GoAroundPlayer(yellowOrb));

        if (finished)
            Global.world.worldObj.transform.GetComponent<GameManager>().gameSerializer.Load(Global.world, Global.player, "CaverninaBoss");
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                LevelUnlocks.lvlCaverninaFirstLevelCompleted = true;
                active = true;
            }
    }
}
