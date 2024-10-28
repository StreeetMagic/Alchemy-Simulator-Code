using Code.Common;
using Code.Infrastructure.Identifiers;
using Entitas;
using Zenject;

namespace Code.Gameplay.Features.Inputs.Systems
{
  public class InitializeInputSystem : IInitializeSystem
  {
    private IIdentifierService _identifiers;

    [Inject]
    private void Construct(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }
  
    public void Initialize()
    {
      CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .isUserInput = true;
    }
  }
}