using Code.Gameplay.Features.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
  public sealed class RaycastFeature : Feature
  {
    public RaycastFeature(ISystemFactory systems)
    {
      Add(systems.Create<RaycastSystem>());
      Add(systems.Create<CurrentInteractDistanceSystem>());
    }
  }
}