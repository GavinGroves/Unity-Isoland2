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

        public static event Action SaveBeforeEvent;

        public static void CallSaveBeforeEvent()
        {
            SaveBeforeEvent?.Invoke();
        }
        
        public static event Action SaveAfterEvent;

        public static void CallSaveAfterEvent()
        {
            SaveAfterEvent?.Invoke();
        }
    }
}