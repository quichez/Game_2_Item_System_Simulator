using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class TestInventoryController : MonoBehaviour
{
    public GameObject EquipmentPanel;
    public GameObject InventoryPanel;

    private InventorySlot[] _invSlots => InventoryPanel.GetComponentsInChildren<InventorySlot>();
    private EquipmentSlot[] _equipSlots => EquipmentPanel.GetComponentsInChildren<EquipmentSlot>();

    private void Start()
    {
        //Player.Instance.OnInventoryUpdateCallback += UpdateInventory;
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

        if(Player.Instance.WeaponHolder.childCount > 0)
        {
            Destroy(Player.Instance.WeaponHolder.GetChild(0).gameObject);
        }
        if (Player.Instance.HatHolder.childCount > 0)
        {
            Destroy(Player.Instance.HatHolder.GetChild(0).gameObject);
        }

        if (_equipSlots[0].Item.ID != -1)
        {
            (_equipSlots[0].Item as Equipment).GetEquipmentModel(Player.Instance.WeaponHolder);
        }
        if (_equipSlots[1].Item.ID != -1)
        {
            (_equipSlots[1].Item as Equipment).GetEquipmentModel(Player.Instance.HatHolder);
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
