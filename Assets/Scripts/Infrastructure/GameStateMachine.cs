using Scripts.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        private SceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, AllServices services, ICoroutineRunner coroutineRunner)
        {
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, _sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, _sceneLoader, curtain, _coroutineRunner),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            IPayLoadedState<TPayLoad> state = ChangeState<TState>();
            state.Enter(payLoad);
        }
    }
}
