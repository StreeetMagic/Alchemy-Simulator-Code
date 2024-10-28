using Code.Gameplay.Features.States.AlchemyStates.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.States.AlchemyStates
{
  public sealed class AlchemyStateFeature : Feature
  {
    public AlchemyStateFeature(ISystemFactory systems)
    {
      Add(systems.Create<CreateAlchemyStateHolderByEnterAlchemyGameplayStateSystem>());
      Add(systems.Create<SetAlchemyStateByChangerSystem>());
    }
  }
}