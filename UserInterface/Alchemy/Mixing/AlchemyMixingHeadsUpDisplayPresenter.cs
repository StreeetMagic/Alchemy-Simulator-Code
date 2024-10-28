using System;
using Code.Gameplay.Features.States.AlchemyStates;
using Code.Gameplay.Features.States.AlchemyStates.Models;
using Zenject;

namespace Code.Mixing
{
  public class AlchemyMixingHeadsUpDisplayPresenter : IInitializable, IDisposable
  {
    private readonly AlchemyStateHolderModel _alchemyStateHolderModel;
    private readonly AlchemyMixingHeadsUpDisplayView _view;

    public AlchemyMixingHeadsUpDisplayPresenter(AlchemyStateHolderModel alchemyStateHolderModel,
      AlchemyMixingHeadsUpDisplayView view)
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
        case AlchemyStateId.FlaskShaking:
        case AlchemyStateId.Cooking:
          _view.Hide();
          break;
        
        case AlchemyStateId.Mixing:
          _view.Show();
          break;
        
        default:
        case AlchemyStateId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
    }
  }
}