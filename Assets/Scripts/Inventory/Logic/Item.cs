using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Item : MonoBehaviour
{
    public ItemName itemName;
    private Camera mainCamera;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }
    public void ItemClicked()
    {
        //获取屏幕坐标和图片
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        Sprite image = transform.GetComponent<SpriteRenderer>().sprite;

        EventHandler.CallUpdateUIMoveEvent(screenPosition, image, itemName);
        // InventoryManager.Instance.AddItem(itemName);
        //点击后隐藏物体
        gameObject.SetActive(false);
    }
}
