using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
  public sealed class RotationFeature : Feature
  {
    public RotationFeature(ISystemFactory systems)
    {
      Add(systems.Create<HorizontalRotationByMouseInputSystem>());
      Add(systems.Create<SetTransformByHorizontalRotationMouseInputSystem>());
      Add(systems.Create<VerticalRotationByMouseInputSystem>());
    }
  }
}