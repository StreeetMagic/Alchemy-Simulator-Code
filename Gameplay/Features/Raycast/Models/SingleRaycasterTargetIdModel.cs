using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Models
{
  public class SingleRaycasterTargetIdModel : SingleValueModel<int>
  {
    public SingleRaycasterTargetIdModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.SingleRayCaster));
    }

    protected override int OnTick() =>
      Entity.SingleRayCaster;
  }
}