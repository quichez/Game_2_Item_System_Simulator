using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public class LightningBolt : AbilityActive
{
    public override string Name => "Lightning Bolt";
    int _dmg = 2;
    int _combo = 0;
    public override void Process()
    {

        if (Player.Instance.Abilities.LastCastAbility?.GetType() == GetType())
            _combo++;
        else
            _combo = 0;

        int lightning = Player.Instance.GetElementalBonuses(Element.Lightning);

        int temp = (_dmg + lightning + GetMistLRBuff()) * (_combo + 1);

        Debug.Log(temp);
    }

    public override void End()
    {
        
    }

    public int GetMistLRBuff()
    {
        if (Player.Instance.Inventory.Inv.Find(x => x.GetType() == typeof(FlameDagger)) != null)
            return 1;
        else
            return 0;
    }

}
