using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity { Common, Uncommon, Rare, Legendary}
public enum WeaponType { Dagger, Sword, Wand}
public enum ArmorType { One, Two, Three}


public abstract class Item<T> : IItemAdaptor
{
    public int ID { get; protected set; }
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public string Slug { get; protected set; }
    //public Sprite Icon;
}

public interface IItemAdaptor
{
    int ID { get; }
    string Title { get; }
    string Description { get; }
    string Slug { get; }
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
    public Rarity Rarity { get; protected set; }
    public List<ElementalStat> Stats = new List<ElementalStat>();

    public Equipment()
    {
        ID = -1;
    }

    protected void SetStatBonuses(Rarity rarity)
    {
        Rarity = rarity;
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
                    Stats.Add(new ElementalStat((Element)val, Random.Range(5, 11)));
                }
                break;
            case Rarity.Legendary:
                break;
            default:
                break;
        }
    }
}

public class Consumable : Item<Consumable>
{
    
}

public class Weapon : Equipment
{
    public WeaponType Type { get; }
    public Vector2Int DamageRange { get; private set; }
    public int Damage { get; }

    //Create for database
    public Weapon(int id, string title, string desc, string slug, WeaponType type, Rarity rarity, Vector2Int dmgRange)
    {
        ID = id;
        Title = title;
        Description = desc;
        Slug = slug;
        Type = type;
        Rarity = rarity;
        DamageRange = dmgRange;
    }

    //Instantiate from weapon frame
    public Weapon(Weapon frame)
    {
        ID = frame.ID;
        Title = frame.Title;
        Description = frame.Description;
        Slug = frame.Slug;
        Type = frame.Type;
        Rarity = frame.Rarity;
        Damage = Random.Range(frame.DamageRange.x, frame.DamageRange.y + 1);

        SetStatBonuses(Rarity);
    }

    //Load from save file
    public Weapon(int id, string title, string desc, string slug, int type, int rarity, int dmg)
    {
        ID = id;
        Title = title;
        Description = desc;
        Slug = slug;
        Type = (WeaponType)type;
        Damage = Damage;
    }
}

public class Armor : Equipment
{
    public ArmorType Type { get; }
    public int Defense { get; }

    public Armor(Rarity rarity)
    {
        Type = ArmorType.One;
    }

    public Armor(int frame, Rarity rarity)
    {

    }
}