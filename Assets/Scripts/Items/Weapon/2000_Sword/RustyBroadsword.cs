using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustyBroadsword : Weapon
{
    public override int ID => 2002;
    public override string Title => "Rusty Broadsword";
    public override string Description => "An old, rusty broadsword.";
    public override string Slug => "rusty_broadsword";

    public override Rarity Rarity => Rarity.Common;

    public override int MinimumDamage => 1;
    public override int MaximumDamage => 5;

    public RustyBroadsword() : base()
    {
        Stats.Add(new ElementalStat(Element.Air, Random.Range(1, 4)));
        Stats.Add(new ElementalStat(Element.Water, Random.Range(1, 4)));
    }
}
