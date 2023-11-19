using System;
using UnityEngine;

namespace Utilities
{
    public static class EventHandler
    {
        /// <summary>
        /// UI更新事件
        /// </summary>
        public static event Action<ItemDetails, int> UpdateUIEvent;

        /// <summary>
        /// 呼叫UI更新事件
        /// </summary>
        public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            UpdateUIEvent?.Invoke(itemDetails, index);
        }

        /// <summary>
        /// 卸载场景之前
        /// </summary>
        public static event Action BeforeSceneUnloadEvent;

        public static void CallBeforeSceneUnloadEvent()
        {
            BeforeSceneUnloadEvent?.Invoke();
        }

        /// <summary>
        /// 载入场景之后
        /// </summary>
        public static event Action AfterSceneLoadedEvent;

        public static void CallAfterSceneLoadEvent()
        {
            AfterSceneLoadedEvent?.Invoke();
        }
        
        public static event Action MenuAfterSceneLoadedEvent;
        public static void CallMenuAfterSceneLoadedEvent()
        {
            MenuAfterSceneLoadedEvent?.Invoke();
        }

        /// <summary>
        /// 物品被选择事件
        /// </summary>
        public static event Action<ItemDetails, bool> ItemSelectedEvent;

        /// <summary>
        /// 呼叫物品被选择事件
        /// </summary>
        public static void CallItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
        {
            ItemSelectedEvent?.Invoke(itemDetails, isSelected);
        }

        /// <summary>
        /// 物品被使用事件
        /// </summary>
        public static event Action<ItemName> ItemUsedEvent;

        /// <summary>
        /// 呼叫物品被使用事件
        /// </summary>
        public static void CallItemUsedEvent(ItemName itemName)
        {
            ItemUsedEvent?.Invoke(itemName);
        }

        /// <summary>
        /// 多物品切换 UI物品变换事件
        /// </summary>
        public static event Action<int> ChangeItemEvent;

        /// <summary>
        /// 呼叫 多物品切换 UI物品变换事件
        /// </summary>
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

        public static event Action<string> GamePassEvent;

        public static void CallGamePassEvent(string gameName)
        {
            GamePassEvent?.Invoke(gameName);
        }

        //开始新游戏，清空所有数据
        public static event Action<int> StartNewGameEvent;

        public static void CallStartNewGameEvent(int gameWeek)
        {
            StartNewGameEvent?.Invoke(gameWeek);
        }
        
        //拾取道具动画
        public static event Action<Vector2, Sprite, ItemName> UpdateUIMoveEvent;
        public static void CallUpdateUIMoveEvent(Vector2 itemPos, Sprite itemImage, ItemName itemName)
        {
            UpdateUIMoveEvent?.Invoke(itemPos, itemImage, itemName);
        }
    }
}