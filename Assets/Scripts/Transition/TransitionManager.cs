using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using EventHandler = Utilities.EventHandler;

/// <summary>
/// 场景切换管理器
/// </summary>
public class TransitionManager : Singleton<TransitionManager>
{
    [SceneName] public string startScene;
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool isFade;
    private bool canTransition;

    private void OnEnable()
    {
        EventHandler.GameStateChangedEvent += OnGameStateChangedEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.GameStateChangedEvent -= OnGameStateChangedEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }

    // private void Start()
    // {
    //     StartCoroutine(TransitionToScene(string.Empty, startScene));
    // }
    
    private void OnGameStateChangedEvent(GameState gameState)
    {
        canTransition = gameState == GameState.Playing;
    }
    
    private void OnStartNewGameEvent(int gameWeek)
    {
        StartCoroutine(TransitionToScene("Menu", startScene));
    }

    public void Transition(string from, string to)
    {
        if (!isFade && canTransition)
        {
            StartCoroutine(TransitionToScene(from, to));
        }
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);

        if (from != string.Empty)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }

        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        //设置新场景为激活场景
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));

        if (from == "Menu")
            EventHandler.CallMenuAfterSceneLoadedEvent();
        
        EventHandler.CallAfterSceneLoadEvent();
        yield return Fade(0);
    }

    /// <summary>
    /// 淡入淡出场景
    /// </summary>
    /// <param name="targetAlpha">1黑，0透明</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        // 速度=路程/时间
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;
        isFade = false;
    }
}