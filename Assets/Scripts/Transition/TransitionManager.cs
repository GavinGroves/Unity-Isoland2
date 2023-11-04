using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景切换管理器
/// </summary>
public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool isFade;

    public void Transition(string from, string to)
    {
        if (!isFade)
        {
            StartCoroutine(TransitionToScene(from, to));
        }
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);
        yield return SceneManager.UnloadSceneAsync(from);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        //设置新场景为激活场景
        var newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

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