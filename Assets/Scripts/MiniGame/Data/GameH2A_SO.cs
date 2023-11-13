using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

[CreateAssetMenu(menuName = "Mini Game Data/GameH2A_SO_SO", fileName = "GameH2A_SO")]
public class GameH2A_SO : ScriptableObject
{
    [Header("球的名字和对应图片")] public List<BallDetails> ballDetailsList;

    [Header("游戏逻辑数据")] [Header("线的位置 点到点")]
    public List<Conections> lineConectionsList;

    [Header("球的初始位置")] public List<BallName> startBallOrder;

    public BallDetails GetBallDetails(BallName ballName)
    {
        return ballDetailsList.Find(i => i.ballName == ballName);
    }
}

[System.Serializable]
public class BallDetails
{
    public BallName ballName;
    public Sprite wrongSprite;
    public Sprite correctSprite;
}

[System.Serializable]
public class Conections
{
    public int from;
    public int to;
}