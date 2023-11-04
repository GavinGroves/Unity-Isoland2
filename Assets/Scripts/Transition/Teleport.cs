using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName] [SerializeField] private string sceneFrom;
    [SceneName] [SerializeField] private string sceneToGo;

    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom,sceneToGo);
    }
}