using Code.Gameplay.Features.Desk.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Desk
{
  public sealed class DeskFeature : Feature
  {
    public DeskFeature(ISystemFactory systems)
    {
      Add(systems.Create<OnDeskInteractSystem>());
    }
  }
}