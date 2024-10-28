using Entitas;

namespace Code.Gameplay.Features.Highlight
{
  public class HighlightHolderUnhighlightOnChangeGameModeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _casters;
    private readonly IGroup<GameEntity> _gameModes;

    private readonly GameContext _game;

    public HighlightHolderUnhighlightOnChangeGameModeSystem(GameContext game)
    {
      _game = game;

      _casters = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.HighlightHolder));

      _gameModes = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.GameplayStateHolder));
    }

    public void Execute()
    {
      foreach (GameEntity caster in _casters)
      foreach (GameEntity gameMode in _gameModes)
        UnHighlight(gameMode, caster);
    }

    private void UnHighlight(GameEntity gameMode, GameEntity caster)
    {
      if (gameMode.GameplayStateHolder == GameplayStateId.Walking)
        return;
    
      if (caster.HighlightHolder == 0)
        return;

      GameEntity currentInteractableEntity = _game.GetEntityWithId(caster.HighlightHolder);
      
      caster.ReplaceHighlightHolder(0);

      if (currentInteractableEntity.isHightlighted)
        currentInteractableEntity.isUnHighlighted = true;
    }
  }
}