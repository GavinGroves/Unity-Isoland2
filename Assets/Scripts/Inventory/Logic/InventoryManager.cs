using System.Collections.Generic;
using Tools;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private List<ItemName> itemNameList = new List<ItemName>();
    [SerializeField] private InventoryItemData_SO itemData;

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
        EventHandler.ChangeItemEvent += OnChangeItemEvent;
        EventHandler.SaveAfterSceneEvent += OnSaveAfterSceneEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        EventHandler.ChangeItemEvent -= OnChangeItemEvent;
        EventHandler.SaveAfterSceneEvent -= OnSaveAfterSceneEvent;
    }

    /// <summary>
    /// 加载场景后更新背包UI
    /// </summary>
    private void OnSaveAfterSceneEvent()
    {
        if (itemNameList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1);
        }
        else
        {
            for (int i = 0; i < itemNameList.Count; i++)
            {
                EventHandler.CallUpdateUIEvent(itemData.GetItemDetail(itemNameList[i]), i);
            }
        }
    }

    private void OnChangeItemEvent(int index)
    {
        if (index >= 0 && index <= itemNameList.Count)
        {
            var item = itemData.GetItemDetail(itemNameList[index]);
            EventHandler.CallUpdateUIEvent(item, index);
        }
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
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetail(itemName), itemNameList.Count - 1);
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