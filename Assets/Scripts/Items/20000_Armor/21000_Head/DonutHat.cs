using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutHat : Armor, ILegendaryEquipment
{
    public override int ID => 21301;
    public override string Title => "Donut Hat";
    public override string Description => "A donut hat!";
    public override string Slug => "donut_hat";
    public override Sprite Icon => Resources.Load<Sprite>("Sprites/Armor/Head/" + Slug);

    public override EquipmentType Type => EquipmentType.Head;
    public override Vector2Int DefenseRange => new Vector2Int(35, 50);

    public string SpecialProperty => "It's a donut!";

    public DonutHat() : base()
    {
        Stats.Add(new ElementalStat(Element.Air, Random.Range(10, 20)));
    }
}
