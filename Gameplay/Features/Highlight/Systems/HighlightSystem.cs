using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Highlight
{
  public class HighlightSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _highlighters;
    private readonly IGroup<GameEntity> _raycasters;

    private readonly List<GameEntity> _buffer = new(12);

    public HighlightSystem(GameContext game)
    {
      _highlighters = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.HighlightEffect,
            GameMatcher.WorldPosition)
          .NoneOf(GameMatcher.Hightlighted)
      );

      _raycasters = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.SingleRayCaster,
            GameMatcher.InitialHighlightRange,
            GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity raycaster in _raycasters)
      foreach (GameEntity highlighter in _highlighters.GetEntities(_buffer))
      {
        if (raycaster.SingleRayCaster != highlighter.Id)
          continue;
      
        float distance = Vector3.Distance(highlighter.WorldPosition, raycaster.WorldPosition);
        
        if (distance > raycaster.InitialHighlightRange)
          continue;

        highlighter.HighlightEffect.highlighted = true;
        highlighter.isHightlighted = true;
      }
    }
  }
}