using System;
using Code.Gameplay.Features.States.AlchemyStates;
using Code.Gameplay.Features.States.AlchemyStates.Models;
using Zenject;

namespace Code.Shaking
{
  public class AlchemyShakingHeadsUpDisplayPresenter : IDisposable, IInitializable
  {
    private readonly AlchemyStateHolderModel _alchemyStateHolderModel;
    private readonly AlchemyShakingHeadsUpDisplayView _view;

    public AlchemyShakingHeadsUpDisplayPresenter(AlchemyStateHolderModel alchemyStateHolderModel,
      AlchemyShakingHeadsUpDisplayView view)
    {
      _alchemyStateHolderModel = alchemyStateHolderModel;
      _view = view;
    }

    public void Initialize()
    {
      _alchemyStateHolderModel.ValueChanged += OnAlchemyStateChanged;
    }

    public void Dispose()
    {
      _alchemyStateHolderModel.ValueChanged -= OnAlchemyStateChanged;
    }

    private void OnAlchemyStateChanged(AlchemyStateId state)
    {
      switch (state)
      {
        case AlchemyStateId.Idle:
        case AlchemyStateId.Preparaion:
        case AlchemyStateId.Mixing:
        case AlchemyStateId.Cooking:
          _view.Hide();
          break;

        case AlchemyStateId.FlaskShaking:
          _view.Show();
          break;

        default:
        case AlchemyStateId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
    }
  }
}