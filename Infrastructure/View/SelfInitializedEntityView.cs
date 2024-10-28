using Code.Common;
using Code.Infrastructure.Identifiers;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
  public class SelfInitializedEntityView : MonoBehaviour
  {
    public EntityBinder EntityBinder;
    private IIdentifierService _identifiers;

    [Inject]
    private void Construct(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    private void Awake()
    {
      EntityBinder = GetComponent<EntityBinder>();

      GameEntity entity =
        CreateEntity
          .Empty()
          .AddId(_identifiers.Next());

      EntityBinder.SetEntity(entity);
    }
  }
}