using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        switch (targetObj.tag)
        {
            case "Teleport":
                targetObj.gameObject.GetComponent<Teleport>().TeleportToScene();
                break;
        }
    }

    private Collider2D GetMousePointObject()
    {
        return Physics2D.OverlapPoint(MousePoint);
    }
}