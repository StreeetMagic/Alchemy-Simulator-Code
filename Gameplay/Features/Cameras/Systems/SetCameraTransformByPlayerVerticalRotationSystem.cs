using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Systems
{
  public class SetCameraTransformByPlayerVerticalRotationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;
    private readonly IGroup<GameEntity> _cameras;

    public SetCameraTransformByPlayerVerticalRotationSystem(GameContext game)
    {
      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Player,
          GameMatcher.VerticalRotation));

      _cameras = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.PlayerCamera,
            GameMatcher.Transform));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
      foreach (GameEntity camera in _cameras)
      {
        camera.Transform.localRotation = Quaternion.Euler(mover.VerticalRotation, 0, 0);
      }
    }
  }
}