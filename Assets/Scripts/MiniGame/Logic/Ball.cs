using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public BallDetails ballDetails;
    public bool isMatch;

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

    public void SetCorrect()
    {
        _spriteRenderer.sprite = ballDetails.correctSprite;
    }

    public void SetWrong()
    {
        _spriteRenderer.sprite = ballDetails.wrongSprite;
    }
}