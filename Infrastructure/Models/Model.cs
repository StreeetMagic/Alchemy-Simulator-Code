using Entitas;
using Zenject;

namespace Code.Infrastructure.Models
{
  public abstract class Model : ITickable
  {
    protected IGroup<GameEntity> Entities;
    
    public GameEntity Entity { get; private set; }
    
    public abstract void Tick();

    protected bool SetEntity()
    {
      Entity = Entities.GetSingleEntity();

      return Entity == null;
    }
  }
}