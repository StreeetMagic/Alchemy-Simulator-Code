using Code.Gameplay.Features.States.AlchemyStates;
using Entitas;

namespace Code.Gameplay.Features.Flasks.Systems
{
  public class ShakeMixingFlaskSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _mixingFlasks;
    private readonly IGroup<GameEntity> _alchemyModes;

    public ShakeMixingFlaskSystem(GameContext game)
    {
      _mixingFlasks = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.MixingFlaskShaker));
    
      _alchemyModes = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.AlchemyStateHolder));
    }
  
    public void Execute()
    {
      foreach (GameEntity mixingFlask in _mixingFlasks)
      foreach (GameEntity alchemyMode in _alchemyModes)
      {
        if (alchemyMode.AlchemyStateHolder != AlchemyStateId.FlaskShaking)
          continue;
      
        mixingFlask.MixingFlaskShaker.Tick();
      }
    }
  }
}
