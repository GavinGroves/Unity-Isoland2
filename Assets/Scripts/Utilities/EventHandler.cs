using System;

namespace Utilities
{
    public static class EventHandler
    {
        public static event Action<ItemDetails, int> UpdateUIEvent;

        public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            UpdateUIEvent?.Invoke(itemDetails, index);
        }

        public static event Action BeforeSceneUnloadEvent;

        public static void CallBeforeSceneUnloadEvent()
        {
            BeforeSceneUnloadEvent?.Invoke();
        }

        public static event Action AfterSceneLoadedEvent;

        public static void CallAfterSceneLoadEvent()
        {
            AfterSceneLoadedEvent?.Invoke();
        }

        public static event Action<ItemDetails, bool> ItemSelectedEvent;

        public static void CallItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
        {
            ItemSelectedEvent?.Invoke(itemDetails, isSelected);
        }

        public static event Action<ItemName> ItemUsedEvent;

        public static void CallItemUsedEvent(ItemName itemName)
        {
            ItemUsedEvent?.Invoke(itemName);
        }
    }
}