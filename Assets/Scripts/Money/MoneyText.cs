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

        private DataSource _dataSource;

        private void OnValidate() => 
            _text ??= GetComponent<TMP_Text>();

        private void Start() => 
            _dataSource = AllServices.Container.GetSingleton<DataSource>();

        private void Update() => 
            _text.text = _dataSource.PlayerProgress.Money.ToString();
    }
}
