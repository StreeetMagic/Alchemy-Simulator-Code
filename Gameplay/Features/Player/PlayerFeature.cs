using Code.Gameplay.Features.Player.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Player
{
  public sealed class PlayerFeature : Feature
  {
    public PlayerFeature(ISystemFactory systems)
    {
      Add(systems.Create<PlayerCrouchSystem>());
      Add(systems.Create<PlayerFootstepSystem>());
      Add(systems.Create<PlayerWalkHeadBobSystem>());
      Add(systems.Create<PlayerSprintHeadBobSystem>());
      Add(systems.Create<PlayerMoveDirectionByInputSystem>());
      Add(systems.Create<PlayerMoveSpeedSystem>());
      Add(systems.Create<PlayerMoveDirectionAfterJumpSystem>());
      Add(systems.Create<PlayerWalkHeadBobTimerSystem>());
      Add(systems.Create<PlayerSprintHeadBobTimerSystem>());
      Add(systems.Create<PlayerMovementReadyByGameModeSystem>());
      Add(systems.Create<PlayerRotationReadyByGameModeSystem>());
      Add(systems.Create<PlayerToggleVisualsByGameModeSystem>());
    }
  }
}