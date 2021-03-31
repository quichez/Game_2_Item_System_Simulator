using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthPotion
{
    void UseHealthPotion();
}

public class HealthPotion : Potion, IHealthPotion
{
    public override int ID => 31001;
    public override string Title => "Health Potion";
    public override string Description => "A weak health potion!";
    public override string Slug => "health_pot";

    public override int MaxStack => 20;

    public HealthPotion(int i):base(i)
    {
        
    }

    protected override void ConsumePotion()
    {
        int before = Player.Instance.Health.Current;
        Player.Instance.Health.Heal(20);
        Debug.Log("Before: " + before.ToString() + "   After: " + Player.Instance.Health.Current.ToString());
        base.ConsumePotion();
    }

    public void UseHealthPotion()
    {
        ConsumePotion();
    }
}
