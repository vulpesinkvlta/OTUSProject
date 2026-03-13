using Code.Gameplay.Features.Scene.SaveLoad;
using Code.Infrastructure.Boot;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelMode.Installers
{
  public class SceneInstaller : MonoInstaller
  {
    [SerializeField] private EnemyConfig[] _enemyConfigs;
    [SerializeField] private PlayerFacade _playerFacadeMono;
    [SerializeField] private PlayerHealthMono _playerHealth;
    [SerializeField] private TowerView _towerPrefab;
    [SerializeField] private ThroneView _thronePrefab;
    [SerializeField] private ThroneConfig _throneConfig;
    public override void InstallBindings()
    {
      Container.Bind<Contexts>()
            .FromMethod(_ => Contexts.sharedInstance)
            .AsSingle();
      
      Container.Bind<PlayerFacade>().FromInstance(_playerFacadeMono).AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadContributor>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
      Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemyConfigs);
      Container.BindInterfacesAndSelfTo<BuildModeService>().AsSingle();
      Container.BindInterfacesAndSelfTo<FlowFieldService>().AsSingle();        
      Container.BindInterfacesAndSelfTo<GridService>().AsSingle();

     // Container.Bind<ThroneFactory>().AsSingle().WithArguments(_thronePrefab);
      Container.Bind<ThroneFactory>().AsSingle().WithArguments(_throneConfig);
      Container.Bind<TowerFactory>().AsSingle().WithArguments(_towerPrefab);

      Container.Bind<GameplayFeatures>().AsSingle();
    }
  }
}