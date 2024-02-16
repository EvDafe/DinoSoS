using Scripts.Money;
using Scripts.Saves;
using Scripts.Services;
using UnityEditor;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private PreviewSpawner _previewSpawner;

        public static Bootstrapper Instance { get; private set; }
        public static int LastSongID { get; set; } = -1;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
            else
            {
                if (Instance != this) Destroy(gameObject);
            }
            LoadProgress();
        }

        private void LoadProgress()
        {
            var dataSource = new DataSource();
            var wallet = new Wallet(dataSource);
            AllServices.Container.RegisterSingleton<DataSource>(dataSource);
            AllServices.Container.RegisterSingleton<Wallet>(wallet);
            AllServices.Container.RegisterSingleton<PreviewSpawner>(_previewSpawner);
            dataSource.Load();
        }
    }
}
