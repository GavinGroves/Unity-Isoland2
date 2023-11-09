using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private List<ItemName> itemNameList = new List<ItemName>();
    [SerializeField] private InventoryItemData_SO itemDataSo;

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        itemNameList.RemoveAt(GetItemListIndex(itemName));

        if (itemNameList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1);
        }
    }

    public void AddItem(ItemName itemName)
    {
        if (!itemNameList.Contains(itemName))
        {
            itemNameList.Add(itemName);
            EventHandler.CallUpdateUIEvent(itemDataSo.GetItemDetail(itemName), itemNameList.Count - 1);
        }
    }

    private int GetItemListIndex(ItemName itemName)
    {
        for (int i = 0; i < itemNameList.Count; i++)
        {
            if (itemNameList[i] == itemName)
                return i;
        }

        return -1;
    }
}