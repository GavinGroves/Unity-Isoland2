using Tools;
using UnityEngine;
using UnityEngine.Events;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class GameController : Singleton<GameController>
{
    public UnityEvent OnFinish;
    [Header("游戏数据")] public GameH2A_SO gameData;

    public Transform[] holderTransforms;

    public GameObject lineParent;

    public LineRenderer linePrefab;

    public Ball ballPrefab;

    private void OnEnable()
    {
        EventHandler.CheckGameStateEvent += OnCheckGameStateEvent;
    }

    private void OnDisable()
    {
        EventHandler.CheckGameStateEvent -= OnCheckGameStateEvent;
    }

    private void Start()
    {
        DrawLine();
        CreateBall();
    }

    private void OnCheckGameStateEvent()
    {
        foreach (var ball in FindObjectsOfType<Ball>())
        {
            if (!ball.isMatch)
                return;
        }

        foreach (var holder in holderTransforms)
        {
            holder.GetComponent<Collider2D>().enabled = false;
        }
        
        EventHandler.CallGamePassEvent(gameData.gameName);
        OnFinish?.Invoke();
    }

    public void ResetGame()
    {
        foreach (var holder in holderTransforms)
        {
            if (holder.childCount > 0)
                Destroy(holder.GetChild(0).gameObject);
        }
        
        CreateBall();
    }

    /// <summary>
    /// 画线
    /// </summary>
    public void DrawLine()
    {
        foreach (var conentions in gameData.lineConectionsList)
        {
            var line = Instantiate(linePrefab, lineParent.transform);
            line.SetPosition(0, holderTransforms[conentions.from].position);
            line.SetPosition(1, holderTransforms[conentions.to].position);

            //创建每个holder的连接关系
            holderTransforms[conentions.from].GetComponent<Holder>().linkHolders
                .Add(holderTransforms[conentions.to].GetComponent<Holder>());
            holderTransforms[conentions.to].GetComponent<Holder>().linkHolders
                .Add(holderTransforms[conentions.from].GetComponent<Holder>());
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

            holderTransforms[i].GetComponent<Holder>().CheckBall(ball);
            holderTransforms[i].GetComponent<Holder>().isEmpty = false;
            ball.SetBall(gameData.GetBallDetails(gameData.startBallOrder[i]));
        }
    }
}