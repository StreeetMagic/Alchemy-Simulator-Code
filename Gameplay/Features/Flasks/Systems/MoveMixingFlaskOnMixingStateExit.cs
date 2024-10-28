using Code.Gameplay.Features.Flasks.Services;
using Entitas;

namespace Code.Gameplay.Features.Flasks.Systems
{
  public class MoveMixingFlaskOnMixingStateExit : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _states;
    private readonly IGroup<GameEntity> _flasks;
    private readonly IGroup<GameEntity> _stationaryPoints;
    private readonly FlaskMovingService _flaskMovingService;

    public MoveMixingFlaskOnMixingStateExit(GameContext game, FlaskMovingService flaskMovingService)
    {
      _flaskMovingService = flaskMovingService;
      _states = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.FromAlchemyMixingStateTransitionFlag));

      _flasks = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.MixingFlask,
          GameMatcher.Transform
        ));

      _stationaryPoints = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.MixingFlaskStationaryPoint,
          GameMatcher.WorldPosition
        ));
    }

    public void Execute()
    {
      foreach (GameEntity unused in _states)
      foreach (GameEntity flask in _flasks)
      foreach (GameEntity point in _stationaryPoints)
      {
        _flaskMovingService.Move(flask.Transform, point.WorldPosition);
      }
    }
  }
}