Проект на ECS Entitas в начальной стадии.

Симулятор алхимика от первого лица. Видео геймплея в конце.

На данный момент реализовано:

-передвижение (спринт, ходьба, присяд, прыжок) + покачивание камеры

-подбор предметов с земли + подсветка + попап

-переход в режим алхимии (активация стола)

-вращение колбы при круговых движениях мышкой

Изначально взял готовый контроллер движения на ООП и полностью переписал на ECS.
Затем добавил взаимодействие с предметами и переходы в разные режимы.
Далее дописал вращание колбы через вращение мышки (на записи не видно курсор) При переходе в режим Mixing если вращать курсор вокруг центра экрана, то колба вращается в ту же сторону. 
Недавно начал работать над инвентарем. Купили готовый ассет, рефакторю код. Сейчас показать нечего.

В архитектурном плане задался целью отделить мир ECS от отображения таким образом:
1. Системы ECS не должны знать о UI и любом отображении
2. Компоненты ECS должны хранить только одно значение и оно должно быть простым типом (без реактивности и событий)

После пары дней эксперементов пришел к такому решению:
![image](https://github.com/user-attachments/assets/15816f86-412d-4b7e-9b95-3761721f61fe)

Таким образом для каждого компонента из ECS, который мы хотим событийно наблюдать, мы пишем модельку, которая через Tick() Zenjecta менеджит изменения и инвокает событие, если состояние поменялось. Производительность не тестил, но, думаю, все ок. С коллекциями работает, проверял.


Исходный код моделек:
```
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
```

```
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
```
```
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
  ```


https://www.youtube.com/watch?v=01QSn-BVQjs
