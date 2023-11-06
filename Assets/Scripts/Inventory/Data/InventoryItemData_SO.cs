using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

[CreateAssetMenu(menuName = "Inventory/InventoryItemData_SO", fileName = "InventoryItemData_SO")]
public class InventoryItemData_SO : ScriptableObject
{
    public List<ItemDetail> itemDetailsList;

    public ItemDetail GetItemDetail(ItemName itemName)
    {
        return itemDetailsList.Find(i => i.itemName == itemName);
    }
}

[System.Serializable]
public class ItemDetail
{
    public ItemName itemName;
    public Sprite itemIcon;
}