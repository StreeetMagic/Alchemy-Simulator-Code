using System;
using Code.Gameplay.Features.States.AlchemyStates;
using Code.Gameplay.Features.States.AlchemyStates.Models;
using Code.Gameplay.Features.States.AlchemyStates.Services;
using UnityEngine.Events;
using Zenject;

namespace Code.Idle
{
  public class AlchemyIdleHeadsUpDisplayPresenter : IInitializable, IDisposable
  {
    private readonly AlchemyIdleHeadsUpDisplayView _view;
    private readonly AlchemyStateHolderModel _alchemyStateHolderModel;
    private readonly StateSwitcherService _stateSwitcherService;

    public AlchemyIdleHeadsUpDisplayPresenter(AlchemyIdleHeadsUpDisplayView view, AlchemyStateHolderModel alchemyStateHolderModel,
      StateSwitcherService stateSwitcherService)
    {
      _view = view;
      _alchemyStateHolderModel = alchemyStateHolderModel;
      _stateSwitcherService = stateSwitcherService;
    }

    public void Initialize()
    {
      _alchemyStateHolderModel.ValueChanged += OnAlchemyStateChanged;
      _view.EnterAlchemyPreparingStateButton.onClick.AddListener(Enter(AlchemyStateId.Preparaion));
      _view.EnterAlchemyCookingStateButton.onClick.AddListener(Enter(AlchemyStateId.Cooking));
      _view.EnterAlchemyMixingStateButton.onClick.AddListener(Enter(AlchemyStateId.Mixing));
      _view.EnterAlchemyShakingStateButton.onClick.AddListener(Enter(AlchemyStateId.FlaskShaking));
    }

    public void Dispose()
    {
      _alchemyStateHolderModel.ValueChanged -= OnAlchemyStateChanged;
      _view.EnterAlchemyPreparingStateButton.onClick.RemoveListener(Enter(AlchemyStateId.Preparaion));
      _view.EnterAlchemyCookingStateButton.onClick.RemoveListener(Enter(AlchemyStateId.Cooking));
      _view.EnterAlchemyMixingStateButton.onClick.RemoveListener(Enter(AlchemyStateId.Mixing));
      _view.EnterAlchemyShakingStateButton.onClick.RemoveListener(Enter(AlchemyStateId.FlaskShaking));
    }

    private void OnAlchemyStateChanged(AlchemyStateId state)
    {
      if (state == AlchemyStateId.Idle)
        _view.Show();
      else
        _view.Hide();
    }

    private UnityAction Enter(AlchemyStateId state) =>
      () => { _stateSwitcherService.EnterState(state); };
  }
}