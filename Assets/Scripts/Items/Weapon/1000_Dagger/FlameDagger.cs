using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class FlameDagger : Weapon, IBuffFireballMult, ILegendaryEquipment
{
    public override int ID => 1301;
    public override string Title => "Flame Dagger";
    public override string Description => "A dagger made out of fire?";
    public override string Slug => "flame_dagger";
    public string SpecialProperty => "Doubles base Fireball damage";


    public override Rarity Rarity => Rarity.Legendary;
    public override int MinimumDamage => 30;
    public override int MaximumDamage => 50;

    public FlameDagger():base()
    {       
        Stats.Add(new ElementalStat(Element.Fire, Random.Range(5,11)));
    }  

    public int FireballBuffMult()
    {
        return 2;
    }
}
