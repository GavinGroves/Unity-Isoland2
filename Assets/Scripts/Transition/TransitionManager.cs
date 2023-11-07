using System;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventHandler = Utilities.EventHandler;

public class TransitionManager : Singleton<TransitionManager>
{
    [SceneName] [SerializeField] private string startScene;
    [SerializeField] private CanvasGroup fadePanelGroup;
    [SerializeField] private float fadeDuration;

    private bool isFade;

    private void Start()
    {
        StartCoroutine(ChangeScene(string.Empty, startScene));
    }

    public void Transition(string from, string to)
    {
        if (!isFade)
            StartCoroutine(ChangeScene(from, to));
    }

    private IEnumerator ChangeScene(string from, string to)
    {
        yield return Fade(1);

        if (from != string.Empty)
        {
            EventHandler.CallSaveBeforeEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }

        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));

        EventHandler.CallSaveAfterEvent();
        yield return Fade(0);
    }

    private IEnumerator Fade(float targetFade)
    {
        isFade = true;
        fadePanelGroup.blocksRaycasts = true;
        float fadeSpeed = Mathf.Abs(fadePanelGroup.alpha - targetFade) / fadeDuration;
        while (!Mathf.Approximately(targetFade, fadePanelGroup.alpha))
        {
            fadePanelGroup.alpha = Mathf.MoveTowards(fadePanelGroup.alpha, targetFade, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        fadePanelGroup.blocksRaycasts = false;
        isFade = false;
    }
}