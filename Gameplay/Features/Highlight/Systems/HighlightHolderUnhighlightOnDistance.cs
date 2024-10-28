using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Highlight
{
  public class HighlightHolderUnhighlightOnDistance : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _casters;
    private readonly IGroup<GameEntity> _highLights;
    private readonly List<GameEntity> _buffer = new(1);

    public HighlightHolderUnhighlightOnDistance(GameContext game)
    {
      _casters = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.HighlightHolder,
          GameMatcher.WorldPosition));

      _highLights = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.Hightlighted,
            GameMatcher.WorldPosition)
          .NoneOf(
            GameMatcher.UnHighlighted)
      );
    }

    public void Execute()
    {
      foreach (GameEntity caster in _casters)
      foreach (GameEntity highLight in _highLights.GetEntities(_buffer))
        UnHighlight(highLight, caster);
    }

    private void UnHighlight(GameEntity highLight, GameEntity caster)
    {
      float distance = Vector3.Distance(caster.WorldPosition, highLight.WorldPosition);
      
      bool near = distance < caster.InitialHighlightRange;

      if (near)
      {
        return;
      }

      if (caster.HighlightHolder == 0)
      {
        return;
      }

      caster.ReplaceHighlightHolder(0);

      highLight.isUnHighlighted = true;
    }
  }
}