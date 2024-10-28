using Code.Infrastructure.Systems;

namespace Code
{
  public sealed class CheatFeature : Feature
  { 
    public CheatFeature(ISystemFactory systems)
    {
      Add(systems.Create<CheatSystem>());
    }
  }
}