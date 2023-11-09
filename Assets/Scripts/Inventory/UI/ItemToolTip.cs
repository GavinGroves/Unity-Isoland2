using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField]private Text itemNameText;

    public void ShowItemName(ItemName itemName)
    {
        itemNameText.text = itemName switch
        {
            ItemName.Key => "一把钥匙",
            ItemName.Ticket => "一张船票",
            _ => ""
        };
    }
}