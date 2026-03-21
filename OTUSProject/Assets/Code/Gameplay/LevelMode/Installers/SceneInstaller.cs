using Assets.Code.Gameplay.Features.Upgrades.UI;
using Code.Gameplay.Features.Scene.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelMode.Installers
{
  public class SceneInstaller : MonoInstaller
  {
    [SerializeField] private EnemyConfig[] _enemyConfigs;
    [SerializeField] private PlayerFacade _playerFacadeMono;
    [SerializeField] private TowerConfigs _towerConfig;
    [SerializeField] private ThroneConfig _throneConfig;
    [SerializeField] private ExperienceView _experienceView;
    [SerializeField] private TowerButtonView _towerButtonView;
    [SerializeField] private TowerView _towerView;
        public override void InstallBindings()
    {
      Container.Bind<Contexts>()
            .FromMethod(_ => Contexts.sharedInstance)
            .AsSingle();

      Container.Bind<ExperienceView>()
        .FromInstance(_experienceView)
        .AsSingle();

      Container.Bind<IPlayerProgressService>().To<PlayerProgressService>().AsSingle();
      Container.Bind<TowerConfigs>()
        .FromInstance(_towerConfig)
        .AsSingle();

      Container.Bind<TowerButtonView>()
        .FromInstance(_towerButtonView)
        .AsSingle();

     Container.Bind<TowerView>()
        .FromInstance(_towerView)
        .AsSingle();

            Container.Bind<ITowerLimitService>().To<TowerLimitService>().AsSingle();
      Container.BindInterfacesAndSelfTo<ExperienceController>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<TowerStats>().AsSingle().NonLazy();
      Container.BindInterfacesAndSelfTo<TowerStatsController>().AsSingle().NonLazy();
      Container.Bind<PlayerFacade>().FromInstance(_playerFacadeMono).AsSingle();
      Container.Bind<TowerPlacementSaveLoad>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadContributor>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
      Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemyConfigs);
      Container.BindInterfacesAndSelfTo<BuildModeService>().AsSingle();
      Container.BindInterfacesAndSelfTo<GridService>().AsSingle();

      Container.Bind<ThroneFactory>().AsSingle().WithArguments(_throneConfig);
      Container.Bind<TowerFactory>().AsSingle().WithArguments(_towerConfig);

      Container.Bind<GameplayFeatures>().AsSingle();
  
    }
  }
}