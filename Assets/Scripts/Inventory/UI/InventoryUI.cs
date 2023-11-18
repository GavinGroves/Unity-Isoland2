using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton, rightButton;
    public SlotUI slotUI;
    public int currentIndex; // 显示UI当前物品序号
    public int  b;

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

   private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        if (itemDetails == null)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentIndex = index;
            slotUI.SetItem(itemDetails);
            
            if (index > b)
            {
                b = currentIndex;
            }
            
            //每次添加一个物品都是显示最新的，所以右键是FALSE的
            if (index > 0)
            {
                leftButton.interactable = true;
                if (index == b)
                {
                    leftButton.interactable = true;
                    rightButton.interactable = false;
                }
            }
            
            if (index == -1)
            {
                leftButton.interactable = false;
                rightButton.interactable = false;
            }
        }
    }

    /// <summary>
    /// 左右按钮的事件（每次添加物品都是显示最新添加的）
    ///  左右按钮onclick 绑定 该事件方法 控制左右+-
    /// </summary>
    /// <param name="amount">左-1 右+1</param>
    public void SwitchItem(int amount)
    {
        var index = currentIndex + amount;
        if (index > currentIndex)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else if (index < currentIndex)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else //多于2个物体的情况
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }
        
        EventHandler.CallChangeItemEvent(index);
    }

    public void UpdateButtonDisplay(int index)
    {
        var total = InventoryManager.Instance.GetListCount();

        if (index <= 0)
        {
            leftButton.interactable = false;
            if (total <= 1)
            {
                rightButton.interactable = false;
            }
            else
            {
                rightButton.interactable = true;
            }
        }
        else if (index >= total - 1)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }
    }
}