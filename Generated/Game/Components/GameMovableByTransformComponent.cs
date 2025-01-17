//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovableByTransform;

    public static Entitas.IMatcher<GameEntity> MovableByTransform {
        get {
            if (_matcherMovableByTransform == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovableByTransform);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovableByTransform = matcher;
            }

            return _matcherMovableByTransform;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Movement.MovableByTransform movableByTransformComponent = new Code.Gameplay.Features.Movement.MovableByTransform();

    public bool isMovableByTransform {
        get { return HasComponent(GameComponentsLookup.MovableByTransform); }
        set {
            if (value != isMovableByTransform) {
                var index = GameComponentsLookup.MovableByTransform;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : movableByTransformComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
