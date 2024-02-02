using Scripts.Services;
using System.Collections;
using UnityEngine;

namespace Scripts.Saves
{
    public class DataSource : IService
    {
        public PlayerProgress PlayerProgress { get; set; }
        private const string DataKey = "PlayerData";

        public IEnumerator Load()
        {
            PlayerProgress = JsonUtility.FromJson<PlayerProgress>(
                PlayerPrefs.GetString(DataKey)) ?? new PlayerProgress();
            Debug.Log(PlayerPrefs.GetString(DataKey));
            yield break;
        }

        public void Save()
        {

            PlayerPrefs.SetString(DataKey, JsonUtility.ToJson(PlayerProgress));
            PlayerPrefs.Save();
        }
    }
}
