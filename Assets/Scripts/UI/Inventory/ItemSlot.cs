using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemSlot : MonoBehaviour
{    
    public Image Icon;
    public IItemAdaptor Item { get; protected set; }
    public static GameObject ItemBeingDragged;

    protected TooltipTrigger _tooltip => GetComponent<TooltipTrigger>();

    protected Transform startParent => transform;
    protected Vector3 startPosition => transform.position;

    public void SetItem()
    {

    }
}
