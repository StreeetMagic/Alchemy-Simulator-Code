using UnityEngine;

namespace Code.Infrastructure.View
{
  public interface IEntityView
  {
    GameEntity Entity { get; }
    void SetEntity(GameEntity entity);
    void ReleaseEntity();
    
    // ReSharper disable once InconsistentNaming
    GameObject gameObject { get; }
  }
}