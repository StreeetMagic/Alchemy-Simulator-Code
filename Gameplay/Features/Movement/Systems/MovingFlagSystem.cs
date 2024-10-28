using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class MovingFlagSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;

    public MovingFlagSystem(GameContext game)
    {
      _movers = game.GetGroup(
        GameMatcher
          .AllOf(GameMatcher.MoveDirection));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
        mover.isMoving = Mathf.Abs(mover.MoveDirection.x) > 0.1f || Mathf.Abs(mover.MoveDirection.z) > 0.1f;
    }
  }
}