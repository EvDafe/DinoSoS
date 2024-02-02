using UnityEngine;

namespace Scripts.Skins
{
    public class SkinData : MonoBehaviour
    {
        [SerializeField] private Material _skinMaterial;

        public Material SkinMaterial => _skinMaterial;
    }
}