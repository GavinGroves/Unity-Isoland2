using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class CursorManager : MonoBehaviour
{
    public RectTransform hand;

    //获取鼠标点击为位置，屏幕坐标 -> 世界坐标
    private Vector3 MouseWorldPos =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private ItemName currentItem;
    private bool holdItem;
    private bool canClick;

    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
    }

    private void Update()
    {
        canClick = ObjectAtMousePosition();

        if (hand.gameObject.activeInHierarchy)
        {
            hand.position = Input.mousePosition;
        }

        if (canClick && Input.GetMouseButtonDown(0))
        {
            //检测鼠标互动情况
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        holdItem = isSelected;
        if (isSelected)
        {
            currentItem = itemDetails.itemName;
        }

        hand.gameObject.SetActive(holdItem);
    }

    /// <summary>
    /// 互动-标签Tag判断
    /// </summary>
    /// <param name="clickObject">点击对应物体</param>
    private void ClickAction(GameObject clickObject)
    {
        var globalTag = Enum.Parse<GlobalTag>(clickObject.tag);
        switch (globalTag)
        {
            case GlobalTag.Teleport:
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                break;
            case GlobalTag.Item:
                var item = clickObject.GetComponent<Item>();
                item?.ItemClicked();
                break;
            case GlobalTag.Interactive:
                var interactive = clickObject.GetComponent<Interactive>();
                if (holdItem)
                    interactive?.CheckItem(currentItem);
                else
                    interactive?.EmptyClicked();
                break;
        }
    }

    /// <summary>
    /// 判断是否点击到物体，并且返回物体的碰撞体;
    /// </summary>
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(MouseWorldPos);
    }
}