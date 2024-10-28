using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
  public sealed class CursorFeature : Feature
  {
    public CursorFeature(ISystemFactory systems)
    {
      Add(systems.Create<ToggleCursorSystem>());
    }
  }
}