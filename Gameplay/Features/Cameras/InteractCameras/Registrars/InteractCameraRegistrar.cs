using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Registrars
{
  public class InteractCameraRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .AddCameraId(CameraId.Interact)
        .With(x => x.isInteractCamera = true)
        ;
    }

    public override void UnregisterComponents()
    {
      throw new System.NotImplementedException();
    }
  }
}