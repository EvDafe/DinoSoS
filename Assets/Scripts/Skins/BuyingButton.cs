using Scripts.Services;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Skins
{
    [RequireComponent(typeof(Button))]

    public class BuyingButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;


        private int _id;
        private Shop _shop;
        private SkinContainer _skinContainer;

        private void OnValidate() =>
            _button ??= GetComponent<Button>();

        private void Start() =>
            _button.onClick.AddListener(BuySkin);

        public void Initialize(int id, Shop shop, SkinContainer skinContainer)
        {
            _id = id;
            _shop = shop;
            _skinContainer = skinContainer;
            _text.text = _skinContainer.Datas.ElementAt(_id).Cost.ToString();
        }

        private void BuySkin()
        {
            Debug.Log("BOUGHT");
            bool bought = _shop.BuySkin(_id);
            AllServices.Container.GetSingleton<DinoImage>().MakeDinoEmot(bought);
        }
    }
}
