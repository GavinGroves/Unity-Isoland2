using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool> miniGameStateDict = new Dictionary<string, bool>();

    void Awake()
    {
        EventHandler.CallGameStateChangedEvent(GameState.Playing);
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += AfterSceneLoadedEvent;
        EventHandler.GamePassEvent += OnGamePassEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= AfterSceneLoadedEvent;
        EventHandler.GamePassEvent -= OnGamePassEvent;
    }

    private void OnGamePassEvent(string gameName)
    {
        miniGameStateDict[gameName] = true;
    }

    private void AfterSceneLoadedEvent()
    {
        foreach (var miniGame in FindObjectsOfType<MiniGame>())
        {
            if (miniGameStateDict.TryGetValue(miniGame.gameName, out bool isPass))
            {
                miniGame.isPass = isPass;
                miniGame.UpdateMiniGameState();
            }
        }
    }
}