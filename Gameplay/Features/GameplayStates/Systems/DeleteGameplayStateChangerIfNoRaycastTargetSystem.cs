using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features
{
  public class DeleteGameplayStateChangerIfNoRaycastTargetSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _raycasters;
    private readonly IGroup<GameEntity> _changers;
    private readonly List<GameEntity> _buffer = new(1);

    public DeleteGameplayStateChangerIfNoRaycastTargetSystem(GameContext game)
    {
      _raycasters = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.SingleRayCaster));

      _changers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.GameplayStateChanger,
          GameMatcher.DurationFlag));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _raycasters)
      foreach (GameEntity changer in _changers.GetEntities(_buffer))
      {
        if (entity.SingleRayCaster == 0)
          changer.Destroy();
      }
    }
  }
}