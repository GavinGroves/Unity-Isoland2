using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class CursorManager : MonoBehaviour
{
    private Vector3 MousePoint =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private bool canClick;

    private void Update()
    {
        canClick = GetMousePointObject();
        if (canClick && Input.GetMouseButtonDown(0))
        {
            ClickAction(GetMousePointObject().gameObject);
        }
    }

    private void ClickAction(GameObject targetObj)
    {
        var globalTag = Enum.Parse<GlobalTag>(targetObj.tag);
        switch (globalTag)
        {
            case GlobalTag.Teleport:
                targetObj.gameObject.GetComponent<Teleport>().TeleportToScene();
                break;
            case GlobalTag.Item:
                targetObj.gameObject.GetComponent<Item>().AddItemToTooltip();
                break;
        }
    }

    private Collider2D GetMousePointObject()
    {
        return Physics2D.OverlapPoint(MousePoint);
    }
}