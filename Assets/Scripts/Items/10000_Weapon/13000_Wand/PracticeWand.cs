using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeWand : Weapon
{   
    public override Rarity Rarity => Rarity.Common;
    public override int MinimumDamage => 1;
    public override int MaximumDamage => 5;

    public PracticeWand() : base()
    {
        ID = 3001;
        Title = "Practice Wand";
        Description = "A small wooden practice wand.";
        Slug = "practice_wand";
        Stats.Add(new ElementalStat(Element.Air, Random.Range(1, 4)));
    }
}
