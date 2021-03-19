using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShortsword : Weapon
{
    public override int ID => 2001;
    public override string Title => "Small Shortsword";
    public override string Description => "A small sword.";
    public override string Slug => "small_shortsword";

    public override Rarity Rarity => Rarity.Common;

    public override int MinimumDamage => 1;
    public override int MaximumDamage => 10;

    public SmallShortsword() : base()
    {
        Stats.Add(new ElementalStat(Element.Air, Random.Range(1, 4)));
        Stats.Add(new ElementalStat(Element.Fire, Random.Range(1, 4)));
    }
}
