using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class UpdateWorldPositionForTransformSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public UpdateWorldPositionForTransformSystem(GameContext game)
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