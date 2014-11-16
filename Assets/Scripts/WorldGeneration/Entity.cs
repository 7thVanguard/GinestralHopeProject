using UnityEngine;
using System.Collections;

public class Entity
{
    public enum EntityType { TERRAIN, MINE, FLUID, GADGET, ENEMY, AIR }
    public EntityType entityType;

    public string ID;
}
