using Code.Common;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Items.Types.Wind.Registrars
{
  public class WindRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity
        .With(x => x.isReagent = true)
        .With(x => x.isCollectable = true)
        ;
    }

    public override void UnregisterComponents()
    {
    }
  }
}