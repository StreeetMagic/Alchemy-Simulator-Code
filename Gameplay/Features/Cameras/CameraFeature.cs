using Code.Gameplay.Features.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features
{
  public sealed class CameraFeature : Feature
  {
    public CameraFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitCameraTogglerSystem>());
      
      Add(systems.Create<ToggleCameraSystem>());
      Add(systems.Create<ReplaceAudioListenerToActiveCameraSystem>());
      Add(systems.Create<SetCameraTransformByPlayerVerticalRotationSystem>());
      Add(systems.Create<SetActiveCameraByGameModeSystem>());
    }
  }
}