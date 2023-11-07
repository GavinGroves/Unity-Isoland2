using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utilities;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    public ItemTooltip itemTooltip;
    private ItemDetails currentItem;
    private bool isSelected;

    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        this.gameObject.SetActive(true);
        itemImage.sprite = itemDetails.itemIcon;
        itemImage.SetNativeSize();
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
            itemTooltip.gameObject.SetActive(true);
            itemTooltip.UpdateItemName(currentItem.itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemTooltip.gameObject.SetActive(false);
    }
}