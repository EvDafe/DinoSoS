using Scripts.Services;
using UnityEngine;

namespace Scripts.Saves
{
    public class DataSource : IService
    {
        public PlayerProgress PlayerProgress { get; set; }
        private const string DataKey = "PlayerData";

        public void Load()
        {
            PlayerProgress = JsonUtility.FromJson<PlayerProgress>(
                PlayerPrefs.GetString(DataKey)) ?? new PlayerProgress();
            Debug.Log(PlayerPrefs.GetString(DataKey));
        }

        public void Save()
        {

            PlayerPrefs.SetString(DataKey, JsonUtility.ToJson(PlayerProgress));
            PlayerPrefs.Save();
        }
    }
}
