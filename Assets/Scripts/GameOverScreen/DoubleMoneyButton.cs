using Scripts.Money;
using Scripts.Scores;
using Scripts.Services;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Scripts.GameOverScreen
{
        [RequireComponent(typeof(Button))]
    public class DoubleMoneyButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private RichMoneyText _text;

        private ScoreSchetchik _schetchik;
        private Wallet _wallet;

        private void OnValidate() =>
            _button ??= GetComponent<Button>();

        private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

        private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

        private void Awake() => _button.onClick.AddListener(ShowAd);

        private void Rewarded(int id)
        {
            AddMoney();
            _text.DoubleResult();
            Destroy(gameObject);
        }

        private void AddMoney()
        {
            _schetchik = AllServices.Container.GetSingleton<ScoreSchetchik>();
            _wallet = AllServices.Container.GetSingleton<Wallet>();
            _wallet.AddMoney(Mathf.RoundToInt(_schetchik.GetCurrentScore()));
        }

        private void ShowAd() => 
            YandexGame.RewVideoShow(0);
    }
}
