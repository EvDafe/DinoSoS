using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _curtain;
        
        private Game _game;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _game = new(this, _curtain);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}
