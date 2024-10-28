using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Models
{
  public class InitialInteractDistanceModel : SingleValueModel<float>
  {
    public InitialInteractDistanceModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.SingleRayCaster,
          GameMatcher.InitialInteractDistance));
    }

    protected override float OnTick()
    {
      return Entity.InitialInteractDistance;
    }
  }
}