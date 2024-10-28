using System;
using Code.Gameplay.Features;
using Code.Gameplay.Features.Models;
using Code.Gameplay.Features.States.AlchemyStates;
using Code.Gameplay.Features.States.AlchemyStates.Services;
using Zenject;

namespace Code
{
  public class AlchemyHeadsUpDisplayPresenter : IInitializable, IDisposable
  {
    private readonly GameplayStateHolderModel _gameplayStateHolderModel;
    private readonly AlchemyHeadsUpDisplayView _view;
    private readonly StateSwitcherService _stateSwitcherService;

    public AlchemyHeadsUpDisplayPresenter(GameplayStateHolderModel gameplayStateHolderModel,
      AlchemyHeadsUpDisplayView view, StateSwitcherService stateSwitcherService)
    {
      _gameplayStateHolderModel = gameplayStateHolderModel;
      _view = view;
      _stateSwitcherService = stateSwitcherService;
    }

    public void Initialize()
    {
      _gameplayStateHolderModel.ValueChanged += OnGameplayStateChanged;
      _view.ExitAlchemyTableButton.onClick.AddListener(ExitAchemyMode);
      _view.EnterIdleButton.onClick.AddListener(EnterIdleMode);
    }

    public void Dispose()
    {
      _gameplayStateHolderModel.ValueChanged -= OnGameplayStateChanged;
      _view.ExitAlchemyTableButton.onClick.RemoveListener(ExitAchemyMode);
      _view.EnterIdleButton.onClick.RemoveListener(EnterIdleMode);
    }

    private void EnterIdleMode()
    {
      _stateSwitcherService.EnterState(AlchemyStateId.Idle);
    }

    private void ExitAchemyMode()
    {
      _stateSwitcherService.EnterState(AlchemyStateId.Idle);
      _stateSwitcherService.EnterState(GameplayStateId.Walking);
    }

    private void ShowView()
    {
      if (_view.gameObject.activeSelf == false)
        _view.gameObject.SetActive(true);
    }

    private void HideView()
    {
      if (_view.gameObject.activeSelf)
        _view.gameObject.SetActive(false);
    }

    private void OnGameplayStateChanged(GameplayStateId state)
    {
      if (state == GameplayStateId.Alchemy)
        ShowView();
      else
        HideView();
    }
  }
}