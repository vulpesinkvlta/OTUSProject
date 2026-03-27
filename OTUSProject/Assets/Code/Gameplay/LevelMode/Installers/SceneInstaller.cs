using Assets.Code.Gameplay.Features.Upgrades.UI;
using Code.Gameplay.Features.Scene.SaveLoad;
using System;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelMode.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig[] _enemyConfigs;
        [SerializeField] private TowerConfigs _towerConfig;
        [SerializeField] private ThroneConfig _throneConfig;
        [SerializeField] private ExperienceView _experienceView;
        [SerializeField] private TowerButtonView _towerButtonView;
        [SerializeField] private TowerView _towerView;
        [SerializeField] private FreeFlyCamera _freeFlyCamera;
        public override void InstallBindings()
        {
            Container.Bind<Contexts>().FromMethod(_ => Contexts.sharedInstance).AsSingle();
            BindProgressServices();
            BindTower();
            BindEnemy();
            BindBuildService();
            BindSaveLoadService();

            Container.Bind<GameplayFeatures>().AsSingle(); 
            Container.Bind<FreeFlyCamera>().FromInstance(_freeFlyCamera).AsSingle();
        }


        private void BindProgressServices()
        {
            Container.Bind<ExperienceView>().FromInstance(_experienceView).AsSingle();
            Container.Bind<IPlayerProgressService>().To<PlayerProgressService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ExperienceController>().AsSingle().NonLazy();
        }


        private void BindTower()
        {
            Container.Bind<TowerConfigs>().FromInstance(_towerConfig).AsSingle();
            Container.Bind<TowerButtonView>().FromInstance(_towerButtonView).AsSingle();
            Container.Bind<TowerView>().FromInstance(_towerView).AsSingle();
            Container.Bind<ITowerLimitService>().To<TowerLimitService>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerStats>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<TowerStatsController>().AsSingle().NonLazy();
            Container.Bind<TowerPlacementSaveLoad>().AsSingle();
            Container.Bind<ThroneFactory>().AsSingle().WithArguments(_throneConfig);
            Container.Bind<TowerFactory>().AsSingle().WithArguments(_towerConfig);
        }
        private void BindEnemy()
        {
            Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemyConfigs);
        }
        private void BindBuildService()
        {
            Container.BindInterfacesAndSelfTo<BuildModeService>().AsSingle();
            Container.BindInterfacesAndSelfTo<GridService>().AsSingle();
        }
        private void BindSaveLoadService()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadContributor>().AsSingle();
            Container.BindInterfacesAndSelfTo<SaveLoadSystem>().AsSingle();
        }
    }
}