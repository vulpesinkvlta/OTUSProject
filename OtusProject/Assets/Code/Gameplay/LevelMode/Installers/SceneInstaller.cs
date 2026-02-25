using Code.Gameplay.Features.Scene.SaveLoad;
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
    public override void InstallBindings()
    {
      Debug.Log("Scene Installer");
      Container.Bind<Contexts>()
            .FromMethod(_ => Contexts.sharedInstance)
            .AsSingle();
      
      Container.Bind<PlayerFacade>().FromInstance(_playerFacadeMono).AsSingle();
      //Container.Bind<PlayerHealthMono>().FromInstance(_playerFacadeMono.PlayerHealthMono).AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadContributor>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
      Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemyConfigs);
      Container.BindInstance(_towerPrefab);
      Container.Bind<GameplayFeatures>().AsSingle();
    }
  }
}