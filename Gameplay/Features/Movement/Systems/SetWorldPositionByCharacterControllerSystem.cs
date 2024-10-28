using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class SetWorldPositionByCharacterControllerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;

    public SetWorldPositionByCharacterControllerSystem(GameContext game)
    {
      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.CharacterController,
          GameMatcher.Transform,
          GameMatcher.WorldPosition,
          GameMatcher.MovableByCharacterController
        ));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
        mover.ReplaceWorldPosition(mover.CharacterController.transform.position);
    }
  }
}