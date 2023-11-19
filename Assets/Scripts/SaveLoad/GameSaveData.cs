using System.Collections.Generic;
using Utilities;

namespace SaveLoad
{
    public class GameSaveData
    {
        public int gameWeek;
        public string currentScene;
        public Dictionary<string, bool> miniGameStateDict;
        public Dictionary<ItemName, bool> itemAvailableDict;
        public Dictionary<string, bool> interactiveStateDict;
        public List<ItemName> itemList;
    }
}