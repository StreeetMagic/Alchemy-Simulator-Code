using Code.Infrastructure.Models;

namespace Code.Gameplay.Features.Model
{
  public class InteractableNameModel : SingleValueModel<string>
  {
    public InteractableNameModel(GameContext game)
    {
      Entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hightlighted,
          GameMatcher.Interactable,
          GameMatcher.InteractableName));
    }

    protected override string OnTick() =>
      Entity.InteractableName;
  }
}