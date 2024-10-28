using Entitas;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerMoveSpeedSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _movers;

    public PlayerMoveSpeedSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.UserInput));

      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Player,
          GameMatcher.InitialCrouchSpeed,
          GameMatcher.InitialWalkSpeed,
          GameMatcher.InitialSprintSpeed,
          GameMatcher.CurrentMoveSpeed));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs)
      foreach (GameEntity mover in _movers)
      {
        if (mover.isCrouching)
          mover.ReplaceCurrentMoveSpeed(mover.InitialCrouchSpeed);
        else if (mover.isAbleToSprint && input.isSprintKey)
          mover.ReplaceCurrentMoveSpeed(mover.InitialSprintSpeed);
        else
          mover.ReplaceCurrentMoveSpeed(mover.InitialWalkSpeed);
      }
    }
  }
}