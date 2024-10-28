using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerWalkHeadBobTimerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _timers;
    private readonly IGroup<GameEntity> _configs;

    public PlayerWalkHeadBobTimerSystem(GameContext game)
    {
      _timers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.PlayerHeadBobWalkTimer));

      _configs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.WalkBobSpeed));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _timers)
      foreach (GameEntity config in _configs)
      {
        float value = entity.PlayerHeadBobWalkTimer + config.WalkBobSpeed * Time.deltaTime;
        
        entity.ReplacePlayerHeadBobWalkTimer(value);
      }
    }
  }
}