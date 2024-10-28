using Code.Infrastructure.ConfigProviders;
using Zenject;

namespace Code.Infrastructure.ZenjectFactories.ProjectContext
{
  public class ProjectZenjectFactory : ZenjectFactory
  {
    public ProjectZenjectFactory(IInstantiator instantiator, DevConfigProvider devConfigProvider) : base(instantiator, devConfigProvider)
    {
    }
  }
}