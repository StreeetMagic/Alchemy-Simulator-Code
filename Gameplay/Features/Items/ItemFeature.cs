using Code.Gameplay.Features.Items.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Items
{
  public sealed class ItemFeature : Feature
  {
    public ItemFeature(ISystemFactory systems)
    {
      Add(systems.Create<OnItemInteractSystem>());
    }
  }
}
