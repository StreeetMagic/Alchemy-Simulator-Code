using Code.Common;
using Entitas;

namespace Code.Gameplay.Features.States.AlchemyStates.Systems
{
  public class CreateAlchemyStateHolderByEnterAlchemyGameplayStateSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _gameplayStateHolders;
    private readonly IGroup<GameEntity> _alchemyStateHolders;

    public CreateAlchemyStateHolderByEnterAlchemyGameplayStateSystem(GameContext game)
    {
      _gameplayStateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));

      _alchemyStateHolders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.AlchemyStateHolder));
    }

    public void Execute()
    {
      if (_alchemyStateHolders.count > 0)
        return;

      foreach (GameEntity entity in _gameplayStateHolders)
      {
        if (entity.GameplayStateHolder == GameplayStateId.Alchemy)
        {
          CreateEntity
            .Empty()
            .AddAlchemyStateHolder(AlchemyStateId.Idle)
            ;
        }
      }
    }
  }
}