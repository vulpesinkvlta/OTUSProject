using Code.Infrastructure.Boot.AppInitializer;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class BootstrapInitializer : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<AppInitializer>().AsSingle();
    }
  }
}