using Code.Gameplay.Features.Movement.Systems;
using Code.Gameplay.Features.Player.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
  public sealed class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systems)
    {
      Add(systems.Create<SetWorldPositionByCharacterControllerSystem>());
      Add(systems.Create<MoveCharacterControllerSystem>());
      Add(systems.Create<MovingFlagSystem>());
      Add(systems.Create<PlayerMoveDirectionIfGroundedSystem>());
      Add(systems.Create<PlayerMoveDirectionIfNotGroundedSystem>());
      Add(systems.Create<GroundedMarkerForCharacterControllerSystem>());
      Add(systems.Create<RemoveJumpKeyAfterJumpSystem>());
      Add(systems.Create<UpdatePositionByWorldPositionSystem>());
      Add(systems.Create<UpdateWorldPositionForCharacterControllerSystem>());
      Add(systems.Create<UpdateWorldPositionForRigidbodySystem>());
      Add(systems.Create<UpdateWorldPositionForTransformSystem>());
    }
  }
}