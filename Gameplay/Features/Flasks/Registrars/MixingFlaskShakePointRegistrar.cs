using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Flasks.Registrars
{
  public class MixingFlaskShakePointRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .AddWorldPosition(transform.position)
        .With(x => x.isMixingFlaskShakePoint = true)
        ;
    }

    public override void UnregisterComponents()
    {
      throw new System.NotImplementedException();
    }
  }
}