using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Items.Types.Water.Registrars
{
  public class WaterRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .AddItem(ItemId.Water)
        .AddWorldPosition(transform.position)
        .AddInteractableName("Water")
        .AddInteractableActionName("Collect")
        .With(x => x.isElement = true)
        .With(x => x.isReagent = true)
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