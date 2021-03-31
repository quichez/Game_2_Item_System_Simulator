using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : Potion
{
    public override int ID => 31002;
    public override string Title => "Mana Potion";
    public override string Description => "A weak mana potion!";
    public override string Slug => "mana_pot";

    public override int MaxStack => 10;

    public ManaPotion(int i) : base(i)
    {

    }
}
