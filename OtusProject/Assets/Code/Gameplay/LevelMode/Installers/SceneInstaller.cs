using Code.Gameplay.Features.Scene.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelMode.Installers
{
  public class SceneInstaller : MonoInstaller
  {
    [SerializeField] private PlayerFacade _playerFacadeMono;
    [SerializeField] private PlayerHealthMono _playerHealth;
    [SerializeField] private EnemyView _enemyPrefab;
    [SerializeField] private TowerView _towerPrefab;
    [SerializeField] private GameBootstrap bootstrap;

    public override void InstallBindings()
    {
      Debug.Log("Scene Installer");
      
      Container.Bind<PlayerFacade>().FromInstance(_playerFacadeMono).AsSingle();
      //Container.Bind<PlayerHealthMono>().FromInstance(_playerFacadeMono.PlayerHealthMono).AsSingle();
      Container.BindInterfacesAndSelfTo<GameBootstrap>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadContributor>().AsSingle();
      Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
      Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemyPrefab);
      Container.BindInstance(_towerPrefab);
      Container.Bind<GameplayFeatures>().AsSingle();
      Container.Bind<EnemyFactory>().AsSingle();
    }
  }
}