using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity { Common, Uncommon, Rare, Legendary}
public enum WeaponType { Dagger, Sword, Wand}
public enum ArmorType { One, Two, Three}

/*
 * ID Code: ABCC
 * A: Item Type
 * 1: Dagger, 2: Sword, 3: Wand
 * 
 * B: Rarity
 * 0: Common, 1: Uncommon:, 2: Rare, 3: Legendary
 * 
 * CC: Item Number
 * 01-99 ~~ 99 different 
*/


public interface IItemAdaptor
{
    int ID { get; }
    string Title { get; }
    string Description { get; }
    string Slug { get; }
    Sprite Icon { get; }
}

public abstract class Item<T> : IItemAdaptor
{
    public abstract int ID { get; }
    public abstract string Title { get; }
    public abstract string Description { get; }
    public abstract string Slug { get; }
    public Sprite Icon { get; }
}

public interface IStackable
{
    bool IsStackable { get; }
}

public interface IConsumable
{
    void UseConsumable();
}

public interface IEquippable
{
    void Equip();
}

public abstract class Equipment : Item<Equipment>
{
    //public override 
    public abstract Rarity Rarity { get; }
    public List<ElementalStat> Stats = new List<ElementalStat>();
    public List<SpecialStat> SpecialStats = new List<SpecialStat>();

    public Equipment()
    {
        
    }

    protected void SetStatBonuses(Rarity rarity)
    {
        //Rarity = rarity;
        int elementList = System.Enum.GetNames(typeof(Element)).Length;
        List<int> roll = new List<int>();
        switch (rarity)
        {
            case Rarity.Common:                
                Stats.Add(new ElementalStat((Element)Random.Range(1, elementList), Random.Range(1, 6)));
                break;
            case Rarity.Uncommon:
                while (roll.Count < 2)
                {
                    int r1 = Random.Range(0, elementList);
                    if (!roll.Contains(r1))
                        roll.Add(r1);                    
                }
                foreach (int val in roll)
                {
                    Stats.Add(new ElementalStat((Element)val, Random.Range(1, 6)));
                }                                
                break;
            case Rarity.Rare:
                while (roll.Count < 2)
                {
                    int r1 = Random.Range(0, elementList);
                    if (!roll.Contains(r1))
                        roll.Add(r1);
                }
                foreach (int val in roll)
                {
                    Stats.Add(new ElementalStat((Element)val, Random.Range(6, 11)));
                }
                break;
            case Rarity.Legendary:
                while (roll.Count < 2)
                {
                    int r1 = Random.Range(0, elementList);
                    if (!roll.Contains(r1))
                        roll.Add(r1);
                }
                foreach (int val in roll)
                {
                    Stats.Add(new ElementalStat((Element)val, Random.Range(11, 21)));
                }
                break;            
        }
    }
}

public abstract class Consumable : Item<Consumable>
{
    
}