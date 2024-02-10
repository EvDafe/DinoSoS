using Scripts.Saves;
using Scripts.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Skins
{
    public class ShopFiller : MonoBehaviour
    {
        [SerializeField] private BuyingCell _buttonPrefab;
        [SerializeField] private Transform _buttonsContainer;
        [SerializeField] private Shop _shop;
        [SerializeField] private SkinContainer _skinContainer;

        private void Awake()
        {
            FillShop();
        }

        private void FillShop()
        {
            for(int i = 0; i < _skinContainer.Datas.Count; i++)
            {
                BuyingCell button = Instantiate(_buttonPrefab, _buttonsContainer);
                button.Initialize(_shop, i, _skinContainer);
            }
            gameObject.SetActive(false);
        }
    }
}
