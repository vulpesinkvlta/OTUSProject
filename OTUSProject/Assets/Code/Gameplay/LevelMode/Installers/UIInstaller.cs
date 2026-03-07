using Code.Gameplay.UI.Huds;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.LevelMode.Installers
{
  public class UIInstaller : MonoInstaller
  {
    [SerializeField] private HUD _hud;

    public override void InstallBindings()
    {
      Container.Bind<HUD>().FromInstance(_hud).AsSingle();
      //Container.Bind<HpBarUI>().FromInstance(_hud.HpBar).AsSingle();
      
      //Container.Bind<IHPBarController>().To<HPBarController>().AsSingle().NonLazy();
    }
  }
}