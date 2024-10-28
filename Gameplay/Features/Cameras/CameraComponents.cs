using Entitas;

namespace Code.Gameplay.Features
{
  [Game] public class CameraComponent : IComponent {public UnityEngine.Camera Value; }
  [Game] public class CameraIdComponent : IComponent { public CameraId Value; }

  [Game] public class CameraToggler : IComponent { }

  [Game] public class CameraInitialLookSpeedY : IComponent { public float Value; }
  [Game] public class CameraInitialLookSpeedX : IComponent { public float Value; }
  [Game] public class CameraLowerLookLimit : IComponent { public float Value; }
  [Game] public class CameraUpperLookLimit : IComponent { public float Value; }
  [Game] public class ActiveCamera : IComponent { }
}