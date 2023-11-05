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
    }
}