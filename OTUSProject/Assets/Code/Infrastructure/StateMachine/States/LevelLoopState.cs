using Code.Infrastructure._Common.Abstractions;
using Code.Infrastructure.Contexts;
using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.Services.SceneLoad;
using System;
using UnityEngine;

namespace Code.Infrastructure.StateMachine.States
{
  public class LevelLoopState : IState, ITick
  {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoaderService _sceneLoader;
        private readonly ILoadingCurtain _curtain;
        private readonly GameLayerContext _gameContext;
        private readonly ISaveLoadService _saveLoad;
        private readonly IExperienceService _experienceService;
        private bool _isLevelUpTransition;

        public LevelLoopState(IGameStateMachine stateMachine,
          ISceneLoaderService sceneLoader,
          ILoadingCurtain curtain,
          GameLayerContext gameContext,
          ISaveLoadService saveLoad,
          IExperienceService experienceService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameContext = gameContext;
            _saveLoad = saveLoad;
            _experienceService = experienceService;
        }

        public void Enter()
        {
            _isLevelUpTransition = false;
            _experienceService.OnLevelChanged += OnLevelChanged;
            Debug.Log("Enter Level Loop State");
            _gameContext.Initialize();
        }

        public void Exit()
        {
            _experienceService.OnLevelChanged -= OnLevelChanged;

            if (_isLevelUpTransition)
                return;

            _saveLoad.Save();
            _saveLoad.Cleanup();
            _gameContext.Cleanup();
            Debug.Log("LoadLevelState Exit");
        }

        public void Tick()
        {
            _gameContext.Tick();
        }

        private void OnLevelChanged()
        {
            _isLevelUpTransition = true;
            _stateMachine.Enter<LevelUpState>();
        }
    }
}