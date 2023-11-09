using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Interactive : MonoBehaviour
{
    [SerializeField] private ItemName requireItem;
    [SerializeField] private bool isDone;

    public void ClickItem(ItemName itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            isDone = true;
            //使用物品，背包移出物品
            OnClickedAction();
        }
    }
    
    protected virtual void OnClickedAction()
    {
        
    }

    public virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }
}
