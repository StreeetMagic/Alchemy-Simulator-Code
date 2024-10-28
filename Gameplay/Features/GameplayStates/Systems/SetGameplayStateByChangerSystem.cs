using Entitas;

namespace Code.Gameplay.Features
{
  public class SetGameplayStateByChangerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _changers;
    private readonly IGroup<GameEntity> _stateHolders;

    public SetGameplayStateByChangerSystem(GameContext game)
    {
      _changers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.GameplayStateChanger,
          GameMatcher.TimerReady));

      _stateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));
    }

    public void Execute()
    {
      foreach (GameEntity changer in _changers)
      foreach (GameEntity holder in _stateHolders)
      {
        if (changer.GameplayStateChanger != holder.GameplayStateHolder)
          holder.ReplaceGameplayStateHolder(changer.GameplayStateChanger);

        changer.isDestructed = true;
      }
    }
  }
}