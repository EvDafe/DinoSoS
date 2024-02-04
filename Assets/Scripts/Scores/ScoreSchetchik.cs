using Scripts.Saves;
using Scripts.Services;
using Scripts.Skins;
using System;
using UnityEngine;

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

        public int Score => _score;

        private void Awake() => 
            AllServices.Container.RegisterSingleton<ScoreSchetchik>(this);

        private void Start()
        {
            _transmiter = AllServices.Container.GetSingleton<GameStateTransmiter>();
            _data = AllServices.Container.GetSingleton<DataSource>();
            _transmiter.StartGame.AddListener(StartChet);
            _transmiter.Died.AddListener(SetBest);
        }

        public float GetCurrentScore()
        {
            if (_canSchet == false)
                return 0;
            float distance = Vector3.Distance(_schetPosition.position, _dino.transform.position);
            return distance * _scoreCoef;
        }

        private void SetBest()
        {
            if (GetCurrentScore() > _data.PlayerProgress.BestScore)
            {
                _data.PlayerProgress.BestScore = Mathf.RoundToInt(GetCurrentScore());
                _data.Save();
            }
            _data.PlayerProgress.Money += (int)GetCurrentScore();
        }

        private void StartChet()
        {
            _schetPosition = Instantiate(_startPos, _dino.transform.position, Quaternion.identity);
            _canSchet = true;
        }
    }
}
