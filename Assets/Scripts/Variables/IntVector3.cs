using UnityEngine;
using System.Collections;

public class IntVector3
{
    public int x;
    public int y;
    public int z;


    public IntVector3 ()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }


    public IntVector3 (int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }


    public Vector3 ToVector3()
    {
        return new Vector3(this.x, this.y, this.z);
    }
}
