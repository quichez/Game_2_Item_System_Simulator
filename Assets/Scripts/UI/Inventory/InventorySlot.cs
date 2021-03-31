using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : ItemSlot, IPointerDownHandler, IBeginDragHandler, IDragHandler,IEndDragHandler,IDropHandler
{
    public TextMeshProUGUI text;

    public void SetItem(Item item)
    {
        Item = item;
        Icon.sprite = item.Icon;
        SetText(item);

        if(item is IStackable)
        {
            text.text = (item as IStackable).Amount.ToString();
        }
        else
        {
            text.text = "";
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Item.ID != -1)
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
                    if(invSlot != this)
                    {
                        Player.Instance.SwapInventoryItems(this, invSlot);
                    }
                    invSlot.transform.GetChild(0).position = invSlot.StartPosition;
                    break;
                case EquipmentSlot equipSlot:
                    Player.Instance.SwapEquipmentItem(equipSlot, this);
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
