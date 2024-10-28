using Code.Gameplay.Features.Inputs.Service;
using Code.Gameplay.Features.Inventories;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Inputs.Systems
{
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<GameEntity> _inputs;
    private readonly InventoryService _inventoryService;

    public EmitInputSystem(GameContext game, IInputService inputService, InventoryService inventoryService)
    {
      _inputService = inputService;
      _inventoryService = inventoryService;
      _inputs = game.GetGroup(GameMatcher.UserInput);
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      {
        if (_inventoryService.IsOpened)
        {
          if (input.hasAxisInput)
            input.RemoveAxisInput();

          if (input.hasMouseInput)
            input.RemoveMouseInput();
          
          return;
        }

        if (_inputService.HasAxisInput)
          input.ReplaceAxisInput(new Vector2(_inputService.Horizontal, _inputService.Vertical));
        else if (input.hasAxisInput)
          input.RemoveAxisInput();

        if (_inputService.HasMouseLook)
          input.ReplaceMouseInput(new Vector2(_inputService.MouseX, _inputService.MouseY));
        else if (input.hasMouseInput)
          input.RemoveMouseInput();

        if (_inputService.SprintKeyPressed)
          input.isSprintKey = true;
        else if (input.isSprintKey)
          input.isSprintKey = false;

        if (_inputService.InterractKeyDown)
          input.isInterractKey = true;
        else if (input.isInterractKey)
          input.isInterractKey = false;

        if (_inputService.JumpKeyDown)
          input.isJumpKey = true;

        if (_inputService.CrouchKeyDown)
          input.isCrouchKey = true;
        else if (input.isCrouchKey)
          input.isCrouchKey = false;

        if (_inputService.ExitKeyDown)
          input.isExitKey = true;
        else if (input.isExitKey)
          input.isExitKey = false;
      }
    }
  }
}