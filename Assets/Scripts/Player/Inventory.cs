using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory
{
    public List<Item> Inv { get; private set; }
    public List<Equipment> Equipped { get; private set; }
    public Weapon EquippedWeapon { get; private set; }

    private Player _player;

    public Inventory(Player player)
    {
        _player = player;
        Inv = new List<Item>(20);
        Equipped = new List<Equipment>(6);

        for (int i = 0; i < 20; i++)
        {
            if (i < 6)
            {
                Equipped.Add(new Equipment());
            }
            Inv.Add(new Item());
        }

        Inv[0] = new FlameDagger();
        Inv[1] = new OrnateAshwoodWand();
        Inv[2] = new MistLightningRod();
        Inv[3] = new RustyBroadsword();
        Inv[4] = new DonutHat();
        Inv[5] = new HealthPotion(5);

        Equipped[0] = new FlameDagger();
        //EquippedWeapon = (Weapon)Equipped[0];
    }

    public bool AddItem(Item other)
    {
        switch (other)
        {
            case IStackable stack:
                List<Item> itemList = Inv.FindAll(x => x.GetType() == stack.GetType());
                List<IStackable> stackList = itemList.OfType<IStackable>().ToList();
                foreach (IStackable stackable in stackList)
                {
                    if(stackable.Amount == stackable.MaxStack)
                    {
                        continue;
                    }
                    else if(stackable.Amount + stack.Amount > stackable.MaxStack)
                    {
                        Debug.Log("Add to remaining stack");
                        int remainder = stackable.MaxStack - stackable.Amount;
                        stackable.AddToStack(remainder);
                        stack.Amount -= remainder;
                        _player.OnInventoryUpdateCallback?.Invoke();
                        continue;
                    }
                    else
                    {
                        Debug.Log("Add to stack");
                        stackable.AddToStack(stack.Amount);
                        _player.OnInventoryUpdateCallback?.Invoke();
                        return true;
                    }
                }
                if(stack.Amount != 0)
                {
                    for (int i = 0; i < Inv.Capacity; i++)
                    {
                        if (Inv[i].ID == -1)
                        {
                            Inv[i] = other;
                            _player.OnInventoryUpdateCallback?.Invoke();
                            return true;
                        }
                    }
                }
                return false;

            default:
                for (int i = 0; i < Inv.Capacity; i++)
                {
                    if (Inv[i].ID == -1)
                    {
                        Inv[i] = other;
                        _player.OnInventoryUpdateCallback?.Invoke();
                        return true;
                    }
                }
                return false;
        }        
    }

    public void RemoveItem(Item other)
    {
        Inv.Remove(other);
    }

    public void SwapInventoryItems(InventorySlot a, InventorySlot b)
    {
        int one = a.transform.GetSiblingIndex();
        int two = b.transform.GetSiblingIndex();

        Item temp = Inv[one];
        Inv[one] = Inv[two];
        Inv[two] = temp;
    }

    public void SwapEquipmentItem(EquipmentSlot a, InventorySlot b)
    {
        int one = a.transform.GetSiblingIndex(); //Equipment
        int two = b.transform.GetSiblingIndex(); //Inventory

        if(b.Item.ID == -1 || a.SlotType == (b.Item as Equipment).Type)
        {
            Item temp = Inv[two];                   //save inv item temporarily
            Inv[two] = Equipped[one] as Item;       //put equipment into inventory
            if(temp is Equipment)
            {
                Equipped[one] = temp as Equipment;  //put temp equipment into inventory (if it is equipment)
            }
            else
            {
                Equipped[one] = new Equipment();
            }
        }


    }
}
