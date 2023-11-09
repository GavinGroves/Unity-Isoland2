using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using EventHandler = Utilities.EventHandler;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private RectTransform hand;

    private Vector3 MousePoint =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private ItemName curentItem;
    private bool canClick;
    private bool holdItem; // holding the obj ?

    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
    }

    private void OnItemSelectedEvent(ItemDetail itemDetail, bool isSelected)
    {
        holdItem = isSelected;
        if (isSelected)
        {
            curentItem = itemDetail.itemName;
        }
        hand.gameObject.SetActive(holdItem);
    }

    private void Update()
    {
        canClick = GetMousePointObject();
        
        if(hand.gameObject.activeInHierarchy)
            hand.transform.position = Input.mousePosition;
        
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
            case GlobalTag.Interactive:
                var interactive = targetObj.gameObject.GetComponent<Interactive>();
                if (holdItem)
                    interactive?.ClickItem(curentItem);
                else 
                    interactive?.EmptyClicked();         
                break;
        }
    }

    private Collider2D GetMousePointObject()
    {
        return Physics2D.OverlapPoint(MousePoint);
    }
}