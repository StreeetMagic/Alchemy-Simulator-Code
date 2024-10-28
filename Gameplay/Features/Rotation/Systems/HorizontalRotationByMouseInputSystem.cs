using Entitas;

namespace Code.Gameplay.Features
{
  public class HorizontalRotationByMouseInputSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _verticalRotators;
    private readonly IGroup<GameEntity> _cameras;

    public HorizontalRotationByMouseInputSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.MouseInput));

      _verticalRotators = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.HorizontalRotation,
          GameMatcher.RotationReady));

      _cameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.CameraInitialLookSpeedX));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      foreach (GameEntity camera in _cameras)
      foreach (GameEntity mover in _verticalRotators)
      {
        mover.ReplaceHorizontalRotation(input.MouseInput.x * camera.CameraInitialLookSpeedX);
      }
    }
  }
}