using Entitas;

namespace Code.Gameplay.Features
{
  [Game] public class GameplayStateHolder : IComponent { public GameplayStateId Value; }
  [Game] public class GameplayStateChanger : IComponent { public GameplayStateId Value; }
  [Game] public class Transition : IComponent { }
}