using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningPotion : Potion
{
    public override int MaxStack => 5;

    public LightningPotion(int i) : base(i)
    {

    }

    protected override void ConsumePotion()
    {

        base.ConsumePotion();
    }
}
