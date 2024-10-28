using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
  public sealed class InteractFeature : Feature
  {
    public InteractFeature(ISystemFactory systems)
    {
      Add(systems.Create<InteractSystem>());
    }
  }
}