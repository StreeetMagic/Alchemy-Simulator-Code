using System;
using Code.Gameplay.Features;
using Code.Gameplay.Features.Models;
using Zenject;

namespace Code
{
  public class WalkingHeadsUpDisplayPresenter : IInitializable, IDisposable
  {
    private readonly WalkingHeadsUpDisplayView _view;
    private readonly GameplayStateHolderModel _gameplayStateHolderModel;

    public WalkingHeadsUpDisplayPresenter(WalkingHeadsUpDisplayView view, GameplayStateHolderModel gameplayStateHolderModel)
    {
      _view = view;
      _gameplayStateHolderModel = gameplayStateHolderModel;
    }

    public void Initialize()
    {
      _gameplayStateHolderModel.ValueChanged += OnGameplayStateChanged;
    }

    public void Dispose()
    {
      _gameplayStateHolderModel.ValueChanged -= OnGameplayStateChanged;
    }

    private void OnGameplayStateChanged(GameplayStateId state)
    {
      if (state == GameplayStateId.Walking)
        ShowView();
      else
        HideView();
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
  }
}