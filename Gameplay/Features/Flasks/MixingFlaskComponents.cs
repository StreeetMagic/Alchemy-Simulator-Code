using Code.Gameplay.Features.Flasks.Monobehaviours;
using Entitas;

namespace Code.Gameplay.Features.Flasks
{
  [Game] public class Flask : IComponent { }
  [Game] public class MixingFlask : IComponent { }
  [Game] public class MixingFlaskShakerComponent : IComponent { public MixingFlaskShaker Value; }

  [Game] public class MixingFlaskShakePoint : IComponent {  }
  [Game] public class MixingFlaskStationaryPoint : IComponent { }
}