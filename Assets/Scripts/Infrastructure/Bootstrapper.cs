using Scripts.Saves;
using Scripts.Services;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private PreviewSpawner _previewSpawner;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            LoadProgress();
        }

        private void LoadProgress()
        {
            var dataSource = new DataSource();
            AllServices.Container.RegisterSingleton<DataSource>(dataSource);
            AllServices.Container.RegisterSingleton<PreviewSpawner>(_previewSpawner);
            dataSource.Load();
        }
    }
}
