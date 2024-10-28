using Code.Gameplay.Common.Timers.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Common.Timers
{
  public sealed class TimerFeature : Feature
  {
    public TimerFeature(ISystemFactory systems)
    {
      Add(systems.Create<UpdateTimerSystem>());
      Add(systems.Create<TimerCurrentValueAdditionSystem>());
      Add(systems.Create<RelativeTimerValueSystem>());
    }
  }
}