using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerMoveDirectionIfGroundedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;

    public PlayerMoveDirectionIfGroundedSystem(GameContext game)
    {
      _movers = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.MoveDirection,
            GameMatcher.Grounded,
            GameMatcher.InitialGravity));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
      {
        Vector3 moveDirection = mover.MoveDirection;
        float gravity = mover.InitialGravity;
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.y = Mathf.Max(moveDirection.y, -gravity);
        mover.ReplaceMoveDirection(moveDirection);
      }
    }
  }
}