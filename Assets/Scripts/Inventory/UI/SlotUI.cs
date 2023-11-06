using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image itemIcon;

    public void SetItem(ItemDetail itemDetail)
    {
        gameObject.SetActive(true);
        itemIcon.sprite = itemDetail.itemIcon;
        itemIcon.SetNativeSize();
    }

    public void SetEmpty()
    {
        
    }
}
