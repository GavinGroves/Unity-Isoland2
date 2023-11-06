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
    }

    private void OnDisable()
    {
        EventHandler.SaveBeforeEvent -= OnSaveBeforeEvent;
        EventHandler.SaveAfterEvent -= OnSaveAfterEvent;
    }
    
    private void OnSaveBeforeEvent()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            // itemObjDict.Add(item.itemName,);
        }
    }

    private void OnSaveAfterEvent()
    {

    }
}
