using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class RemoveJumpKeyAfterJumpSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _movers;
    private readonly List<GameEntity> _buffer = new(1);

    public RemoveJumpKeyAfterJumpSystem(GameContext game)
    {
      _inputs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.UserInput,
          GameMatcher.JumpKey));

      _movers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.Jumped));
    }

    public void Execute()
    {
      foreach (GameEntity input in _inputs.GetEntities(_buffer))
      foreach (GameEntity unused in _movers)
      {
        input.isJumpKey = false;
      }
    }
  }
}