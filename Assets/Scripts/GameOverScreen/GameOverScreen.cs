using Scripts.Services;
using UnityEngine;

namespace Scripts.GameOverScreen
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;

        private GameStateTransmiter _gameState;

        private void Start()
        {
            _panel.SetActive(false);
            _gameState = AllServices.Container.GetSingleton<GameStateTransmiter>();
            _gameState.Died.AddListener(ShowPanel);
        }

        private void ShowPanel() => 
            _panel.SetActive(true);
    }
}
