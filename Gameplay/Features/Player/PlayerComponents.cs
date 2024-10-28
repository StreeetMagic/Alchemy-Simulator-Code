using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player
{
  [Game] public class Player : IComponent { }
  [Game] public class PlayerVisualsTogglerComponent : IComponent { public PlayerVisualsToggler Value; }
  [Game] public class PlayerHeadBobWalkTimer : IComponent { public float Value; }
  [Game] public class PlayerHeadBobSprintTimer : IComponent { public float Value; }
  
  [Game] public class UseFootSteps : IComponent { }

  [Game] public class CrouchHeight : IComponent { public float Value; }
  [Game] public class StandingHeight : IComponent { public float Value; }
  [Game] public class TimeToCrouch : IComponent { public float Value; }
  [Game] public class CrouchCenter : IComponent { public Vector3 Value; }
  [Game] public class StandingCenter : IComponent { public Vector3 Value; }
  
  [Game] public class WalkBobSpeed : IComponent { public float Value; }
  [Game] public class WalkBobAmount : IComponent { public float Value; }
  [Game] public class SprintBobSpeed : IComponent { public float Value; }
  [Game] public class SprintBobAmount : IComponent { public float Value; }
}