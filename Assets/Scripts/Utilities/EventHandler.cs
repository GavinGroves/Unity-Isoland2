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
    }
}