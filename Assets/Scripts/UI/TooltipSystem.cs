using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem Instance;
    public Tooltip tooltip;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public static void Show(string content, string header = "")
    {
        if (!string.IsNullOrEmpty(content))
        {
            Instance.tooltip.SetText(content, header);
            Instance.tooltip.gameObject.SetActive(true);
        }
    }

    public static void Hide() => Instance.tooltip.gameObject.SetActive(false);

}
