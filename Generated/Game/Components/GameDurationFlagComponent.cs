//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDurationFlag;

    public static Entitas.IMatcher<GameEntity> DurationFlag {
        get {
            if (_matcherDurationFlag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DurationFlag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDurationFlag = matcher;
            }

            return _matcherDurationFlag;
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

    static readonly Code.Gameplay.Common.DurationFlag durationFlagComponent = new Code.Gameplay.Common.DurationFlag();

    public bool isDurationFlag {
        get { return HasComponent(GameComponentsLookup.DurationFlag); }
        set {
            if (value != isDurationFlag) {
                var index = GameComponentsLookup.DurationFlag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : durationFlagComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}