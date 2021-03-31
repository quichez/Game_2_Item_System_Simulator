using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestItemDisplay : MonoBehaviour
{
    private string tooltipText;
    private TooltipTrigger tooltipTrigger => GetComponent<TooltipTrigger>();

    public void SetText(Item item)
    {
        switch (item)
        {
            case null:
                break;
            case Weapon weapon:
                tooltipText = weapon.Title + ": " + weapon.Damage + "\n" + weapon.Description;
                foreach(ElementalStat stat in weapon.Stats)
                {
                    tooltipText += "\n" + stat.ToString();
                    
                }
                if (weapon.Rarity == Rarity.Legendary)
                {
                    ILegendaryEquipment temp = weapon as ILegendaryEquipment;
                    if (temp != null)
                        tooltipText += "\n" + temp.SpecialProperty;                  
                }
                tooltipTrigger.SetTooltipText(tooltipText);
                break;
            default:
                break;
        }
    }
}
