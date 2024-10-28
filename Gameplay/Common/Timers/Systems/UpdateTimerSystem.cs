using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Common.Timers.Systems
{
  public class UpdateTimerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(8);
    private readonly ITimeService _timeService;

    public UpdateTimerSystem(GameContext game, ITimeService timeService)
    {
      _timeService = timeService;
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.TimerCurrentValue)
        .NoneOf(GameMatcher.TimerReady));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.TimerCurrentValue <= 0)
        {
          entity.ReplaceTimerCurrentValue(0);
          entity.isTimerReady = true;
        }

        entity.ReplaceTimerCurrentValue(entity.TimerCurrentValue - _timeService.DeltaTime);
      }
    }
  }
}