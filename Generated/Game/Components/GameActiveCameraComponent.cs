//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherActiveCamera;

    public static Entitas.IMatcher<GameEntity> ActiveCamera {
        get {
            if (_matcherActiveCamera == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ActiveCamera);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherActiveCamera = matcher;
            }

            return _matcherActiveCamera;
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

    static readonly Code.Gameplay.Features.ActiveCamera activeCameraComponent = new Code.Gameplay.Features.ActiveCamera();

    public bool isActiveCamera {
        get { return HasComponent(GameComponentsLookup.ActiveCamera); }
        set {
            if (value != isActiveCamera) {
                var index = GameComponentsLookup.ActiveCamera;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : activeCameraComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
