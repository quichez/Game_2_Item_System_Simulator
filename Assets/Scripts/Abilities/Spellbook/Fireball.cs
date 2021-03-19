using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public class Fireball : AbilityActive
{
    public override string Name => "Fireball";
    int _dmg = 5;
    int _mod;

    public override void Process()
    {
        int tempDmg = _dmg + Player.Instance.GetElementalBonuses(Element.Fire);
        foreach (Equipment item in Player.Instance.Inventory.Inv)
        {
            var mult = item as IBuffFireballMult;
            if(mult != null)
                tempDmg *= mult.FireballBuffMult();
        }
        foreach (Equipment item in Player.Instance.Inventory.Inv)
        {
            var sum = item as IBuffFireballAdd;
            if (sum != null)
                tempDmg += sum.FireballBuffAdd();
        }
        foreach (Equipment item in Player.Instance.Inventory.Inv)
        {
            var spec = item as IFireballSpecialEffect;            
            spec?.FireballSpecialEffect();

        }
        Debug.Log(tempDmg);
    }

    public override void End()
    {
        throw new System.NotImplementedException();
    }
}

public interface IBuffFireballMult
{
    int FireballBuffMult();
}
public interface IBuffFireballAdd
{
    int FireballBuffAdd();
}
public interface IFireballSpecialEffect
{
    void FireballSpecialEffect();
}