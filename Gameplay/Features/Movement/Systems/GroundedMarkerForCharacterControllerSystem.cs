using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class GroundedMarkerForCharacterControllerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _characterControllers;

    public GroundedMarkerForCharacterControllerSystem(GameContext game)
    {
      _characterControllers = game.GetGroup(
        GameMatcher
          .AllOf(GameMatcher.CharacterController));
    }

    public void Execute()
    {
      foreach (GameEntity characterController in _characterControllers)
        characterController.isGrounded = characterController.CharacterController.isGrounded;
    }
  }
}