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
        private DataSource _dataSource;

        private void OnValidate() => 
            _text ??= GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _wallet = AllServices.Container.GetSingleton<Wallet>();
            _dataSource = AllServices.Container.GetSingleton<DataSource>();
            _wallet.MoneyChanged += UpdateText;
            UpdateText();
        }

        private void OnDisable() => 
            _wallet.MoneyChanged -= UpdateText;

        public void UpdateText()
        {
            Debug.Log("Ti LOx");
            _text.text = string.Format("{0:d6}", _dataSource.PlayerProgress.Money);
            Debug.Log("Ti LOx x2");
        }
    }
}
