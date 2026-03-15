using Assets.Code.Gameplay.Features.Upgrades.UI;
using Code.Gameplay.Features.Gold.Services;
using UnityEngine;
using Zenject;


namespace Code.Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<GoldService>().AsSingle();
      Container.Bind<ICardUIPresenter>().To<CardContainerPresenter>().AsSingle();
    }
  }
}