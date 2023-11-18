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
        EventHandler.ChangeItemEvent += OnChangeItemEvent;
        EventHandler.MenuAfterSceneLoadedEvent += OnMenuAfterSceneLoadedEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        EventHandler.ChangeItemEvent -= OnChangeItemEvent;
        EventHandler.MenuAfterSceneLoadedEvent -= OnMenuAfterSceneLoadedEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }

    private void Start()
    {
        EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(ItemName.None), 0);
    }

    private void OnStartNewGameEvent(int obj)
    {
        itemList.Clear();
    }

    private void OnMenuAfterSceneLoadedEvent()
    {
        if (itemList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1);
        }
        else
        {
            //有多个物体，那么就逐一添加进去
            for (int i = 0; i < itemList.Count; i++)
            {
                EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemList[i]), i);
            }
        }
    }

    /// <summary>
    /// 左右按钮切换 物品UI显示
    /// </summary>
    /// <param name="index">传入物品的索引</param>
    private void OnChangeItemEvent(int index)
    {
        if (index >= 0 && index < itemList.Count)
        {
            var item = itemData.GetItemDetails(itemList[index]);
            EventHandler.CallUpdateUIEvent(item, index);
        }
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        var index = GetItemIndex(itemName);
        itemList.RemoveAt(index);

        if (itemList.Count != 0)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemList[i]), i);
            }
        }

        //包里没有东西
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

    /// <summary>
    /// 返回物品对应的序号
    /// </summary>
    private int GetItemIndex(ItemName itemName)
    {
        // for (int i = 0; i < itemList.Count; i++)
        // {
        //     if (itemList[i] == itemName)
        //         return i;
        // }
        //
        // return -1;
        return itemList.IndexOf(itemName);
    }

    public int GetListCount()
    {
        return itemList.Count;
    }
}