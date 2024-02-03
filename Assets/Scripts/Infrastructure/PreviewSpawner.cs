using Scripts.Services;
using Scripts.Skins;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class PreviewSpawner : MonoBehaviour, IService
    {
        [SerializeField] private Transform _startSpawnPosition;
        [SerializeField] private PreviewContainer _previewPrefab;
        [SerializeField] private PreviewContainer _base;
        [SerializeField] private Vector3 _spawnOffSet;

        private int _count = 1;

        public RenderTexture SpawnPreview(SkinData data)
        {
            PreviewContainer preview = Instantiate(_previewPrefab, _startSpawnPosition.position + _spawnOffSet * _count, Quaternion.identity);
            RenderTexture texture = new(_base.Camera.targetTexture);
            preview.Camera.targetTexture = texture;
            preview.View.SetSkin(data);
            _count++;
            return texture;
        }
    }
}
