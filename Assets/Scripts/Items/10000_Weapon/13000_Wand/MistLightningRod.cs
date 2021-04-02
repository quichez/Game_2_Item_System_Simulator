using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistLightningRod : Weapon, ILegendaryEquipment
{
    public override int ID => 3302;
    public override string Title => "MIST Lightning Rod";
    public override string Description => "One of the lightning rods from a building in MIST.";
    public override string Slug => "mist_lr";
    public override string EquipmentSlug => "WandBase";

    public override Sprite Icon => Resources.Load<Sprite>("Sprites/Weapons/Wands/" + Slug);

    public string SpecialProperty => "Increases consecutive bonus to Lightning Bolt";

    public override Rarity Rarity => Rarity.Legendary;

    public override int MinimumDamage => 20;
    public override int MaximumDamage => 55;

    public MistLightningRod():base()
    {
        Stats.Add(new ElementalStat(Element.Lightning, Random.Range(5, 11)));
    }    
}
