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
    
    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnUpdateUIEvent(ItemDetail itemDetail, int index)
    {
        if (itemDetail == null)
        {
            slotUI.SetEmpty();
        }
        else
        {
            slotUI.SetItem(itemDetail);
        }
    }
}