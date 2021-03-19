using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerratedDagger : Weapon
{
    public override int ID => 1201;
    public override string Title => "Serrated Dagger";
    public override string Description => "A dagger with a serrated edge. Perfect for rending flesh.";
    public override string Slug => "serrated_dagger";

    public override Rarity Rarity => Rarity.Rare;

    public override int MinimumDamage => 10;
    public override int MaximumDamage => 15;

    public SerratedDagger() : base()
    {

    }
}
