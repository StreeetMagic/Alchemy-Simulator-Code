using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Systems
{
  public class CurrentInteractDistanceSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _highlighted;
    private readonly IGroup<GameEntity> _raycasters;

    public CurrentInteractDistanceSystem(GameContext game)
    {
      _highlighted = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hightlighted,
          GameMatcher.WorldPosition));

      _raycasters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.SingleRayCaster,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity interactable in _highlighted)
      foreach (GameEntity raycaster in _raycasters)
      {
        if (raycaster.SingleRayCaster == 0)
        {
          raycaster.ReplaceCurrentRaycastDistance(0f);
          continue;
        }
        
        float distance = Vector3.Distance(interactable.WorldPosition, raycaster.WorldPosition);
        raycaster.ReplaceCurrentRaycastDistance(distance);
      }
    }
  }
}