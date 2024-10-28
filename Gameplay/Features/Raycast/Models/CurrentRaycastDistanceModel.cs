using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Models
{
  public class CurrentRaycastDistanceModel : SingleValueModel<float>
  {
    public CurrentRaycastDistanceModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CurrentRaycastDistance));
    }

    protected override float OnTick()
    {
      return Entity.CurrentRaycastDistance;
    }
  }
}