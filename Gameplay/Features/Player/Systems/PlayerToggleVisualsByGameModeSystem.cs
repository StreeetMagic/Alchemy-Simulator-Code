using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerToggleVisualsByGameModeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _gameModes;
    private readonly IGroup<GameEntity> _players;
    private readonly Dictionary<GameplayStateId, bool> _map;

    public PlayerToggleVisualsByGameModeSystem(GameContext game)
    {
      _gameModes = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.GameplayStateHolder));

      _players = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.PlayerVisualsToggler));

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
      {
        if (_map[gameMode.GameplayStateHolder])
          player.PlayerVisualsToggler.Enable();
        else
          player.PlayerVisualsToggler.Disable();
      }
    }
  }
}