//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherToAlchemyIdleStateTransitionFlag;

    public static Entitas.IMatcher<GameEntity> ToAlchemyIdleStateTransitionFlag {
        get {
            if (_matcherToAlchemyIdleStateTransitionFlag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ToAlchemyIdleStateTransitionFlag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherToAlchemyIdleStateTransitionFlag = matcher;
            }

            return _matcherToAlchemyIdleStateTransitionFlag;
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

    static readonly Code.Gameplay.Features.States.AlchemyStates.ToAlchemyIdleStateTransitionFlag toAlchemyIdleStateTransitionFlagComponent = new Code.Gameplay.Features.States.AlchemyStates.ToAlchemyIdleStateTransitionFlag();

    public bool isToAlchemyIdleStateTransitionFlag {
        get { return HasComponent(GameComponentsLookup.ToAlchemyIdleStateTransitionFlag); }
        set {
            if (value != isToAlchemyIdleStateTransitionFlag) {
                var index = GameComponentsLookup.ToAlchemyIdleStateTransitionFlag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : toAlchemyIdleStateTransitionFlagComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
