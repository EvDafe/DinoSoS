using System;
using System.Collections.Generic;

namespace Scripts.Saves
{
    [Serializable]
    public class PlayerProgress
    {
        public int LastSkinIndex = 0;

        public List<int> UnlockedSkins = new() { 0 };
    }
}
