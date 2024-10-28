using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Desk.Registrars
{
  public class DeskRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .AddWorldPosition(transform.position)
        .AddInteractableName("Desk")
        .AddInteractableActionName("Start Alchemy")
        .With(x => x.isDesk = true)
        .With(x => x.isHighlightable = true)
        .With(x => x.isInteractable = true)
        .With(x => x.isDurationFlag = true)
        ;
    }

    public override void UnregisterComponents()
    {
      EntityBinder.ReleaseEntity();
      Destroy(gameObject);
    }
  }
}