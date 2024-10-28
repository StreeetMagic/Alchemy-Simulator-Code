using Entitas;

namespace Code.Gameplay.Common.Timers.Systems
{
  public class RelativeTimerValueSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public RelativeTimerValueSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TimerCurrentValue,
          GameMatcher.TimerMaxValue));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      {
        float max = entity.TimerMaxValue;
        float current = entity.TimerCurrentValue;
        float relative = current / max;
       
        entity.ReplaceTimerRelativeValue(relative);
      }
    }
  }
}