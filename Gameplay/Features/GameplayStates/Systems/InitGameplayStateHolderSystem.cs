using Code.Common;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Gameplay.Features
{
  public class InitGameplayStateHolderSystem : IInitializeSystem
  {
    private readonly IIdentifierService _identifiers;

    public InitGameplayStateHolderSystem(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public void Initialize()
    {
      CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddGameplayStateHolder(GameplayStateId.Walking)
        ;
    }
  }
}

