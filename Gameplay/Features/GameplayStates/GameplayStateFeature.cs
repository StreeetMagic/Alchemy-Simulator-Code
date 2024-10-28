using Code.Gameplay.Features.States.AlchemyStates;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
  public sealed class GameplayStateFeature : Feature
  {
    public GameplayStateFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitGameplayStateHolderSystem>());
      Add(systems.Create<ExitAlchemyModeByExitButtonSystem>());
      Add(systems.Create<SetGameplayStateByChangerSystem>());
      Add(systems.Create<DeleteGameplayStateChangerWhenNoInteractKeyPressedSystem>());
      Add(systems.Create<DeleteGameplayStateChangerIfNoRaycastTargetSystem>());
      Add(systems.Create<RemoveAlchemyStateHolderIfNoAlchemyStateSystem>());

      Add(systems.Create<AlchemyStateFeature>());
    }
  }
}