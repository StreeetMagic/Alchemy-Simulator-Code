using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Highlight
{
  public class UnHighlightSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _onFocused;
    private readonly List<GameEntity> _buffer = new(16);

    public UnHighlightSystem(GameContext game)
    {
      _onFocused = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.UnHighlighted,
            GameMatcher.Hightlighted,
            GameMatcher.HighlightEffect)
      );
    }

    public void Cleanup()
    {
      foreach (GameEntity onFocused in _onFocused.GetEntities(_buffer))
      {
        onFocused.HighlightEffect.highlighted = false;
        onFocused.isUnHighlighted = false;
        onFocused.isHightlighted = false;
      }
    }
  }
}