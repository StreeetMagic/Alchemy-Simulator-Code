using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Models
{
  public class GameplayStateHolderModel : SingleValueModel<GameplayStateId>
  {
    public GameplayStateHolderModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));
    }

    protected override GameplayStateId OnTick() =>
      Entity.GameplayStateHolder;
  }
}