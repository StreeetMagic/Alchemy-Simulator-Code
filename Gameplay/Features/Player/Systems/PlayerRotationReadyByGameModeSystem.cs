using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerRotationReadyByGameModeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<GameEntity> _gameModes;
    private readonly Dictionary<GameplayStateId, bool> _map;

    public PlayerRotationReadyByGameModeSystem(GameContext game)
    {
      _players = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.Player));
    
      _gameModes = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.GameplayStateHolder));

      _map = new Dictionary<GameplayStateId, bool>()
      {
        { GameplayStateId.Walking, true },
        { GameplayStateId.Alchemy, false },
      };
    }

    public void Execute()
    {
      foreach (GameEntity gameMode in _gameModes)
      foreach (GameEntity player in _players)
        player.isRotationReady = _map[gameMode.GameplayStateHolder];
    }
  }
}