using System;
using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.States.AlchemyStates.Systems
{
  public class SetAlchemyStateByChangerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _changers;
    private readonly IGroup<GameEntity> _stateHolders;

    private readonly Dictionary<AlchemyStateId, Action<GameEntity>> _setNextTransitionActions;
    private readonly Dictionary<AlchemyStateId, Action<GameEntity>> _setCurrentStateActions;

    public SetAlchemyStateByChangerSystem(GameContext game)
    {
      _changers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AlchemyStateChanger,
          GameMatcher.TimerReady));

      _stateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.AlchemyStateHolder));

      _setNextTransitionActions = new Dictionary<AlchemyStateId, Action<GameEntity>>
      {
        { AlchemyStateId.Idle, changer => changer.isToAlchemyIdleStateTransitionFlag = true },
        { AlchemyStateId.Preparaion, changer => changer.isToAlchemyPreparaionStateTransitionFlag = true },
        { AlchemyStateId.FlaskShaking, changer => changer.isToAlchemyFlaskShakingStateTransitionFlag = true },
        { AlchemyStateId.Cooking, changer => changer.isToAlchemyCookingStateTransitionFlag = true },
        { AlchemyStateId.Mixing, changer => changer.isToAlchemyMixingStateTransitionFlag = true },
      };

      _setCurrentStateActions = new Dictionary<AlchemyStateId, Action<GameEntity>>
      {
        { AlchemyStateId.Idle, changer => changer.isFromAlchemyIdleStateTransitionFlag = true },
        { AlchemyStateId.Preparaion, changer => changer.isFromAlchemyPreparaionStateTransitionFlag = true },
        { AlchemyStateId.FlaskShaking, changer => changer.isFromAlchemyFlaskShakingStateTransitionFlag = true },
        { AlchemyStateId.Cooking, changer => changer.isFromAlchemyCookingStateTransitionFlag = true },
        { AlchemyStateId.Mixing, changer => changer.isFromAlchemyMixingStateTransitionFlag = true },
      };
    }

    public void Execute()
    {
      foreach (GameEntity changer in _changers)
      foreach (GameEntity holder in _stateHolders)
      {
        if (changer.AlchemyStateChanger != holder.AlchemyStateHolder)
          ChangeState(changer, holder);

        changer.isDestructed = true;
      }
    }

    private void ChangeState(GameEntity changer, GameEntity holder)
    {
      changer.isTransition = true;
      SetCurrentState(holder, changer);
      SetNextTransition(changer);
      holder.ReplaceAlchemyStateHolder(changer.AlchemyStateChanger);
    }

    private void SetNextTransition(GameEntity changer)
    {
      if (_setNextTransitionActions.TryGetValue(changer.AlchemyStateChanger, out Action<GameEntity> action))
        action(changer);
      else
        throw new ArgumentOutOfRangeException();
    }

    private void SetCurrentState(GameEntity holder, GameEntity changer)
    {
      if (_setCurrentStateActions.TryGetValue(holder.AlchemyStateHolder, out Action<GameEntity> action))
        action(changer);
      else
        throw new ArgumentOutOfRangeException();
    }
  }
}