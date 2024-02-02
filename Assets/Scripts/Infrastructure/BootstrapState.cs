using Scripts.Services;
using Scripts.Saves;

namespace Scripts.Infrastructure
{
    internal class BootstrapState : IState
    {
        private const string BootSceneName = "BootStrapScene";
        private const string GameSceneName = "Hz";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;


        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(BootSceneName, EnterLoadLevel);
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadLevelState, string>(GameSceneName);

        private void RegisterServices()
        {
            _services.RigisterSingle(new DataSource());
        }

        public void Exit()
        {

        }
    }
}
