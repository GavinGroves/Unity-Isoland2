using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemObjDict = new Dictionary<ItemName, bool>();
    private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();
    
    private void OnEnable()
    {
        EventHandler.SaveBeforeSceneEvent += OnSaveBeforeSceneEvent;
        EventHandler.SaveAfterSceneEvent += OnSaveAfterSceneEvent;
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.SaveBeforeSceneEvent -= OnSaveBeforeSceneEvent;
        EventHandler.SaveAfterSceneEvent -= OnSaveAfterSceneEvent;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    #region 切换场景前后 物品的保存与读取

    private void OnSaveBeforeSceneEvent()
    {
        foreach (var item in FindObjectsByType<Item>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (!itemObjDict.ContainsKey(item.itemName))
                itemObjDict.Add(item.itemName, item.gameObject.activeInHierarchy);
        }

        foreach (var interObj in FindObjectsOfType<Interactive>())
        {
            Debug.Log(interObj.name);
            if (interactiveStateDict.ContainsKey(interObj.name))
            {
                interactiveStateDict[interObj.name] = interObj.isDone;
            }
            else
            {
                interactiveStateDict.Add(interObj.name,interObj.isDone);
            }
        }
    }
    
    private void OnSaveAfterSceneEvent()
    {
        foreach (var item in FindObjectsByType<Item>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            if (!itemObjDict.ContainsKey(item.itemName))
                itemObjDict.Add(item.itemName, item.gameObject.activeInHierarchy);
            else
                item.gameObject.SetActive(itemObjDict[item.itemName]);
        }
        
        foreach (var interObj in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interObj.name))
            {
                interObj.isDone = interactiveStateDict[interObj.name] ;
            }
            else
            {
                interactiveStateDict.Add(interObj.name,interObj.isDone);
            }
        }
    }

    #endregion
    
    /// <summary>
    /// 场景物品点击后隐藏 , 所以 保存物品的字典里 物品状态要设置为FALSE
    /// </summary>
    private void OnUpdateUIEvent(ItemDetail itemDetail, int arg)
    {
        if (itemDetail != null)
        {
            itemObjDict[itemDetail.itemName] = false;
        }
    }
}