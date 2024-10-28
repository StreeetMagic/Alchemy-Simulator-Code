using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class UpdatePositionByWorldPositionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public UpdatePositionByWorldPositionSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.WorldPosition,
          GameMatcher.Transform,
          GameMatcher.MovableByWorldPosition
        )
      );
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        entity.Transform.position = entity.WorldPosition;
    }
  }
}