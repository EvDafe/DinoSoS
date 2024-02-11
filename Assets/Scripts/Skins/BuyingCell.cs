using Scripts.Infrastructure;
using Scripts.Saves;
using Scripts.Services;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Skins
{
    public class BuyingCell : MonoBehaviour
    {
        [SerializeField] private BuyingButton _buyingButton;
        [SerializeField] private SetSkinButton _setSkinButton;
        [SerializeField] private RawImage _preview;

        private Shop _shop;
        private int _id;
        private SkinContainer _skinContainer;
        private DataSource _dataSource;

        private void OnEnable()
        {
            _dataSource ??= AllServices.Container.GetSingleton<DataSource>();
            UpdateView();
        }

        private void OnDisable() =>
            DisableButtons();

        public void Initialize(Shop shop, int id, SkinContainer skinContainer)
        {
            _shop = shop;
            _id = id;
            _skinContainer = skinContainer;
            _preview.texture = AllServices.Container.GetSingleton<PreviewSpawner>().SpawnPreview(_skinContainer.Datas.ElementAt(id));
            _setSkinButton.Initialize(id, skinContainer);
            _buyingButton.Initialize(id, shop, skinContainer);
            _shop.BoughtSkin.AddListener(UpdateView);
        }

        private void DisableButtons()
        {
            _buyingButton.gameObject.SetActive(false);
            _setSkinButton.gameObject.SetActive(false);
        }


        private void UpdateView()
        {
            if (_dataSource.PlayerProgress.UnlockedSkins.Contains(_id))
                _setSkinButton.gameObject.SetActive(true);
            else
                _buyingButton.gameObject.SetActive(true);
        }
    }
}
