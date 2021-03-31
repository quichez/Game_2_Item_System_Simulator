using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot : ItemSlot, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public EquipmentType SlotType;

    public void SetItem(Equipment equipment)
    {
        if(equipment.Type == SlotType || equipment.ID == -1)
        {
            Item = equipment;
            Icon.sprite = equipment.Icon;
            SetText(equipment);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //do nothing
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Item.ID != -1)
        {
            ItemBeingDragged = Icon.gameObject;
            Icon.GetComponent<CanvasGroup>().blocksRaycasts = false;
            Icon.GetComponent<Canvas>().sortingOrder = 2;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (ItemBeingDragged)
            ItemBeingDragged.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (ItemBeingDragged)
        {
            Icon.GetComponent<CanvasGroup>().blocksRaycasts = false;
            Icon.GetComponent<Canvas>().sortingOrder = 1;
            if (ItemBeingDragged.transform.parent == StartParent)
            {
                ItemBeingDragged.transform.position = StartPosition;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (ItemBeingDragged)
        {
            ItemSlot temp = ItemBeingDragged.transform.parent.GetComponent<ItemSlot>();
            switch (temp)
            {
                case InventorySlot invSlot:
                    if(temp.Item is Equipment)
                    {
                        if((temp.Item as Equipment).Type == SlotType)
                        {
                            Player.Instance.SwapEquipmentItem(this, invSlot);
                        }
                    }
                    invSlot.transform.GetChild(0).position = invSlot.StartPosition;
                    break;
                case EquipmentSlot equipSlot:
                    equipSlot.transform.GetChild(0).position = equipSlot.StartPosition;
                    break;
                default:
                    break;
            }

            ItemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = true;
            ItemBeingDragged.GetComponent<Canvas>().sortingOrder = 1;

            ItemBeingDragged = null;
        }

        SetText(Item);
    }
    
}
