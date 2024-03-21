using Scripts.Money;
using Scripts.Saves;
using Scripts.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private PreviewSpawner _previewSpawner;

        public static Bootstrapper Instance { get; private set; }

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
            AllServices.Container.RegisterSingleton(dataSource);
            AllServices.Container.RegisterSingleton(wallet);
            AllServices.Container.RegisterSingleton(_previewSpawner);
            dataSource.Load();
        }
    }
}
