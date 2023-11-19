using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class Teleport : MonoBehaviour
{
     [SerializeField] private string sceneFrom;
     [SerializeField] private string sceneToGo;

    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom,sceneToGo);
    }
}