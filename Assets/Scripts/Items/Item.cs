using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public enum Rarity { Common, Uncommon, Rare, Legendary}
public enum EquipmentType { Weapon, Head, Chest, Pants, Gloves, Boots}
public enum ArmorType { One, Two, Three}

/*
 * ID Code: ABCDD
 * A: Item Type
 * 1: Weapon, 2: Armor, 3: Consumable
 * 
 * B: Item SubType (see subclasses)
 * 
 * C: Rarity
 * 0: Common or N/A, 1: Uncommon:, 2: Rare, 3: Legendary
 * 
 * DD: Item Number
 * 01-99 ~~ 99 different 
*/


public interface IItem
{
    int ID { get; }
    string Title { get; }
    string Description { get; }
    string Slug { get; }
    Sprite Icon { get; }
}

public class Item
{
    public virtual int ID { get; protected set; }
    public virtual string Title { get; protected set; }
    public virtual string Description { get; protected set; }
    public virtual string Slug { get; protected set; }
    public virtual Sprite Icon { get; protected set; }

    public Item()
    {
        ID = -1;
    }
}

public interface IStackable
{
    int Amount { get; set; }
    int MaxStack { get; }

    void AddToStack(int amount);    
}

public interface IConsumable
{
    void UseConsumable();
}

public interface IEquippable
{
    void Equip();
}

public class Equipment : Item
{
    public virtual Rarity Rarity { get; }
    public virtual EquipmentType Type { get; protected set; }
    public virtual string EquipmentSlug { get; protected set; }
    public List<ElementalStat> Stats = new List<ElementalStat>();
    public List<SpecialStat> SpecialStats = new List<SpecialStat>();
    public GameObject Model;

    public Equipment():base()
    {
        //Addressables.LoadAssetAsync<GameObject>("WandBase").Completed += OnModelLoadComplete;
    }

    private void OnModelLoadComplete(AsyncOperationHandle<GameObject> obj)
    {
        if(obj.Result == null)
        {
            return;
        }
        Model = obj.Result;
    }

    public void GetEquipmentModel(Transform t)
    {
        if (string.IsNullOrEmpty(EquipmentSlug))
        {
            Debug.Log(GetType().ToString() + " needs an EquipmentSlug!");
            return;
        }
        Addressables.InstantiateAsync(EquipmentSlug,t);
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