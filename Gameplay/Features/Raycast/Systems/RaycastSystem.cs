using Code.Gameplay.Common;
using Entitas;

namespace Code.Gameplay.Features.Systems
{
  public class RaycastSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _raycasters;
    private readonly IGroup<GameEntity> _gameModes;
    private readonly IGroup<GameEntity> _cameras;

    private readonly IPhysicsService _physicsService;

    public RaycastSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;

      _raycasters = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.SingleRayCaster));

      _gameModes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));

      _cameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.ActiveCamera));
    }

    public void Execute()
    {
      foreach (GameEntity camera in _cameras)
      foreach (GameEntity gameMode in _gameModes)
      foreach (GameEntity raycasters in _raycasters)
      {
        if (gameMode.GameplayStateHolder != GameplayStateId.Walking)
        {
          raycasters.ReplaceSingleRayCaster(0);
          
          continue;
        }

        GameEntity raycastEntity = _physicsService.Raycast(camera.Camera.transform.position, camera.Camera.transform.forward);

        if (raycastEntity != null)
          raycasters.ReplaceSingleRayCaster(raycastEntity.Id);
        else
          raycasters.ReplaceSingleRayCaster(0);
      }
    }
  }
}