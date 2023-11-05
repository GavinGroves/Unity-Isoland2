using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool canClick;

    //获取鼠标点击为位置，屏幕坐标 -> 世界坐标
    private Vector3 MouseWorldPos =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private void Update()
    {
        canClick = ObjectAtMousePosition();

        if (canClick && Input.GetMouseButtonDown(0))
        {
            //检测鼠标互动情况
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    /// <summary>
    /// 互动-标签Tag判断
    /// </summary>
    /// <param name="clickObject">点击对应物体</param>
    private void ClickAction(GameObject clickObject)
    {
        switch (clickObject.tag)
        {
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                break;
            case "Item":
                var item = clickObject.GetComponent<Item>();
                item?.ItemClicked();
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