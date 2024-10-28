using Code.Gameplay.Common.Visuals.StatusVisuals;
using Code.Infrastructure.Prefabs;
using Code.Infrastructure.View;
using Entitas;

namespace Code.Common
{
  [Game] public class Destructed : IComponent { }
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class ViewId : IComponent { public PrefabId Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBinder Value; }
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
  [Game] public class Radius : IComponent { public float Value; }
  [Game] public class StatusVisualsComponent : IComponent { public IStatusVisuals Value; }
}