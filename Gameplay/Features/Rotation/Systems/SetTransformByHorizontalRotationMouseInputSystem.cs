using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features
{
  public class SetTransformByHorizontalRotationMouseInputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _horizontalRotators;
    private readonly IGroup<GameEntity> _input;

    public SetTransformByHorizontalRotationMouseInputSystem(GameContext game)
    {
      _horizontalRotators = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.HorizontalRotation,
          GameMatcher.Transform,
          GameMatcher.RotationReady));

      _input = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.MouseInput));
    }

    public void Execute()
    {
      foreach (GameEntity unused in _input)
      foreach (GameEntity rotator in _horizontalRotators)
        rotator.Transform.rotation *= Quaternion.Euler(0, rotator.HorizontalRotation, 0);
    }
  }
}