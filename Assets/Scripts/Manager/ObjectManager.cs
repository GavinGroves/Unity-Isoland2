using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemObjDict = new Dictionary<ItemName, bool>();

    private void OnEnable()
    {
        EventHandler.SaveBeforeEvent += OnSaveBeforeEvent;
        EventHandler.SaveAfterEvent += OnSaveAfterEvent;
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.SaveBeforeEvent -= OnSaveBeforeEvent;
        EventHandler.SaveAfterEvent -= OnSaveAfterEvent;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnSaveBeforeEvent()
    {
        foreach (var item in FindObjectsByType<Item>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (!itemObjDict.ContainsKey(item.itemName))
                itemObjDict.Add(item.itemName, item.gameObject.activeInHierarchy);
        }
    }

    private void OnSaveAfterEvent()
    {
        foreach (var item in FindObjectsByType<Item>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (!itemObjDict.ContainsKey(item.itemName))
                itemObjDict.Add(item.itemName, item.gameObject.activeInHierarchy);
            else
                item.gameObject.SetActive(itemObjDict[item.itemName]);
        }
    }

    private void OnUpdateUIEvent(ItemDetail itemDetail, int index)
    {
        if (itemDetail != null)
        {
            itemObjDict[itemDetail.itemName] = false;
        }
    }
}