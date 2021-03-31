using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ID Code: ABCDD
 * A: Item Type = 2 (Armor)
 * 
 * B: Armor Type
 * 1: Head, 2: Chest, 3: Pants, 4: Boots, 5: Gloves
 * 
 * See Item for full ID description
*/

public abstract class Armor : Equipment
{
    public virtual Vector2Int DefenseRange { get; protected set; }
    public int Defense { get; protected set; }


    public Armor() : base()
    {
        Defense = Random.Range(DefenseRange.x, DefenseRange.y + 1);
    }
}
