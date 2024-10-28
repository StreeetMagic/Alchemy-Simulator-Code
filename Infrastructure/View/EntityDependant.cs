using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Infrastructure.View
{
  public abstract class EntityDependant : MonoBehaviour
  {
    [FormerlySerializedAs("EntityView")]
    public EntityBinder EntityBinder;

    protected GameEntity Entity => EntityBinder != null
      ? EntityBinder.Entity
      : null;

    private void Awake()
    {
      if (!EntityBinder)
        EntityBinder = GetComponent<EntityBinder>();
    }
  }
}