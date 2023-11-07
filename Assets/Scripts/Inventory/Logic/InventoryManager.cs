using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;
    [SerializeField] private List<ItemName> itemList = new List<ItemName>();

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
        // itemList.Remove(itemName);
        var index = GetItemIndex(itemName);
        itemList.RemoveAt(index);

        if (itemList.Count == 0)
            EventHandler.CallUpdateUIEvent(null, -1);
    }

    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
        }
    }

    private int GetItemIndex(ItemName itemName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
                return i;
        }

        return -1;
    }
}