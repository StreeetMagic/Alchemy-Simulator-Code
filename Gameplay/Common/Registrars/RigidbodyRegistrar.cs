using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
  public class RigidbodyRegistrar : EntityComponentRegistrar
  {
    public Rigidbody Rigidbody;

    public override void RegisterComponents()
    {
      Entity.AddRigidbody(Rigidbody);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasRigidbody)
        Entity.RemoveRigidbody();
    }
  }
}