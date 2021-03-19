using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public class Flame : AbilityActive
{
    public override string Name => "Flame";
    public int Damage { get; private set; } = 5;
    public bool IsChanneling { get; private set; }

    private int OrnateAshwoodDamage = 0;

    public override void Process()
    {
        IsChanneling = true;
        int temp = Damage;      
        Player.Instance.Abilities.StartCoroutine(FlameChannel());
    }

    public override void End()
    {
        IsChanneling = false;
    }

    public IEnumerator FlameChannel()
    {
        float timer = 0.0f;
        while (IsChanneling)
        {
            timer += Time.deltaTime;
            if(timer < 1.0f)
            {
                Debug.Log(Damage + OrnateAshwoodDamage + Player.Instance.GetElementalBonuses(Element.Fire));
                yield return new WaitForEndOfFrame();
            }
            timer = 0.0f;
        }
    }

    public bool BuffFromOrnateAshwoodWand(bool amt)
    {
        if (amt)
            OrnateAshwoodDamage = Damage;
        else
            OrnateAshwoodDamage = 0;

        return amt;
    }

}

public interface IBuffFlameMult
{
    int FlameBuffMult();
}
public interface IBuffFlameAdd
{
    int FlameBuffAdd();
}
public interface IFlameSpecialEffect
{

}
