using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeWand : Weapon
{
    public override int ID => 3001;
    public override string Title => "Practice Wand";
    public override string Description => "A small wooden practice wand.";
    public override string Slug => "practice_wand";

    public override Rarity Rarity => Rarity.Common;

    public override int MinimumDamage => 1;
    public override int MaximumDamage => 5;

    public PracticeWand() : base()
    {
        Stats.Add(new ElementalStat(Element.Air, Random.Range(1, 4)));
    }
}
