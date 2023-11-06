using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    [SerializeField] private CanvasGroup fadePanelGroup;
    [SerializeField] private float fadeDuration;

    private bool isFade;

    public void Transition(string from, string to)
    {
        if (!isFade)
            StartCoroutine(ChangeScene(from, to));
    }

    private IEnumerator ChangeScene(string from, string to)
    {
        yield return Fade(1);
        yield return SceneManager.UnloadSceneAsync(from);
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
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