using DesperateDevs.Unity;
using System;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
{
    [SerializeField] private LoadingCurtain _curtainPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AppInitializer>().AsSingle();
        BindInfrastructureServices();
        BindContexts();
        BindGameFactories();
        BindGameStateMachine();

    }

    private void BindInfrastructureServices()
    {
        Container.Bind<IDIService>().To<DIService>().AsSingle();
        Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
        Container.BindInterfacesAndSelfTo<LoadingCurtain>()
            .FromComponentInNewPrefab(_curtainPrefab).AsSingle();
        Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle();
        Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void BindContexts()
    {
        Container.Bind<GameContext>().To<GameContext>().AsSingle();
    }

    private void BindGameFactories()
    {
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        Container.Bind<IState>().To<BootstrapState>().AsSingle();
        Container.Bind<IState>().To<LevelLoopState>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameStarter>().AsSingle();
    }
}