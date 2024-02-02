using Scripts.Services;
using Scripts.Saves;
using System.Collections;

namespace Scripts.Infrastructure
{
    public class LoadLevelState : IPayLoadedState<string>
    {

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly ICoroutineRunner _coroutineRunner;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _coroutineRunner = coroutineRunner;
        }

        public void Enter(string payLoad)
        {
            _curtain.Show();
            _coroutineRunner.StartCoroutine(LoadProgress());
            _sceneLoader.Load(payLoad, OnLoad);
        }

        private void OnLoad() => 
            _stateMachine.Enter<GameLoopState>();

        private IEnumerator LoadProgress()
        {
            yield return AllServices.Container.Single<DataSource>().Load();
        }

        public void Exit() =>
            _curtain.Hide();
    }
}
