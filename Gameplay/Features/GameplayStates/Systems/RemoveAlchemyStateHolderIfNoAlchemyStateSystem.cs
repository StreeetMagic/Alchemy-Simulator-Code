using Entitas;

namespace Code.Gameplay.Features
{
  public class RemoveAlchemyStateHolderIfNoAlchemyStateSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _gamePlayStateHolders;
    private readonly IGroup<GameEntity> _alchemyStateHolders;

    public RemoveAlchemyStateHolderIfNoAlchemyStateSystem(GameContext game)
    {
      _gamePlayStateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));
      
      _alchemyStateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.AlchemyStateHolder));
    }

    public void Execute()
    {
      foreach (GameEntity gameplayStateHolder in _gamePlayStateHolders)
      foreach (GameEntity alchemyStateHolder in _alchemyStateHolders)
      {
        if (gameplayStateHolder.GameplayStateHolder != GameplayStateId.Alchemy)
        {
          //alchemyStateHolder.ReplaceAlchemyStateHolder(AlchemyStateId.Unknown);
          alchemyStateHolder.isDestructed = true;
        }
      }
    }
  }
}