using Scripts.Money;
using Scripts.Saves;
using Scripts.Services;
using Scripts.Skins;
using UnityEngine;
using YG;

namespace Scripts.Scores
{
    public class ScoreSchetchik : MonoBehaviour, IService
    {
        [SerializeField] private float _scoreCoef;
        [SerializeField] private DinoView _dino;
        [SerializeField] private Transform _startPos;

        private GameStateTransmiter _transmiter;
        private int _score;
        private Transform _schetPosition;
        private bool _canSchet;
        private DataSource _data;
        private Wallet _wallet;
        private int _startMoney;

        public int Score => _score;

        private void Awake() => 
            AllServices.Container.RegisterSingleton<ScoreSchetchik>(this);

        private void Start()
        {
            _transmiter = AllServices.Container.GetSingleton<GameStateTransmiter>();
            _data = AllServices.Container.GetSingleton<DataSource>();
            _wallet = AllServices.Container.GetSingleton<Wallet>();
            _transmiter.StartGame.AddListener(StartChet);
            _transmiter.Died.AddListener(SetBest);
        }

        public float GetCurrentScore()
        {
            if (_canSchet == false)
                return 0;
            float distance = Vector3.Distance(_schetPosition.position, _dino.transform.position);
            if (_transmiter.Alive)
                _data.PlayerProgress.Money = _startMoney + Mathf.RoundToInt(distance * _scoreCoef); 
            _wallet.AddMoney(0);
            return distance * _scoreCoef;
        }

        private void SetBest()
        {
            if (GetCurrentScore() > _data.PlayerProgress.BestScore)
            {
                _data.PlayerProgress.BestScore = Mathf.RoundToInt(GetCurrentScore());
                YandexGame.NewLeaderboardScores("Score", _data.PlayerProgress.BestScore);
            }
            _data.Save();
        }

        private void StartChet()
        {
            _schetPosition = Instantiate(_startPos, _dino.transform.position, Quaternion.identity);
            _canSchet = true;
            _startMoney = _data.PlayerProgress.Money;
        }
    }
}
