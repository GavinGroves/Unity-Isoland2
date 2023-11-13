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

        public static event Action<int> ChangeItemEvent;

        public static void CallChangeItemEvent(int index)
        {
            ChangeItemEvent?.Invoke(index);
        }

        public static event Action<string> ShowDialogueEvent;

        public static void CallShowDialogueEvent(string dialogue)
        {
            ShowDialogueEvent?.Invoke(dialogue);
        }

        public static event Action<GameState> GameStateChangedEvent;

        public static void CallGameStateChangedEvent(GameState gameState)
        {
            GameStateChangedEvent?.Invoke(gameState);
        }

        public static event Action CheckGameStateEvent;

        public static void CallCheckGameStateEvent()
        {
            CheckGameStateEvent?.Invoke();
        }
    }
}