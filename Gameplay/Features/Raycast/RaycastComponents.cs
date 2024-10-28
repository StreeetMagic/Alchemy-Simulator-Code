using Entitas;

namespace Code.Gameplay.Features
{
  [Game] public class SingleRayCaster : IComponent { public int Value; }
  [Game] public class CurrentRaycastDistance : IComponent { public float Value; }
}