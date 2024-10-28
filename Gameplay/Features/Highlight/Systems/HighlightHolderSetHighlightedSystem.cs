using Entitas;

namespace Code.Gameplay.Features.Highlight
{
  public class HighlightHolderSetHighlightedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _raycasters;
    private readonly IGroup<GameEntity> _highlighters;
    private readonly IGroup<GameEntity> _gameplayStates;

    private readonly GameContext _game;

    public HighlightHolderSetHighlightedSystem(GameContext game)
    {
      _game = game;

      _raycasters = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.SingleRayCaster));

      _highlighters = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.HighlightHolder));

      _gameplayStates = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.GameplayStateHolder));
    }

    public void Execute()
    {
      foreach (GameEntity highlighter in _highlighters)
      foreach (GameEntity raycaster in _raycasters)
      foreach (GameEntity gameMode in _gameplayStates)
        Highlight(gameMode, highlighter, raycaster);
    }

    private void Highlight(GameEntity gameMode, GameEntity highlighter, GameEntity raycaster)
    {
      if (raycaster.SingleRayCaster == 0)
        return;

      if (gameMode.GameplayStateHolder != GameplayStateId.Walking)
        return;

      GameEntity rayCastTarget = _game.GetEntityWithId(raycaster.SingleRayCaster);

      if (rayCastTarget.isHighlightable == false)
        return;

      int currentInteractableId = highlighter.HighlightHolder;

      if (currentInteractableId == raycaster.SingleRayCaster)
        return;

      highlighter.ReplaceHighlightHolder(rayCastTarget.Id);

      if (currentInteractableId == 0)
        return;

      GameEntity currentInteractableEntity = _game.GetEntityWithId(currentInteractableId);

      if (currentInteractableEntity == null)
        return;

      if (currentInteractableEntity.isHightlighted)
        currentInteractableEntity.isUnHighlighted = true;
    }
  }
}