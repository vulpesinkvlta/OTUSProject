using Zenject;

namespace Code.Gameplay.LevelMode.Installers
{
  public class SystemsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UpgradeSystem>().AsSingle().NonLazy();
    }
  }
}