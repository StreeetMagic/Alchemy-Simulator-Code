using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Items.Types.Frog.Registrars
{
  public class FrogRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .AddItem(ItemId.Frog)
        .AddWorldPosition(transform.position)
        .AddInteractableName("Frog")
        .AddInteractableActionName("Collect")
        .With(x => x.isElement = true)
        .With(x => x.isInteractable = true)
        .With(x => x.isHighlightable = true)
        .With(x => x.isCollectable = true)
        ;
    }

    public override void UnregisterComponents()
    {
    }
  }
}