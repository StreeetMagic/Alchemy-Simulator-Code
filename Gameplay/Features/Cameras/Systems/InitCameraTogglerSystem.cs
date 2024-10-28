using Code.Common;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Gameplay.Features.Systems
{
  public class InitCameraTogglerSystem : IInitializeSystem
  {
    private IIdentifierService _identifiers;

    public InitCameraTogglerSystem(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public void Initialize()
    {
      CreateEntity
        .Empty()
        .AddId(_identifiers.Next())
        .AddCameraId(CameraId.Player)
        .With(x => x.isCameraToggler = true)
        ;
    }
  }
}