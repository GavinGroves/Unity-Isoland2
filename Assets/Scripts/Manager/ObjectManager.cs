using System;
using System.Collections;
using System.Collections.Generic;
using SaveLoad;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class ObjectManager : MonoBehaviour,ISaveable
{
    //场景物品存储
    private Dictionary<ItemName, bool> itemAvailableDict = new Dictionary<ItemName, bool>();

    //场景状态存储
    private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void Start()
    {
        //保存数据
        ISaveable saveable = this;
        saveable.SaveableRegister();
    }
    
    private void OnItemUsedEvent(ItemName obj)
    {
        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
            {
                interactiveStateDict[interactive.name] = interactive.isDone;
            }
            else
            {
               interactiveStateDict.Add(interactive.name, interactive.isDone);
            }
        }
    }

    //场景切换前 保存
    private void OnBeforeSceneUnloadEvent()
    {
        //一些变换是切换场景后进行，所以卸载场景也要保存一次
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
                itemAvailableDict.Add(item.itemName, true);
        }

        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
                interactiveStateDict[interactive.name] = interactive.isDone;
            else
                interactiveStateDict.Add(interactive.name, interactive.isDone);
        }
    }

    /// <summary>
    /// 场景切换后 加载
    /// </summary>
    private void OnAfterSceneLoadedEvent()
    {
        //切换后的场景会判断 场景中的物体有没有添加进字典 ， 已经有了就判断激活状态
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))
                itemAvailableDict.Add(item.itemName, true);
            else
                item.gameObject.SetActive(itemAvailableDict[item.itemName]);
        }

        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
                interactive.isDone = interactiveStateDict[interactive.name];
            else
                interactiveStateDict[interactive.name] = interactive.isDone;
        }
    }
    
    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        //拾取物体后，字典保存的场景Item状态就为FALSE
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.itemName] = false;
        }
    }

    private void OnStartNewGameEvent(int gameWeek)
    {
        itemAvailableDict.Clear();
        interactiveStateDict.Clear();
    }

    public GameSaveData GenerateSaveData()
    {
        GameSaveData saveData = new GameSaveData();
        saveData.itemAvailableDict = this.itemAvailableDict;
        saveData.interactiveStateDict = this.interactiveStateDict;
        return saveData;
    }

    public void RestoreGameData(GameSaveData saveData)
    {
        this.itemAvailableDict = saveData.itemAvailableDict;
        this.interactiveStateDict = saveData.interactiveStateDict;
    }
}