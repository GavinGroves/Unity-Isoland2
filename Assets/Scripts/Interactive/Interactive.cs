using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;
    public bool isDone;

    public void ClickItem(ItemName itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            isDone = true;
            
            //use Items
            OnClickedAction();

            //Remove Used Items From The Backpack
            EventHandler.CallItemUsedEvent(itemName);
        }
    }

    protected virtual void OnClickedAction()
    {
    }

    public virtual void EmptyClicked()
    {
        Debug.Log("EmptySpots");
    }
}