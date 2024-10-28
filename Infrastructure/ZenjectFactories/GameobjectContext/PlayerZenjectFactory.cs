using Code.Infrastructure.ConfigProviders;
using Zenject;

namespace Code.Infrastructure.ZenjectFactories.GameobjectContext
{
  public class PlayerZenjectFactory : ZenjectFactory, IGameObjectZenjectFactory
  {
    public PlayerZenjectFactory(IInstantiator instantiator, DevConfigProvider devConfigProvider) : base(instantiator, devConfigProvider)
    {
    }
  }
}