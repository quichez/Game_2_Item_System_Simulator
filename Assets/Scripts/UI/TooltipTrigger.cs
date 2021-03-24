using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Header { get; private set; }
    public string Content { get; private set; }

    public void SetTooltipText(string content, string header = "")
    {
        Header = header;
        Content = content;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(Content, Header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }

    
}
