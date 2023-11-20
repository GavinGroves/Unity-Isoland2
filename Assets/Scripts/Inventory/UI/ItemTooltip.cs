using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] private Text itemNameText;

    public void UpdateItemName(ItemName itemName)
    {
        itemNameText.text = itemName switch
        {
            ItemName.Key => "开锁道具",
            ItemName.Ticket => "一张船票",
            ItemName.Book => "不明物体",
            _=>""
        };
        
        // switch (itemName)
        // {
        //     case ItemName.Key:
        //         itemNameText.text = "信箱钥匙";
        //         break;
        //     case ItemName.Ticket:
        //         itemNameText.text = "一张船票";
        //         break;
        // }
    }
}