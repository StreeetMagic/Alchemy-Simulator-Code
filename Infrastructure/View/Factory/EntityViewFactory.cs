using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
  public class EntityViewFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly Vector3 _farAway = new(-999, 999, 0);

    public EntityViewFactory(IInstantiator instantiator)
    {
      _instantiator = instantiator;
    }

    // public EntityBinder CreateViewForEntity(GameEntity entity)
    // {
    //   EntityBinder viewPrefab = _devConfigProvider.GetPrefabForComponent<EntityBinder>(entity.ViewId);
    //
    //   EntityBinder view = _instantiator.InstantiatePrefabForComponent<EntityBinder>
    //   (
    //     viewPrefab,
    //     position: _farAway,
    //     Quaternion.identity,
    //     parentTransform: null
    //   );
    //
    //   view.SetEntity(entity);
    //
    //   return view;
    // }

    public EntityBinder CreateViewForEntityFromPrefab(GameEntity entity)
    {
      EntityBinder binder = _instantiator.InstantiatePrefabForComponent<EntityBinder>(
        entity.ViewPrefab,
        position: _farAway,
        Quaternion.identity,
        parentTransform: null);

      binder.SetEntity(entity);

      return binder;
    }
  }
}