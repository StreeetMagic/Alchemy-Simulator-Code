using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
  public class EntityBinder : MonoBehaviour, IEntityView
  {
    private ICollisionRegistry _collisionRegistry;
    
    public GameEntity Entity { get; private set; }

    [Inject]
    private void Construct(ICollisionRegistry collisionRegistry) => 
      _collisionRegistry = collisionRegistry;

    public void SetEntity(GameEntity entity)
    {
      Entity = entity;
      Entity.AddView(this);
      Entity.Retain(this);

      foreach (IEntityComponentRegistrar registrar in GetComponents<IEntityComponentRegistrar>()) 
        registrar.RegisterComponents();

      foreach (Collider collider2d in GetComponentsInChildren<Collider>(includeInactive: true)) 
        _collisionRegistry.Register(collider2d.GetInstanceID(), Entity);
    }

    public void ReleaseEntity()
    {
      foreach (IEntityComponentRegistrar registrar in GetComponentsInChildren<IEntityComponentRegistrar>()) 
        registrar.UnregisterComponents();

      foreach (Collider collider2d in GetComponentsInChildren<Collider>(includeInactive: true)) 
        _collisionRegistry.Unregister(collider2d.GetInstanceID());
      
      Entity.Release(this);
      Entity = null;
    }
  }
}