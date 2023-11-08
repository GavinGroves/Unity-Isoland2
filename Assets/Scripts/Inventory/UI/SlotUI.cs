using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
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
}
