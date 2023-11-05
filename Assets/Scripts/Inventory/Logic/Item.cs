using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        InventoryManager.Instance.AddItem(itemName);
        //点击后隐藏物体
        gameObject.SetActive(false);
    }
}
