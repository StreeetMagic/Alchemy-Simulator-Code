using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerWalkHeadBobSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _movers;
    private readonly IGroup<GameEntity> _cameras;

    public PlayerWalkHeadBobSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.UserInput)
          .NoneOf(
            GameMatcher.SprintKey));

      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Player,
          GameMatcher.AbleToMove,
          GameMatcher.CharacterController,
          GameMatcher.AbleToHeadBob,
          GameMatcher.WalkBobAmount,
          GameMatcher.Moving,
          GameMatcher.Grounded,
          GameMatcher.PlayerHeadBobWalkTimer));

      _cameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.PlayerCamera,
          GameMatcher.Transform,
          GameMatcher.DefaultPositionY));
    }

    public void Execute()
    {
      foreach (GameEntity _ in _inputs)
      foreach (GameEntity camera in _cameras)
      foreach (GameEntity mover in _movers)
      {
        if (!mover.isAbleToHeadBob)
          continue;

        float x = camera.Transform.localPosition.x;
        float y = camera.DefaultPositionY + Mathf.Sin(mover.PlayerHeadBobWalkTimer) * mover.WalkBobAmount;
        float z = camera.Transform.localPosition.z;

        camera.Transform.localPosition = new Vector3(x, y, z);
      }
    }
  }
}