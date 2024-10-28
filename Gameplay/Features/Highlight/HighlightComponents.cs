using Entitas;
using HighlightPlus;

namespace Code.Gameplay.Features.Highlight
{
  [Game] public class Highlightable : IComponent { }

  [Game] public class HighlighterComponent : IComponent { }
  [Game] public class HighlightHolder : IComponent { public int Value; }

  [Game] public class Hightlighted : IComponent { }
  [Game] public class UnHighlighted : IComponent { }

  [Game] public class HighlightEffectComponent : IComponent {public HighlightEffect Value;}
  [Game] public class InitialHighlightRange : IComponent { public float Value; }
}