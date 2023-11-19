using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton, rightButton;
    public SlotUI slotUI;
    public int currentIndex; // 显示UI当前物品序号
    
    public Image propImage;

    [Header("拾取物品速度")] [Range(0f, 5f)] public float duration = 1f;

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
        EventHandler.UpdateUIMoveEvent += OnUpdateUIMoveEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
        EventHandler.UpdateUIMoveEvent -= OnUpdateUIMoveEvent;
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        if (itemDetails == null)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentIndex = index;
            slotUI.SetItem(itemDetails);

            // 更新左右按钮的交互状态
            var listCount = InventoryManager.Instance.GetListCount();
            leftButton.interactable = index > 0;
            rightButton.interactable = index < listCount - 1;

            // if (index == -1)
            // {
            //     leftButton.interactable = false;
            //     rightButton.interactable = false;
            // }
        }
    }

    /// <summary>
    /// 左右按钮的事件（每次添加物品都是显示最新添加的）
    ///  左右按钮onclick 绑定 该事件方法 控制左右+-
    /// </summary>
    /// <param name="amount">左-1 右+1</param>
    public void SwitchItem(int amount)
    {
        var listCount = InventoryManager.Instance.GetListCount();
        var index = currentIndex + amount;

        // 确保 index 在合法范围内（0 到 listCount）
        index = Mathf.Clamp(index, 0, listCount - 1);

        // if (index > currentIndex)
        // {
        //     leftButton.interactable = true;
        //     rightButton.interactable = false;
        // }
        // else if (index < currentIndex)
        // {
        //     leftButton.interactable = false;
        //     rightButton.interactable = true;
        // }
        // else //多于2个物体的情况
        // {
        //     leftButton.interactable = true;
        //     rightButton.interactable = true;
        // }

        EventHandler.CallChangeItemEvent(index);
    }

    /// <summary>
    /// 拾取物品动画
    /// </summary>
    private void OnUpdateUIMoveEvent(Vector2 itemPos, Sprite itemImage, ItemName itemName)
    {
        propImage.gameObject.SetActive(true);
        propImage.transform.position = itemPos;
        propImage.sprite = itemImage;
        propImage.SetNativeSize();

        propImage.transform.DOMove(transform.position, duration).OnComplete(
            () =>
            {
                propImage.gameObject.SetActive(false);
                InventoryManager.Instance.AddItem(itemName);
            });
    }
}