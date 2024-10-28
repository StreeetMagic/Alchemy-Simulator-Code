using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features
{
  public class VerticalRotationByMouseInputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _verticalRotators;
    private readonly IGroup<GameEntity> _cameras;

    public VerticalRotationByMouseInputSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.MouseInput));

      _verticalRotators = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.VerticalRotation,
          GameMatcher.RotationReady));

      _cameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.CameraInitialLookSpeedY,
          GameMatcher.CameraUpperLookLimit,
          GameMatcher.CameraLowerLookLimit));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      foreach (GameEntity config in _cameras)
      foreach (GameEntity mover in _verticalRotators)
      {
        float rotationX = mover.VerticalRotation;
        rotationX -= input.MouseInput.y * config.CameraInitialLookSpeedY;

        mover.ReplaceVerticalRotation(Mathf.Clamp(rotationX, -config.CameraUpperLookLimit, config.CameraLowerLookLimit));
      }
    }
  }
}