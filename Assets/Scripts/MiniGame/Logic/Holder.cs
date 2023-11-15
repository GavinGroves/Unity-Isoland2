using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Holder : Interactive
{
    private Ball currentBall;//现在格子下的球

    public BallName matchBall;//当前格子正确的球
    
    public HashSet<Holder> linkHolders = new HashSet<Holder>();
    public bool isEmpty;

    public void CheckBall(Ball ball)
    {
        currentBall = ball;
        if (ball.ballDetails.ballName == matchBall)
        {
            currentBall.isMatch = true;
            currentBall.SetCorrect();
        }
        else
        {
            currentBall.isMatch = false;
            currentBall.SetWrong();
        }
    }

    public override void EmptyClicked()
    {
        foreach (var holder in linkHolders)
        {
            if (holder.isEmpty)
            {
                //移动球
                currentBall.transform.position = holder.transform.position;
                currentBall.transform.SetParent(holder.transform);

                //交换球
                holder.CheckBall(currentBall);
                this.currentBall = null;

                //改变状态
                this.isEmpty = true;
                holder.isEmpty = false;
                
                EventHandler.CallCheckGameStateEvent();
            }
        }
    }
}