using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        //加载游戏进度
    }

    public void GoBackToMenu()
    {
        var currenScene = SceneManager.GetActiveScene().name;
        TransitionManager.Instance.Transition(currenScene, "Menu");

        //保存游戏进度
    }

    public void StartGameWeek(int gameWeek)
    {
        EventHandler.CallStartNewGameEvent(gameWeek);
    }
}