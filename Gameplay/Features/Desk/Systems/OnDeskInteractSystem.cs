using System.Collections.Generic;
using Code.Gameplay.Features.States.AlchemyStates.Services;
using Entitas;

namespace Code.Gameplay.Features.Desk.Systems
{
  public class OnDeskInteractSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _desks;

    private readonly List<GameEntity> _buffer = new(1);
    private readonly IGroup<GameEntity> _stateChangers;
    private readonly StateSwitcherService _stateSwitcherService;

    public OnDeskInteractSystem(GameContext game, StateSwitcherService stateSwitcherService)
    {
      _stateSwitcherService = stateSwitcherService;

      _stateChangers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.GameplayStateChanger,
          GameMatcher.DurationFlag));

      _desks = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Desk,
          GameMatcher.Interactable,
          GameMatcher.Hightlighted));
    }

    public void Execute()
    {
      foreach (GameEntity _ in _desks.GetEntities(_buffer))
      {
        if (_stateChangers.count > 0)
          continue;

        _stateSwitcherService.EnterState(GameplayStateId.Alchemy, 1);
      }
    }
  }
}