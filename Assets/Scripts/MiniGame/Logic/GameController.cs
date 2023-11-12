using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameController : MonoBehaviour
{
    public GameH2A_SO gameData;

    public Transform[] holderTransforms;

    public GameObject lineParent;

    public LineRenderer linePrefab;

    public Ball ballPrefab;

    private void Start()
    {
        DrawLine();
        CreateBall();
    }

    /// <summary>
    /// 画线
    /// </summary>
    public void DrawLine()
    {
        foreach (var conentions in gameData.LineConectionsList)
        {
            var line = Instantiate(linePrefab, lineParent.transform);
            line.SetPosition(0, holderTransforms[conentions.from].position);
            line.SetPosition(1, holderTransforms[conentions.to].position);
        }
    }

    /// <summary>
    /// 造球
    /// </summary>
    public void CreateBall()
    {
        for (int i = 0; i < gameData.startBallOrder.Count; i++)
        {
            if (gameData.startBallOrder[i] == BallName.None)
            {
                holderTransforms[i].GetComponent<Holder>().isEmpty = true;
                continue;
            }

            var ball = Instantiate(ballPrefab, holderTransforms[i]);
            holderTransforms[i].GetComponent<Holder>().isEmpty = false;
            ball.SetBall(gameData.GetBallDetails(gameData.startBallOrder[i]));
        }
    }
}