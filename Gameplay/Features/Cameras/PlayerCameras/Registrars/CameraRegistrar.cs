using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.PlayerCameras.Registrars
{
  public class CameraRegistrar : EntityComponentRegistrar
  {
    [SerializeField]
    private Camera _camera;
    
    public override void RegisterComponents()
    {
      Entity.AddCamera(_camera);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasCamera)
        Entity.RemoveCamera();
    }
  }
}