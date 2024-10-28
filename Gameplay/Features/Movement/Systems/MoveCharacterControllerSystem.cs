using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class MoveCharacterControllerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;

    public MoveCharacterControllerSystem(GameContext game)
    {
      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.CharacterController,
          GameMatcher.MoveDirection,
          GameMatcher.MovementReady,
          GameMatcher.MovableByCharacterController
          ));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
        mover.CharacterController.Move(mover.MoveDirection * Time.deltaTime);
    }
  }
}