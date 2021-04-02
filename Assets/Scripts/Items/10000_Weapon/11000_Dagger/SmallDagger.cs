using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDagger : Weapon
{
    public override string EquipmentSlug => "WandBase";

    public override Rarity Rarity => Rarity.Common;
    public override int MinimumDamage => 1;
    public override int MaximumDamage => 5;

    public SmallDagger() : base()
    {
        ID = 1001;
        Title = "Small Dagger";
        Description = "A small dagger.";
        Slug = "small_dagger";
    }
}
