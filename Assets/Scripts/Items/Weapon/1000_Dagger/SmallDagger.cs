using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallDagger : Weapon
{
    public override int ID => 1001;
    public override string Title => "Small Dagger";
    public override string Description => "A small dagger.";
    public override string Slug => "small_dagger";

    public override Rarity Rarity => Rarity.Common;

    public override int MinimumDamage => 1;
    public override int MaximumDamage => 5;

    public SmallDagger() : base()
    {

    }
}
