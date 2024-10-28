using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Model
{
  public class InteractableActionNameModel : SingleValueModel<string>
  {
    public InteractableActionNameModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hightlighted,
          GameMatcher.Interactable,
          GameMatcher.InteractableActionName));
    }

    protected override string OnTick() =>
      Entity.InteractableActionName;
  }
}