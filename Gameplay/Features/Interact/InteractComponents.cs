using Entitas;

namespace Code.Gameplay.Features
{
  [Game] public class Interactable : IComponent { }
  [Game] public class Interacted : IComponent { }
  [Game] public class InteractableName : IComponent { public string Value; }
  [Game] public class InteractableActionName : IComponent { public string Value; }
  [Game] public class InitialInteractDistance : IComponent { public float Value; }
}