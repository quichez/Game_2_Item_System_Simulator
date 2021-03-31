using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShortsword : Weapon
{
    public override Rarity Rarity => Rarity.Common;
    public override int MinimumDamage => 1;
    public override int MaximumDamage => 10;

    public SmallShortsword() : base()
    {
        ID = 2001;
        Title = "Small Shortsword";
        Description = "A small sword.";
        Slug = "small_shortsword";

        Stats.Add(new ElementalStat(Element.Air, Random.Range(1, 4)));
        Stats.Add(new ElementalStat(Element.Fire, Random.Range(1, 4)));
    }
}
