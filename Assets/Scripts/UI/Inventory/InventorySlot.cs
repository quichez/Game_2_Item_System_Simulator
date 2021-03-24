using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : ItemSlot, IPointerDownHandler, IBeginDragHandler, IDragHandler,IEndDragHandler,IDropHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Item != null && Item.ID != -1)
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
            if (ItemBeingDragged.transform.parent == startParent)
            {
                ItemBeingDragged.transform.position = startPosition;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (ItemBeingDragged)
        {
            ItemSlot temp = ItemBeingDragged.transform.parent.GetComponent<ItemSlot>();
            if(temp != this)
            {
                //Swap Items in inventory
            }
        }
    }
}
