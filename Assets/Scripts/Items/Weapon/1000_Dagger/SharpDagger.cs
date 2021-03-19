using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpDagger : Weapon
{
    public override int ID => 1101;
    public override string Title => "Sharp Dagger";
    public override string Description => "A sharpened dagger.";
    public override string Slug => "sharp_dagger";

    public override Rarity Rarity => Rarity.Uncommon;

    public override int MinimumDamage => 5;
    public override int MaximumDamage => 10;

    public SharpDagger() : base()
    {

    }
}
