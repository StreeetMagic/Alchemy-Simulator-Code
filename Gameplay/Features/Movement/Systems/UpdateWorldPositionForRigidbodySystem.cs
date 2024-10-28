using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class UpdateWorldPositionForRigidbodySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public UpdateWorldPositionForRigidbodySystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Rigidbody,
          GameMatcher.WorldPosition,
          GameMatcher.MovableByRigidbody,
          GameMatcher.Transform
        ));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
        entity.ReplaceWorldPosition(entity.Transform.position);
    }
  }
}