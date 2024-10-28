using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class UpdateWorldPositionForCharacterControllerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public UpdateWorldPositionForCharacterControllerSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CharacterController,
          GameMatcher.WorldPosition,
          GameMatcher.MovableByCharacterController,
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