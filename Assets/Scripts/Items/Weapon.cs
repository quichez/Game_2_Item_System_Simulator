using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public abstract class Weapon : Equipment
{
    public WeaponType Type { get; }
    public Vector2Int DamageRange { get; private set; }
    public int Damage { get; protected set; }

    public abstract int MinimumDamage { get; }
    public abstract int MaximumDamage { get; }

    public Weapon()
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