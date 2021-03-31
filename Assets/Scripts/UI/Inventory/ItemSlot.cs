using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{    
    public Image Icon;
    public Item Item { get; protected set; }
    public static GameObject ItemBeingDragged;

    protected string tooltipText;
    protected TooltipTrigger _tooltip => GetComponent<TooltipTrigger>();

    public Transform StartParent { get => transform; }
    public Vector3 StartPosition { get => transform.position; }


    protected void SetText(Item item)
    {
        if (item.ID == -1)
        {
            tooltipText = "";
            _tooltip.SetTooltipText(tooltipText);
            return;
        }

        switch (item)
        {
            case null:
                break;
            case Weapon weapon:
                tooltipText = weapon.Title + ": " + weapon.Damage + "\n" + weapon.Description;
                foreach (ElementalStat stat in weapon.Stats)
                {
                    tooltipText += "\n" + stat.ToString();

                }
                if (weapon.Rarity == Rarity.Legendary)
                {
                    if (weapon is ILegendaryEquipment temp)
                        tooltipText += "\n" + temp.SpecialProperty;
                }                
                break;
            case Armor armor:
                tooltipText = armor.Title + ": " + armor.Defense + "\n" + armor.Description;
                foreach(ElementalStat stat in armor.Stats)
                {
                    tooltipText += "\n" + stat.ToString();
                }
                if(armor is ILegendaryEquipment armorTemp)
                {
                    tooltipText += "\n" + armorTemp.SpecialProperty;
                }
                break;
            case IConsumable cons:
                if(cons is IStackable stack)
                {
                    tooltipText = item.Title + " (" + stack.Amount.ToString() + ")";
                }
                tooltipText += "\n" + item.Description;
                break;
            default:
                break;
        }

        _tooltip.SetTooltipText(tooltipText);
    }
}
