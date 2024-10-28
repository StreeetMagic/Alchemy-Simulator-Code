using Code.Infrastructure.ConfigProviders;
using Zenject;

namespace Code.Infrastructure.ZenjectFactories.GameobjectContext
{
  public class EnemyZenjectFactory : ZenjectFactory, IGameObjectZenjectFactory
  {
    public EnemyZenjectFactory(IInstantiator instantiator, DevConfigProvider devConfigProvider) : base(instantiator, devConfigProvider)
    {
    }
  }
}