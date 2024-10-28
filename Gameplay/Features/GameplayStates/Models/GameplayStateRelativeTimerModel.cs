using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Models
{
  public class GameplayStateRelativeTimerModel : SingleValueModel<float>
  {
    public GameplayStateRelativeTimerModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.GameplayStateChanger,
          GameMatcher.DurationFlag,
          GameMatcher.TimerRelativeValue));
    }

    protected override float OnTick()
    {
      return Entity.TimerRelativeValue;
    }
  }
}