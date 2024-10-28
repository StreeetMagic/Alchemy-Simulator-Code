using System;
using System.Collections.Generic;

namespace Code.Infrastructure.Models
{
  public abstract class CollectionModel<T> : Model
  {
    private readonly List<T> _cached = new();

    public event Action<IReadOnlyCollection<T>> CollectionChanged;

    public override void Tick()
    {
      if (SetEntity())
        return;

      OnTick();
    }

    protected abstract void OnTick();

    protected void HandleCollection(IReadOnlyCollection<T> collection)
    {
      if (_cached.Count != collection.Count)
      {
        ReCache(collection);
        return;
      }

      var areEqual = true;
      int index = 0;

      foreach (T item in collection)
      {
        if (!item.Equals(_cached[index++]))
        {
          areEqual = false;
          break;
        }
      }

      if (!areEqual)
        ReCache(collection);
    }

    private void ReCache(IReadOnlyCollection<T> collection)
    {
      _cached.Clear();

      foreach (T item in collection)
        _cached.Add(item);

      CollectionChanged?.Invoke(_cached);
    }
  }
}