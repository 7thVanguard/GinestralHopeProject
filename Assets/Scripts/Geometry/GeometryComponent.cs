using UnityEngine;
using System.Collections;

public class GeometryComponent : MonoBehaviour
{
    [HideInInspector] public World world;
    [HideInInspector] public Player player;


    void Start()
    {
        if (this.name != "none")
        {
            this.gameObject.name = this.name;

            GameObject geometry = GameObject.Instantiate((GameObject)Resources.Load("Props/Geometry/" + this.name + "/" + this.name), 
                                                        transform.position, Quaternion.Euler(transform.eulerAngles)) as GameObject;
            geometry.transform.localScale = transform.localScale;
            geometry.name = this.name;

            GameObject.Destroy(this.gameObject);
        }
    }
}
