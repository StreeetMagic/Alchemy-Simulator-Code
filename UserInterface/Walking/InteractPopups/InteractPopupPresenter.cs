using System;
using Code.Gameplay.Features.Inputs.Service;
using Code.Gameplay.Features.Model;
using Code.Gameplay.Features.Models;
using Zenject;

namespace Code.InteractPopups
{
  public class InteractPopupPresenter : ITickable, IInitializable, IDisposable
  {
    private readonly InteractPopupView _view;
    private readonly IInputService _inputService;

    private readonly CurrentRaycastDistanceModel _currentRaycastDistanceModel;
    private readonly InitialInteractDistanceModel _initialInteractDistanceModel;
    private readonly GameplayStateRelativeTimerModel _timerModel;
    private readonly InteractableNameModel _interactableNameModel;
    private readonly InteractableActionNameModel _interactableActionNameModel;
    private readonly SingleRaycasterTargetIdModel _targetIdModel;

    public InteractPopupPresenter(
      InteractPopupView view,
      IInputService inputService,
      CurrentRaycastDistanceModel currentRaycastDistanceModel,
      InitialInteractDistanceModel initialInteractDistanceModel,
      GameplayStateRelativeTimerModel gameplayStateRelativeTimerModel,
      InteractableNameModel interactableNameModel,
      InteractableActionNameModel interactableActionNameModel,
      SingleRaycasterTargetIdModel singleRaycasterTargetIdModel)
    {
      _inputService = inputService;
      _view = view;

      _currentRaycastDistanceModel = currentRaycastDistanceModel;
      _initialInteractDistanceModel = initialInteractDistanceModel;
      _timerModel = gameplayStateRelativeTimerModel;
      _interactableNameModel = interactableNameModel;
      _interactableActionNameModel = interactableActionNameModel;
      _targetIdModel = singleRaycasterTargetIdModel;
    }

    public void Initialize()
    {
      _currentRaycastDistanceModel.ValueChanged += OnRaycastDistanceChanged;
      _timerModel.ValueChanged += OnTimerChanged;
      _interactableNameModel.ValueChanged += OnInteractableNameChanged;
      _interactableActionNameModel.ValueChanged += OnInteractableActionNameChanged;
      _targetIdModel.ValueChanged += OnTargetIdChanged;
    }

    public void Tick()
    {
      if (_inputService.InterractKeyDown)
        return;
      
      _view.SetSliderValue(0);
    }

    public void Dispose()
    {
      _currentRaycastDistanceModel.ValueChanged -= OnRaycastDistanceChanged;
      _timerModel.ValueChanged -= OnTimerChanged;
      _interactableNameModel.ValueChanged -= OnInteractableNameChanged;
      _interactableActionNameModel.ValueChanged -= OnInteractableActionNameChanged;
      _targetIdModel.ValueChanged -= OnTargetIdChanged;
    }

    private void OnTargetIdChanged(int id)
    {
      if (id == 0)
        _view.Hide();
    }

    private void OnInteractableNameChanged(string name)
    {
      if (_interactableNameModel.Entity.isDurationFlag)
        _view.SetHoldState(name, "E", _interactableActionNameModel.Value, "HOLD");
      else
        _view.SetPressState(name, "E", _interactableActionNameModel.Value);
    }

    private void OnInteractableActionNameChanged(string actionName)
    {
      if (_interactableNameModel.Entity.isDurationFlag)
        _view.SetHoldState(_interactableNameModel.Value, "E", actionName, "HOLD");
      else
        _view.SetPressState(_interactableNameModel.Value, "E", actionName);
    }

    private void OnTimerChanged(float value)
    {
      _view.SetSliderValue(1 - value);
    }

    private void OnRaycastDistanceChanged(float distance)
    {
      if (distance > _initialInteractDistanceModel.Value)
        _view.Hide();
      else
        _view.Show();
    }
  }
}