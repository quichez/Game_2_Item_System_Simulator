using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventoryController : MonoBehaviour
{
    public GameObject EquipmentPanel;
    public GameObject InventoryPanel;

    private InventorySlot[] _invSlots => InventoryPanel.GetComponentsInChildren<InventorySlot>();
    private EquipmentSlot[] _equipSlots => EquipmentPanel.GetComponentsInChildren<EquipmentSlot>();

    private void Start()
    {
        Player.Instance.OnInventoryUpdateCallback += UpdateInventory;
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < _invSlots.Length; i++)
        {
            if(i < _equipSlots.Length)
            {
                _equipSlots[i].SetItem(Player.Instance.Inventory.Equipped[i]);
            }
            _invSlots[i].SetItem(Player.Instance.Inventory.Inv[i]);            
        }
    }

    private void OnEnable()
    {
        if(Player.Instance != null)
        {
            Player.Instance.OnInventoryUpdateCallback += UpdateInventory;
            UpdateInventory();
        }
    }

    private void OnDisable()
    {
        Player.Instance.OnInventoryUpdateCallback -= UpdateInventory;
    }
}
