using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventHandler = Utilities.EventHandler;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        //加载游戏进度
        SaveLoadManager.Instance.Load();
    }

    public void GoBackToMenu()
    {
        var currenScene = SceneManager.GetActiveScene().name;
        TransitionManager.Instance.Transition(currenScene, "Menu");

        //保存游戏进度
        SaveLoadManager.Instance.Save();
    }

    /// <summary>
    /// 开始新游戏 多周目
    /// </summary>
    public void StartGameWeek(int gameWeek)
    {
        EventHandler.CallStartNewGameEvent(gameWeek);
    }
}