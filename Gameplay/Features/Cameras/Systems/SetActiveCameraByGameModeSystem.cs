using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Systems
{
  public class SetActiveCameraByGameModeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _gameModes;
    private readonly IGroup<GameEntity> _togglers;

    private readonly Dictionary<GameplayStateId, CameraId> _gameModeToCameraMap;

    public SetActiveCameraByGameModeSystem(GameContext game)
    {
      _gameModes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GameplayStateHolder));

      _togglers = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.CameraToggler));

      _gameModeToCameraMap = new Dictionary<GameplayStateId, CameraId>()
      {
        { GameplayStateId.Walking, CameraId.Player },
        { GameplayStateId.Alchemy, CameraId.Interact },
      };
    }

    public void Execute()
    {
      foreach (GameEntity gameMode in _gameModes)
      foreach (GameEntity toggler in _togglers)
      {
        toggler.ReplaceCameraId(_gameModeToCameraMap[gameMode.GameplayStateHolder]);
      }
    }
  }
}