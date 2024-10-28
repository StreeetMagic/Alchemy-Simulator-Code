using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Collect.Systems
{
  public class CollectSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _collectables;
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _raycasters;
    private readonly List<GameEntity> _buffer = new(128);

    public CollectSystem(GameContext game)
    {
      _collectables = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collectable)
        .NoneOf(
          GameMatcher.Collected));

      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.UserInput,
          GameMatcher.InterractKey));

      _raycasters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.SingleRayCaster));
    }

    public void Execute()
    {
      foreach (GameEntity interactable in _collectables.GetEntities(_buffer))
      foreach (GameEntity _ in _inputs)
      foreach (GameEntity raycaster in _raycasters)
      {
        int raycastedId = raycaster.SingleRayCaster;

        if (raycastedId == interactable.Id)
          interactable.isInteracted = true;
      }
    }
  }
}