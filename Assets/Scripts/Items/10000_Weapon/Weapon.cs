using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ID Code: ABCDD
 * A: Item Type = 1 (Weapon)
 * 
 * B: Weapon Type
 * 1: Dagger, 2: Sword, 3: Wand
 * 
 * See Item for full ID description
*/

public abstract class Weapon : Equipment
{    
    public override EquipmentType Type => EquipmentType.Weapon;

    public Vector2Int DamageRange { get; protected set; }
    public int Damage { get; protected set; }

    public abstract int MinimumDamage { get; }
    public abstract int MaximumDamage { get; }

    public Weapon():base()
    {
        Damage = Random.Range(MinimumDamage, MaximumDamage + 1);        
    }  

    //Instantiate from weapon frame
    public Weapon(Weapon frame)
    {
        
        Damage = Random.Range(frame.DamageRange.x, frame.DamageRange.y + 1);
        //Icon = frame.Icon;
        SetStatBonuses(Rarity);
        SpecialStats = frame.SpecialStats;
    }

    //Load from save file
    public Weapon(int id, string title, string desc, string slug, int type, int rarity, int dmg, int[][] statBonuses)
    {
        
        foreach (int[] stat in statBonuses)
        {
            Stats.Add(new ElementalStat((Element)stat[0], stat[1]));
        }
    }
}

public interface ILegendaryEquipment
{
    string SpecialProperty { get; }
}