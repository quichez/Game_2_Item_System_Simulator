using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItemDispenser : MonoBehaviour
{
    public void DispenseItem(int item)
    {
        switch (item)
        {
            case 1:
                Player.Instance.Inventory.AddItem(new FlameDagger());
                break;
            case 2:
                Player.Instance.Inventory.AddItem(new OrnateAshwoodWand());
                break;
            case 3:
                Player.Instance.Inventory.AddItem(new DonutHat());
                break;
            case 4:
                Player.Instance.Inventory.AddItem(new HealthPotion(7));
                break;
            case 5:
                Player.Instance.Inventory.AddItem(new ManaPotion(3));
                break;
            case 6:
                Player.Instance.Inventory.AddItem(new RestorePotion(2));
                break;
            case 7:
                Player.Instance.Inventory.AddItem(new SerratedDagger());
                break;
            case 8:
                Player.Instance.Inventory.AddItem(new RustyBroadsword());
                break;
            default:
                break;
        }
    }
}
