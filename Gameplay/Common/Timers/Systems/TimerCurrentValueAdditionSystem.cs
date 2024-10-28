using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Common.Timers.Systems
{
  public class TimerCurrentValueAdditionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(8);

    public TimerCurrentValueAdditionSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.TimerMaxValue)
        .NoneOf(GameMatcher.TimerCurrentValue));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        entity.AddTimerCurrentValue(entity.TimerMaxValue); 
      }
    }
  }
}