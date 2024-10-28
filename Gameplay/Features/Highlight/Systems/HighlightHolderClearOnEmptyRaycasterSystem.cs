using Entitas;

namespace Code.Gameplay.Features.Highlight
{
  /// <summary>
  /// Очищаем ID подсвеченной цели
  /// </summary>
  public class HighlightHolderClearOnEmptyRaycasterSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _raycasters;
    private readonly IGroup<GameEntity> _highlighters;

    private readonly GameContext _game;

    public HighlightHolderClearOnEmptyRaycasterSystem(GameContext game)
    {
      _game = game;

      _raycasters = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.SingleRayCaster));

      _highlighters = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.HighlightHolder));
    }

    public void Execute()
    {
      foreach (GameEntity highlighter in _highlighters)
      foreach (GameEntity raycaster in _raycasters)
        Highlight(highlighter, raycaster);
    }

    private void Highlight(GameEntity highlighter, GameEntity raycaster)
    {
      if (raycaster.SingleRayCaster != 0)
        return;

      if (highlighter.HighlightHolder == 0)
        return;

      GameEntity currentInteractableEntity = _game.GetEntityWithId(highlighter.HighlightHolder);

      highlighter.ReplaceHighlightHolder(0);

      if (currentInteractableEntity == null)
        return;

      if (currentInteractableEntity.isHightlighted)
        currentInteractableEntity.isUnHighlighted = true;
    }
  }
}