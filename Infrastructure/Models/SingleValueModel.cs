using System;

namespace Code.Infrastructure.Models
{
  public abstract class SingleValueModel<T> : Model
  {
    private T _value;

    public event Action<T> ValueChanged;

    public T Value
    {
      get => _value;

      private set
      {
        if (_value != null)
        {
          if (_value.Equals(value))
            return;
        }

        _value = value;
        ValueChanged?.Invoke(_value);
      }
    }

    public override void Tick()
    {
      if (SetEntity())
        return;

      Value = OnTick();
    }

    protected abstract T OnTick();
  }
}