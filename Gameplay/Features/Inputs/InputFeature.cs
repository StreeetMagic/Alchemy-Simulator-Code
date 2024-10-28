using Code.Gameplay.Features.Inputs.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Inputs
{
  public sealed class InputFeature : Feature
  {
    public InputFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeInputSystem>());
      Add(systems.Create<EmitInputSystem>());
    }
  }
}