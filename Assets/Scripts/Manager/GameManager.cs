using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        EventHandler.CallGameStateChangedEvent(GameState.Playing);
    }
}