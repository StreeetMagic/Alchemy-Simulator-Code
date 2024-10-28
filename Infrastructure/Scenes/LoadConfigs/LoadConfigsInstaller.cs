using Zenject;

namespace Code.Infrastructure.Scenes.LoadConfigs
{
  public class LoadConfigsInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<LoadConfigsInitializer>().FromInstance(GetComponent<LoadConfigsInitializer>()).AsSingle().NonLazy();
    }
  }
}