using System.Collections.Generic;
using Code.Gameplay.Features.Inputs.Service;
using Entitas;

namespace Code.Gameplay.Features
{
  public class DeleteGameplayStateChangerWhenNoInteractKeyPressedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly IInputService _inputService;
    private readonly List<GameEntity> _buffer = new(1);

    public DeleteGameplayStateChangerWhenNoInteractKeyPressedSystem(GameContext game, IInputService inputService)
    {
      _inputService = inputService;

      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.GameplayStateChanger,
          GameMatcher.DurationFlag));
    }

    public void Cleanup()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (_inputService.InterractKeyDown)
          continue;

        entity.Destroy();
      }
    }
  }
}