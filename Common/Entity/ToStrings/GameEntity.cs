using System;
using System.Linq;
using System.Text;
using Code.Common;
using Code.Gameplay.Features;
using Code.Gameplay.Features.AudioListeners;
using Code.Gameplay.Features.Desk;
using Code.Gameplay.Features.Inputs;
using Code.Gameplay.Features.Player;
using Code.Gameplay.Features.PlayerCameras;
using Entitas;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
  private EntityPrinter _printer;

  public override string ToString()
  {
    _printer ??= new EntityPrinter(this);

    _printer.InvalidateCache();

    return _printer.BuildToString();
  }

  public string EntityName(IComponent[] components)
  {
    try
    {
      if (components.Length == 1)
        return components[0].GetType().Name;

      string[] validComponentNames =
      {
        nameof(Player),
        nameof(CameraToggler),
        nameof(InteractCamera),
        nameof(PlayerCamera),
        nameof(Desk),
        nameof(Code.Gameplay.Features.GameplayStateHolder),
        nameof(UserInput),
        nameof(AudioListenerComponent),
        nameof(Code.Gameplay.Features.Items.Item),
        nameof(Code.Gameplay.Features.Inventories.Inventory),
        nameof(Code.Gameplay.Features.States.AlchemyStates.AlchemyStateHolder),
        nameof(Code.Gameplay.Features.Flasks.MixingFlaskShakePoint),
        nameof(Code.Gameplay.Features.Flasks.MixingFlaskStationaryPoint),
        nameof(Code.Gameplay.Features.Flasks.MixingFlask),
      };

      foreach (IComponent component in components)
      {
        string componentName = component.GetType().Name;

        if (validComponentNames.Contains(componentName))
          return Print(componentName);
      }
    }
    catch (Exception exception)
    {
      Debug.LogError(exception.Message);
    }

    return components.First().GetType().Name;
  }

  private string Print(string name)
  {
    return new StringBuilder(name)
      .With(s => s.Append($" Id:{Id}"), when: hasId)
      .ToString();
  }

  public string BaseToString() =>
    base.ToString();
}