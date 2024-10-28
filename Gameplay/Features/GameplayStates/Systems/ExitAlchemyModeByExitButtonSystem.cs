using Code.Gameplay.Features.States.AlchemyStates.Services;
using Entitas;

namespace Code.Gameplay.Features
{
  public class ExitAlchemyModeByExitButtonSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _input;
    private readonly IGroup<GameEntity> _holders;
    private readonly StateSwitcherService _stateSwitcherService;

    public ExitAlchemyModeByExitButtonSystem(GameContext game, StateSwitcherService stateSwitcherService)
    {
      _stateSwitcherService = stateSwitcherService;
      _input = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.ExitKey));

      _holders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));
    }

    public void Execute()
    {
      foreach (GameEntity holder in _holders)
      foreach (GameEntity _ in _input)
      {
        if (holder.GameplayStateHolder == GameplayStateId.Alchemy)
          _stateSwitcherService.EnterState(GameplayStateId.Walking);
      }
    }
  }
}