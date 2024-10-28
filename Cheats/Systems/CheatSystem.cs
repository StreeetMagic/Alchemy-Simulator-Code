using Code.Gameplay.Features;
using Code.Gameplay.Features.States.AlchemyStates.Services;
using Entitas;
using UnityEngine;

namespace Code
{
  public class CheatSystem : IExecuteSystem
  {
    private readonly StateSwitcherService _stateSwitcherService;

    public CheatSystem(StateSwitcherService stateSwitcherService)
    {
      _stateSwitcherService = stateSwitcherService;
    }

    public void Execute()
    {
      if (Input.GetKeyDown(KeyCode.Alpha1))
        _stateSwitcherService.EnterState(GameplayStateId.Walking);

      if (Input.GetKeyDown(KeyCode.Alpha2))
        _stateSwitcherService.EnterState(GameplayStateId.Alchemy);
    }
  }
}