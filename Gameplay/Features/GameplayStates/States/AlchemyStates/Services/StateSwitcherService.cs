using Code.Common;

namespace Code.Gameplay.Features.States.AlchemyStates.Services
{
  public class StateSwitcherService
  {
    public void EnterState(AlchemyStateId stateId)
    {
      CreateEntity
        .Empty()
        .AddTimerMaxValue(0)
        .AddAlchemyStateChanger(stateId);
    }

    public void EnterState(GameplayStateId stateId)
    {
      CreateEntity
        .Empty()
        .AddTimerMaxValue(0)
        .AddGameplayStateChanger(stateId);
    }

    public void EnterState(GameplayStateId stateId, float duration)
    {
      CreateEntity
        .Empty()
        .AddTimerMaxValue(duration)
        .AddGameplayStateChanger(stateId)
        .With(x => x.isDurationFlag = true)
        ;
    }
  }
}