using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustyBroadsword : Weapon
{
    public override string Slug => "rusty_broadsword";
    public override Sprite Icon => Resources.Load<Sprite>("Sprites/Weapons/Swords/" + Slug);

    public override Rarity Rarity => Rarity.Common;
    public override int MinimumDamage => 1;
    public override int MaximumDamage => 5;

    public RustyBroadsword() : base()
    {
        ID = 2002;
        Title = "Rusty Broadsword";
        Description = "An old, rusty broadsword.";
        Stats.Add(new ElementalStat(Element.Air, Random.Range(1, 4)));
        Stats.Add(new ElementalStat(Element.Water, Random.Range(1, 4)));
    }
}
