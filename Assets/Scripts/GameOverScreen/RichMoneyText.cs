using Scripts.Money;
using Scripts.Scores;
using Scripts.Services;
using System;
using TMPro;
using UnityEngine;

namespace Scripts.GameOverScreen
{
    [RequireComponent(typeof(TMP_Text))]

    public class RichMoneyText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private MoneyText _moneyText;

        private ScoreSchetchik _schetchik;

        private void OnValidate() =>
            _text ??= GetComponent<TMP_Text>();

        private void OnEnable()
        {
            _schetchik = AllServices.Container.GetSingleton<ScoreSchetchik>();
            if(_text != null && _schetchik != null)
                _text.text = $"+{Mathf.RoundToInt(_schetchik.GetCurrentScore())}";
        }

        public void DoubleResult()
        {
            if (_text != null && _schetchik != null)
                _text.text = $"+{Mathf.RoundToInt(_schetchik.GetCurrentScore()) * 2}";
            _moneyText.UpdateText();
        }
    }
}
