using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using Utilities;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private List<ItemName> itemNameList = new List<ItemName>();
    [SerializeField] private InventoryItemData_SO itemDataSo;

    public void AddItem(ItemName itemName)
    {
        if (!itemNameList.Contains(itemName))
        {
            itemNameList.Add(itemName);
            EventHandler.CallUpdateUIEvent(itemDataSo.GetItemDetail(itemName), itemNameList.Count - 1);
        }
    }
}