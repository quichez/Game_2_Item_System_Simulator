using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpDagger : Weapon
{
    public override Rarity Rarity => Rarity.Uncommon;
    public override int MinimumDamage => 5;
    public override int MaximumDamage => 10;

    public SharpDagger() : base()
    {
        ID = 1101;
        Title = "Sharp Dagger";
        Description = "A sharpened dagger.";
        Slug = "sharp_dagger";
        Icon = Resources.Load<Sprite>("Sprites/Weapons/Daggers/" + Slug);
    }
}
