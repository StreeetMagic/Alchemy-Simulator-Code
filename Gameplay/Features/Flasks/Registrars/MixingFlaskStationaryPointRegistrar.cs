using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Flasks.Registrars
{
  public class MixingFlaskStationaryPointRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .AddWorldPosition(transform.position)
        .With(x => x.isMixingFlaskStationaryPoint = true)
        ;
    }

    public override void UnregisterComponents()
    {
      throw new System.NotImplementedException();
    }
  }
}