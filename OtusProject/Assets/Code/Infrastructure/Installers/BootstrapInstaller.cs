using Code.Gameplay.Features.Factory;
using Code.Infrastructure.Boot;
using Code.Infrastructure.Contexts;
using Code.Infrastructure.Services.Curtain;
using Code.Infrastructure.Services.DI;
using Code.Infrastructure.Services.Progress;
using Code.Infrastructure.Services.Register;
using Code.Infrastructure.Services.SaveLoad;
using Code.Infrastructure.Services.SceneLoad;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Infrastructure.StateMachine.States.Factory;

using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  //Infrastructure layer
  public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
  {
    [SerializeField] private LoadingCurtain _curtainPrefab;
    
    public override void InstallBindings()
    {
      BindInfrastructureServices();
      BindContexts();
      BindSaveLoadService();
      BindGameFactories();
      BindRegisterServices();
      BindGameStateMachine();
    }

    private void BindInfrastructureServices()
    {
      Container.Bind<IDIService>().To<DIService>().AsSingle();
      Container.Bind<IInputService>().To<StandaloneInput>().AsSingle();
      Container.Bind<IConfigDataService>().To<ConfigDataService>().AsSingle();
      Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
      Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadingCurtain>()
        .FromComponentInNewPrefab(_curtainPrefab).AsSingle();
    }

    private void BindRegisterServices()
    {
      Container.Bind<IRegisterService>().To<RegisterService>().AsSingle();
    }

    private void BindContexts()
    {
      Container.Bind<GameLayerContext>().To<GameLayerContext>().AsSingle();
    }

    private void BindSaveLoadService()
    {
      Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void BindGameFactories()
    {
      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
      Container.Bind<IUpgradeFactory>().To<UpgradeFactory>().AsSingle();
    }

    private void BindGameStateMachine()
    {
      Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
      Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
      Container.BindInterfacesAndSelfTo<LevelLoopState>().AsSingle();
    }
  }
}