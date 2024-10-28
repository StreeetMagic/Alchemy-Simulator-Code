using Entitas;

namespace Code.Gameplay.Features
{
  [Game] public class VerticalRotation : IComponent { public float Value; }
  [Game] public class HorizontalRotation : IComponent { public float Value; }
  [Game] public class RotationReady : IComponent {}
}