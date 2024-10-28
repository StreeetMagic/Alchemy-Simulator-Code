using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Inputs
{
  [Game] public class UserInput : IComponent { }
  [Game] public class AxisInput : IComponent { public Vector2 Value; }
  [Game] public class MouseInput : IComponent { public Vector2 Value; }

  [Game] public class SprintKey : IComponent { }
  [Game] public class InterractKey : IComponent { }
  [Game] public class JumpKey : IComponent { }
  [Game] public class CrouchKey : IComponent { }
  [Game] public class ExitKey : IComponent { }
}