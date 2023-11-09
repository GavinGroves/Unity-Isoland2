using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Utilities.EventHandler;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private SlotUI slotUI;
    private int currentIndex; //

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    /// <summary>
    /// UI显示物品（只在拾取物品时候调用）
    /// </summary>
    private void OnUpdateUIEvent(ItemDetail itemDetail, int index)
    {
        if (itemDetail == null)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentIndex = index;
            slotUI.SetItem(itemDetail);

            // 添加物品会显示最新添加的物品，所以左侧亮
            if (index > 0)
                leftButton.interactable = true;

            if (index == -1)
            {
                leftButton.interactable = false;
                rightButton.interactable = false;
            }
        }
    }

    /// <summary>
    /// 按键显隐判断
    /// </summary>
    /// <param name="amount">左-1，右+1</param>
    public void SwitchItem(int amount)
    {
        var index = currentIndex + amount;
        if (index < currentIndex)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if (index > currentIndex)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else // 多于两个物体的情况
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        EventHandler.CallChangeItemEvent(index);
    }
}