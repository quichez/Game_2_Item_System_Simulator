using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : Item, IConsumable, IStackable
{
    public override Sprite Icon => Resources.Load<Sprite>("Sprites/Consumables/" + Slug);

    public int Amount { get; set; }
    public abstract int MaxStack { get; }

    public Potion(int i)
    {
        Amount = i;
    }

    protected virtual void ConsumePotion()
    {
        Amount -= 1;
    }

    public void UseConsumable()
    {
        ConsumePotion();
    }

    public void AddToStack(int amount)
    {
        Amount += amount;
    }
}
