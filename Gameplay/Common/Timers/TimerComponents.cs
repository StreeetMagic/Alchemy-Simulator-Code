using Entitas;

namespace Code.Gameplay.Common.Timers
{
  [Game] public class TimerCurrentValue : IComponent { public float Value; }
  [Game] public class TimerRelativeValue : IComponent { public float Value; }
  [Game] public class TimerMaxValue : IComponent { public float Value; }
  [Game] public class TimerReady : IComponent  {  }
}