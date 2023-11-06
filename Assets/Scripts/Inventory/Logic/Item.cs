using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Item : MonoBehaviour
{
    [SerializeField]private ItemName itemName;

    public void AddItemToTooltip()
    {
        InventoryManager.Instance.AddItem(itemName);
        gameObject.SetActive(false);
    }
}
