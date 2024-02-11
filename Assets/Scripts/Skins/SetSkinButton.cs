using Scripts.Services;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Skins
{
    [RequireComponent(typeof(Button))]
    public class SetSkinButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private int _id;
        private SkinContainer _skinContainer;

        private void OnValidate() => 
            _button ??= GetComponent<Button>();

        public void Initialize(int id, SkinContainer skinContainer)
        {
            _id = id;
            _skinContainer = skinContainer;
        }

        private void Start() => 
            _button.onClick.AddListener(SetSkin);

        private void SetSkin()
        {
            _skinContainer.SetSkin(_id);
            AllServices.Container.GetSingleton<DinoImage>().MakeDinoCake();
        }
    }
}
