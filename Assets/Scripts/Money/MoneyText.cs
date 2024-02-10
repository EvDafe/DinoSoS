using Scripts.Saves;
using Scripts.Services;
using TMPro;
using UnityEngine;

namespace Scripts.Money
{
    [RequireComponent(typeof(TMP_Text))]
    public class MoneyText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private Wallet _wallet;

        private void OnValidate() => 
            _text ??= GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _wallet = AllServices.Container.GetSingleton<Wallet>();
            _wallet.MoneyChanged += UpdateText;
            UpdateText();
        }

        private void UpdateText() =>
            _text.text = string.Format("{0:d6}", Mathf.RoundToInt(_wallet.Money));
    }
}
