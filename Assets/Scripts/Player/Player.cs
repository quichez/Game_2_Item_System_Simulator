using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilityFactoryReflection;

public enum Element { Air, Water, Fire, Lightning}

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Inventory Inventory { get; private set; }
    public Spellbook Abilities { get; private set; }
    public GameObject testController;



    private void Awake()
    {
        if (Instance != null)
            return;
        else
            Instance = this;

        Inventory = new Inventory();
        Abilities = GetComponent<Spellbook>();

        //Test
        int i = 0;
        foreach (IItemAdaptor item in Inventory.Inv)
        {
            testController.transform.GetChild(i).GetComponent<TestItemDisplay>().SetText(item);
            i++;
        }
        //End Test
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetElementalBonuses(Element element)
    {
        int bonus = 0;
        foreach (Equipment item in Instance.Inventory.Inv)
        {
            ElementalStat stat = item.Stats.Find(x => x.Element == element);
            if (stat != null)
                bonus += stat.Amount;
        }
        return bonus;
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

public class Inventory
{
    public List<IItemAdaptor> Inv { get; private set; }
    public Weapon EquippedWeapon { get; private set; }

    public Inventory()
    {
        Inv = new List<IItemAdaptor>()
        {
            new FlameDagger(), 
            new OrnateAshwoodWand(),
            new MistLightningRod(),
            new RustyBroadsword()
        };

        EquippedWeapon = (Weapon)Inv[0];
    }
}