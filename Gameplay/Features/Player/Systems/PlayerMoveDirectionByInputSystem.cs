using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerMoveDirectionByInputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _movers;

    public PlayerMoveDirectionByInputSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher.UserInput);

      _movers = game.GetGroup(GameMatcher.AllOf(
        GameMatcher.Player,
        GameMatcher.AbleToMove,
        GameMatcher.CharacterController,
        GameMatcher.HorizontalDirection));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
      foreach (GameEntity input in _inputs)
      {
        if (!input.hasAxisInput)
        {
          Vector3 currentDirection = mover.MoveDirection;
          
          mover.ReplaceMoveDirection(new Vector3(0, currentDirection.y, 0));
          
          continue;
        }
          
        UpdateMoverDirection(input, mover);
      }
    }

    private void UpdateMoverDirection(GameEntity input, GameEntity mover)
    {
      Vector3 currentInputX = mover.Transform.TransformDirection(Vector3.forward) * mover.HorizontalDirection.x;
      Vector3 currentInputY = mover.Transform.TransformDirection(Vector3.right) * mover.HorizontalDirection.y;

      Vector2 horizontalDirection = new Vector2(input.AxisInput.y, input.AxisInput.x).normalized; 
      horizontalDirection *= mover.CurrentMoveSpeed;
      mover.ReplaceHorizontalDirection(horizontalDirection);

      float moveDirectionY = mover.MoveDirection.y;
      Vector3 direction = currentInputX + currentInputY;
      direction.y = moveDirectionY;

      mover.ReplaceMoveDirection(direction);
    }
  }
}