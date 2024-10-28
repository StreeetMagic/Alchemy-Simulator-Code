using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerSprintHeadBobTimerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _timers;
    private readonly IGroup<GameEntity> _configs;

    public PlayerSprintHeadBobTimerSystem(GameContext game)
    {
      _timers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.PlayerHeadBobSprintTimer));

      _configs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.SprintBobSpeed));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _timers)
      foreach (GameEntity config in _configs)
      {
        entity.ReplacePlayerHeadBobSprintTimer(entity.PlayerHeadBobSprintTimer + config.SprintBobSpeed * Time.deltaTime);
      }
    }
  }
}