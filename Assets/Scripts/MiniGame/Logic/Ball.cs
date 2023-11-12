using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public BallDetails ballDetails;
    private bool isMatch;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBall(BallDetails ball)
    {
        ballDetails = ball;
        if (isMatch)
        {
            SetCorrect();
        }
        else
        {
            SetWrong();
        }
    }

    private void SetCorrect()
    {
        _spriteRenderer.sprite = ballDetails.correctSprite;
    }

    private void SetWrong()
    {
        _spriteRenderer.sprite = ballDetails.wrongSprite;
    }
}