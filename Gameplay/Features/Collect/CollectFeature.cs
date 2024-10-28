using Code.Gameplay.Features.Collect.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Collect
{
  public sealed class CollectFeature : Feature
  {
    public CollectFeature(ISystemFactory systems)
    {
      Add(systems.Create<CollectSystem>());
    }
  }
}