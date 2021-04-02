using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;
using Scima.ResourceSystems;

public enum Element { Air, Water, Fire, Lightning}

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Inventory Inventory { get; private set; }
    public Spellbook Abilities { get; private set; }
    public HealthSystem Health { get; private set; }
    public ManaSystem Mana { get; protected set; }

    public Transform WeaponHolder;
    public Transform HatHolder;

    public delegate void OnPlayerUpdate();
    public OnPlayerUpdate OnInventoryUpdateCallback;

    private void Awake()
    {
        if (Instance != null)
            return;
        else
            Instance = this;

        Inventory = new Inventory(this);
        Abilities = GetComponent<Spellbook>();
        Health = new HealthSystem(this,100, 1000, 1, 2.0f);
        Mana = new ManaSystem(this,100, 1000, 1, 2.0f);
    }

    void Start()
    {
        //Load Player Data

        //OnInventoryUpdateCallback?.Invoke();
    }

    void Update()
    {
        
    }

    public int GetElementalBonuses(Element element)
    {
        int bonus = 0;
        foreach (Equipment item in Instance.Inventory.Equipped)
        {
            if(item.ID == -1)
            {
                continue;
            }
            ElementalStat stat = item.Stats.Find(x => x.Element == element);
            if (stat != null)
                bonus += stat.Amount;
        }
        return bonus;
    }

    public void SwapInventoryItems(InventorySlot a, InventorySlot b)
    {
        Inventory.SwapInventoryItems(a, b);
        OnInventoryUpdateCallback?.Invoke();
    }

    public void SwapEquipmentItem(EquipmentSlot a, InventorySlot b)
    {
        Inventory.SwapEquipmentItem(a, b);
        OnInventoryUpdateCallback?.Invoke();
    }
}

public class ElementalStat
{
    public Element Element { get; }
    public int Amount { get; }

    public ElementalStat(Element element, int amt)
    {
        Element = element;       
        Amount = amt;
    }

    public override string ToString()
    {
        return Element.ToString() + " + " + Amount;
    }
} 

public class SpecialStat
{
    public string Effect { get; }
    public Ability Source { get; }
    public Ability Target { get; }
    public int Mult { get; }
    string Description { get; }

    public SpecialStat(string effect, string src, string tgt, int amt, string desc)
    {
        Effect = effect;
        Source = AbilityFactory.GetAbilityActive(src);
        Target = AbilityFactory.GetAbilityActive(tgt);
        Mult = amt;
        Description = desc;
        //Debug.Log(Player.Instance.Abilities);
    }
    
    public void SpecialEffect(Ability abil, MonoBehaviour caller)
    {
        switch (Effect)
        {
            case "BuffSkill":
                break;
            case "BuffSkillTimed":
                break;
            default:
                break;
        }
    }

    public override string ToString()
    {
        return Description;
    }
}