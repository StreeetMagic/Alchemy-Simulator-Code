using Code.Common;
using Code.Gameplay.Features.Flasks.Monobehaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Flasks.Registrars
{
  public class MixingFlaskRegistrar : EntityComponentRegistrar
  {
    public MixingFlaskShaker Shaker;
  
    public override void RegisterComponents()
    {
      Entity
        .AddMixingFlaskShaker(Shaker)
        .AddWorldPosition(transform.position)
        .With(x => x.isMixingFlask = true)
        .With(x => x.isMovableByTransform = true)
        .With(x => x.isFlask = true)
        ;
    }

    public override void UnregisterComponents()
    {
    }
  }
}
