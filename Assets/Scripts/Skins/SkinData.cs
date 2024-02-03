using UnityEngine;

namespace Scripts.Skins
{
    public class SkinData : MonoBehaviour
    {
        [SerializeField] private Material _skinMaterial;
        [SerializeField] private int _cost;

        public Material SkinMaterial => _skinMaterial;
        public int Cost => _cost;
    }
}