using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Registrars
{
  public class PlayerVisualsTogglerRegistrar : EntityComponentRegistrar
  {
    [SerializeField]
    public PlayerVisualsToggler VisualsToggler;

    public override void RegisterComponents()
    {
      Entity.AddPlayerVisualsToggler(VisualsToggler);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasPlayerVisualsToggler)
        Entity.RemovePlayerVisualsToggler();
    }
  }
}