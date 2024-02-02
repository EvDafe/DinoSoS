using Scripts.Services;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        private ICoroutineRunner _coroutineRunner;
        private LoadingCurtain _curtain;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            _coroutineRunner = coroutineRunner;
            _curtain = curtain;
            StateMachine = new GameStateMachine(new SceneLoader(_coroutineRunner), _curtain, AllServices.Container, _coroutineRunner);
        }
    }
}
