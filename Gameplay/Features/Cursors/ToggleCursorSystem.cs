using System;
using Code.Gameplay.Features.Inventories;
using Code.Infrastructure;
using Entitas;

namespace Code.Gameplay.Features
{
  public class ToggleCursorSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _gameplayStateHolders;

    private readonly InventoryService _inventoryService;
    private readonly CursorService _cursorService;

    public ToggleCursorSystem(GameContext game, InventoryService inventoryService, CursorService cursorService)
    {
      _inventoryService = inventoryService;
      _cursorService = cursorService;

      _gameplayStateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _gameplayStateHolders)
      {
        switch (entity.GameplayStateHolder)
        {
          case GameplayStateId.Alchemy:
            _cursorService.ShowCursor();
            break;

          case GameplayStateId.Walking:
          case GameplayStateId.Fishing:
            if (_inventoryService.IsOpened)
            {
              _cursorService.ShowCursor();
            }
            else
            {
              _cursorService.HideCursor();
            }

            break;

          default:
          case GameplayStateId.Unknown:
            throw new ArgumentOutOfRangeException();
        }
      }
    }
  }
}