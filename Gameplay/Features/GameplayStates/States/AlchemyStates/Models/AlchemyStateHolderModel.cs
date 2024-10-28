using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.States.AlchemyStates.Models
{
  public class AlchemyStateHolderModel : SingleValueModel<AlchemyStateId>
  {
    public AlchemyStateHolderModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.AlchemyStateHolder));
    }

    protected override AlchemyStateId OnTick() =>
      Entity.AlchemyStateHolder;
  }
}