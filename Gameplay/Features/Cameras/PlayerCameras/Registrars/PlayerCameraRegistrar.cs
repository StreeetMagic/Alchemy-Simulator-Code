using Code.Common;
using Code.Gameplay.Features.Player.Configs;
using Code.Infrastructure.ConfigProviders;
using Code.Infrastructure.View.Registrars;
using Zenject;

namespace Code.Gameplay.Features.PlayerCameras.Registrars
{
  public class PlayerCameraRegistrar : EntityComponentRegistrar
  {
    private BalanceConfigProvider _configProvider;
  
    [Inject]
    public void Construct(BalanceConfigProvider configProvider)
    {
      _configProvider = configProvider;
    }

    public override void RegisterComponents()
    {
      PlayerMoverConfig config = _configProvider.PlayerMover;

      Entity
        .AddCameraId(CameraId.Player)
        .AddDefaultPositionY(transform.localPosition.y)
        .AddCameraInitialLookSpeedX(config.LookSpeedX)
        .AddCameraInitialLookSpeedY(config.LookSpeedY)
        .AddCameraLowerLookLimit(config.LowerLookLimit)
        .AddCameraUpperLookLimit(config.UpperLookLimit)
        .With(x => x.isPlayerCamera = true)
        .With(x => x.isActiveCamera = true)
        .With(x => x.isRotationReady = true)
        ;
    }

    public override void UnregisterComponents()
    {
      throw new System.NotImplementedException();
    }
  }
}