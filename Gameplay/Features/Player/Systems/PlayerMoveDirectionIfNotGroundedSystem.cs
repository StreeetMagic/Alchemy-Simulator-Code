using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerMoveDirectionIfNotGroundedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;

    public PlayerMoveDirectionIfNotGroundedSystem(GameContext game)
    {
      _movers = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.MoveDirection,
            GameMatcher.InitialGravity)
          .NoneOf(GameMatcher.Grounded));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
      {
        Vector3 moveDirection = mover.MoveDirection;
        moveDirection.y -= mover.InitialGravity * Time.deltaTime;
        mover.ReplaceMoveDirection(moveDirection);
      }
    }
  }
}