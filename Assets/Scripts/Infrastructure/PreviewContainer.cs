using Scripts.Skins;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class PreviewContainer : MonoBehaviour
    {
        [SerializeField] private DinoView _view;
        [SerializeField] private Camera _camera;

        public DinoView View => _view;
        public Camera Camera => _camera;
    }
}
