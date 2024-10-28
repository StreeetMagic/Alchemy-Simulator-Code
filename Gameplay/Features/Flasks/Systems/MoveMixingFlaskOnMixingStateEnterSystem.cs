using Code.Gameplay.Features.Flasks.Services;
using Entitas;

namespace Code.Gameplay.Features.Flasks.Systems
{
  public class MoveMixingFlaskOnMixingStateEnterSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _states;
    private readonly IGroup<GameEntity> _flasks;
    private readonly IGroup<GameEntity> _mixingPoints;
    private readonly FlaskMovingService _flaskMovingService;

    public MoveMixingFlaskOnMixingStateEnterSystem(GameContext game, FlaskMovingService flaskMovingService)
    {
      _states = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ToAlchemyMixingStateTransitionFlag
        ));

      _flasks = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.MixingFlask,
          GameMatcher.Transform
        ));

      _mixingPoints = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.MixingFlaskShakePoint,
          GameMatcher.WorldPosition
        ));
      
      _flaskMovingService = flaskMovingService;
    }

    public void Execute()
    {
      foreach (GameEntity unused in _states)
      foreach (GameEntity flask in _flasks)
      foreach (GameEntity mixPoint in _mixingPoints)
      {
        _flaskMovingService.Move(flask.Transform, mixPoint.WorldPosition);
      }
    }
  }
}