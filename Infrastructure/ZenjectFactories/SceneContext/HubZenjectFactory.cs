using Code.Infrastructure.ConfigProviders;
using Zenject;

namespace Code.Infrastructure.ZenjectFactories.SceneContext
{
  public class HubZenjectFactory : ZenjectFactory
  {
    public HubZenjectFactory(IInstantiator instantiator, DevConfigProvider devConfigProvider) : base(instantiator, devConfigProvider)
    {
    }
  }
}