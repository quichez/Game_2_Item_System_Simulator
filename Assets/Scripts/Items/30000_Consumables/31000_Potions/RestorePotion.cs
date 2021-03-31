using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestorePotion : Potion
{
    public override int ID => 31003;
    public override string Title => "Restore Potion";
    public override string Description => "A weak restoration potion!";
    public override string Slug => "restore_pot";

    public override int MaxStack => 5;

    public RestorePotion(int i) : base(i)
    {

    }    
}
