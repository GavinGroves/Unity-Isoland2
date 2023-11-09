using System;

namespace Utilities
{
    public static class EventHandler
    {
        public static event Action<ItemDetail, int> UpdateUIEvent;

        public static void CallUpdateUIEvent(ItemDetail itemDetail, int index)
        {
            UpdateUIEvent?.Invoke(itemDetail, index);
        }

        public static event Action SaveBeforeSceneEvent;

        public static void CallSaveBeforeEvent()
        {
            SaveBeforeSceneEvent?.Invoke();
        }
        
        public static event Action SaveAfterSceneEvent;

        public static void CallSaveAfterEvent()
        {
            SaveAfterSceneEvent?.Invoke();
        }

        public static event Action<ItemDetail, bool> ItemSelectedEvent;

        public static void CallItemSelectedEvent(ItemDetail itemDetail,bool isSelected)
        {
            ItemSelectedEvent?.Invoke(itemDetail,isSelected);
        }

        public static event Action<ItemName> ItemUsedEvent;

        public static void CallItemUsedEvent(ItemName itemName)
        {
            ItemUsedEvent?.Invoke(itemName);
        }
    }
}