using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerMoveDirectionAfterJumpSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _movers;
    private readonly List<GameEntity> _buffer = new(1);

    public PlayerMoveDirectionAfterJumpSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.UserInput,
          GameMatcher.JumpKey));

      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Player,
          GameMatcher.AbleToMove,
          GameMatcher.CharacterController,
          GameMatcher.AbleToJump,
          GameMatcher.Transform,
          GameMatcher.InitialJumpForce,
          GameMatcher.Grounded));
    }

    public void Execute()
    {
      foreach (GameEntity unused in _inputs.GetEntities(_buffer))
      foreach (GameEntity mover in _movers)
      {
        if (!mover.isAbleToJump)
          continue;
        
        Vector3 direction = mover.MoveDirection;
        direction.y = mover.InitialJumpForce;
        mover.ReplaceMoveDirection(direction);
        mover.isJumped = true;
      }
    }
  }
}