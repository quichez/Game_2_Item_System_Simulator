using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { One, Two, Tree}

public class Player : MonoBehaviour
{
    public Inventory Inventory { get; private set; }
    public GameObject testController;



    private void Awake()
    {
        Inventory = new Inventory();

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
}

public class ElementalStat
{
    public Element Element { get; }
    public int Amount { get; }

    public ElementalStat(Element element, int amt)
    {
        Element = element;
        Debug.Log(Element.ToString());
        Amount = amt;
    }

    public override string ToString()
    {
        return Element.ToString() + " + " + Amount;
    }
} 


public class Inventory
{
    public List<IItemAdaptor> Inv { get; private set; }

    public Inventory()
    {
        Inv = new List<IItemAdaptor>();
        Inv.Add(new Weapon(ItemDatabase.GetWeaponByID(1001)));
        Inv.Add(new Weapon(ItemDatabase.GetWeaponByID(1101)));
        Inv.Add(new Weapon(ItemDatabase.GetWeaponByID(1201)));
        Inv.Add(new Consumable());
        Inv.Add(new Weapon(ItemDatabase.GetWeaponByID(2001)));
        Inv.Add(new Weapon(ItemDatabase.GetWeaponByID(3001)));       
    }
}