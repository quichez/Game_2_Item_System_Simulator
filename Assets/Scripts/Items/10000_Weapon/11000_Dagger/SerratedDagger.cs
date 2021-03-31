using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerratedDagger : Weapon
{

    public override Rarity Rarity => Rarity.Rare;

    public override int MinimumDamage => 10;
    public override int MaximumDamage => 15;

    public SerratedDagger() : base()
    {
        ID = 1201;
        Title = "Serrated Dagger";
        Description = "A dagger with a serrated edge. Perfect for rending flesh.";
        Slug = "serrated_dagger";
        Icon = Resources.Load<Sprite>("Sprites/Weapons/Daggers/" + Slug);
    }
}
