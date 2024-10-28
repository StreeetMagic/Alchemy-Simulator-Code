using Code.Gameplay.Features.Flasks.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Flasks
{
  public sealed class MixingFlaskFeature : Feature
  {
    public MixingFlaskFeature(ISystemFactory systems)
    {
      Add(systems.Create<ShakeMixingFlaskSystem>());
      Add(systems.Create<MoveMixingFlaskOnMixingStateEnterSystem>());
      Add(systems.Create<MoveMixingFlaskOnMixingStateExit>());
      Add(systems.Create<MoveMixingFlaskOnShakingStateEnterSystem>());
      Add(systems.Create<MoveMixingFlaskOnShakingStateExit>());
    }
  }
}
