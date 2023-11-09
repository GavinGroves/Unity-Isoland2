using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utilities;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private ItemToolTip tooltip;
    private ItemDetail currentItem; //
    private bool isSelected; //

    public void SetItem(ItemDetail itemDetail)
    {
        currentItem = itemDetail;
        gameObject.SetActive(true);
        itemIcon.sprite = itemDetail.itemIcon;
        itemIcon.SetNativeSize();
    }

    public void SetEmpty()
    {
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        EventHandler.CallItemSelectedEvent(currentItem, isSelected);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.activeInHierarchy)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.ShowItemName(currentItem.itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}