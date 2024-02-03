using Scripts.Saves;
using Scripts.Services;
using System.Collections;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            StartCoroutine(nameof(LoadProgress));
        }

        private IEnumerator LoadProgress()
        {
            var dataSource = new DataSource();
            AllServices.Container.RigisterSingle(dataSource);
            yield return dataSource.Load();
        }
    }
}
