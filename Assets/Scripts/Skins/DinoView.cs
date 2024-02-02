using UnityEngine;

namespace Scripts.Skins
{
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class DinoView : MonoBehaviour
    {
        private SkinnedMeshRenderer _renderer;

        private void Awake() => 
            _renderer = GetComponent<SkinnedMeshRenderer>();

        public void SetSkin(SkinData data) => 
            _renderer.material = data.SkinMaterial;
    }
}
