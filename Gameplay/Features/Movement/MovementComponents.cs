using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
  [Game] public class CurrentMoveSpeed : IComponent { public float Value;}
  [Game] public class MovementReady : IComponent { }

  [Game] public class MoveDirection : IComponent { public Vector3 Value; }
  [Game] public class HorizontalDirection : IComponent { public Vector2 Value; }
  
  [Game] public class AbleToMove : IComponent {}
  [Game] public class AbleToSprint : IComponent { }
  [Game] public class AbleToJump : IComponent {}
  [Game] public class AbleToCrouch : IComponent {  }
  [Game] public class AbleToHeadBob : IComponent {  }
  
  [Game] public class InitialWalkSpeed : IComponent { public float Value; }
  [Game] public class InitialSprintSpeed : IComponent { public float Value; }
  [Game] public class InitialCrouchSpeed : IComponent { public float Value; }
  [Game] public class InitialJumpForce : IComponent { public float Value; }
  [Game] public class InitialGravity : IComponent { public float Value; }

  [Game] public class Moving : IComponent { }
  [Game] public class Grounded : IComponent { }
  [Game] public class Jumped : IComponent { }
  [Game] public class Crouching : IComponent { }
  [Game] public class CrouchingAnimation : IComponent { }

  [Game] public class WorldPosition : IComponent { public Vector3 Value; }
  
  [Game] public class MovableByWorldPosition : IComponent { }
  [Game] public class MovableByCharacterController : IComponent { }
  [Game] public class MovableByRigidbody : IComponent { }
  [Game] public class MovableByTransform : IComponent { }
}