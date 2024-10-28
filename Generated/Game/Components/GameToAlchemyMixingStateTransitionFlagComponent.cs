//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherToAlchemyMixingStateTransitionFlag;

    public static Entitas.IMatcher<GameEntity> ToAlchemyMixingStateTransitionFlag {
        get {
            if (_matcherToAlchemyMixingStateTransitionFlag == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ToAlchemyMixingStateTransitionFlag);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherToAlchemyMixingStateTransitionFlag = matcher;
            }

            return _matcherToAlchemyMixingStateTransitionFlag;
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

    static readonly Code.Gameplay.Features.States.AlchemyStates.ToAlchemyMixingStateTransitionFlag toAlchemyMixingStateTransitionFlagComponent = new Code.Gameplay.Features.States.AlchemyStates.ToAlchemyMixingStateTransitionFlag();

    public bool isToAlchemyMixingStateTransitionFlag {
        get { return HasComponent(GameComponentsLookup.ToAlchemyMixingStateTransitionFlag); }
        set {
            if (value != isToAlchemyMixingStateTransitionFlag) {
                var index = GameComponentsLookup.ToAlchemyMixingStateTransitionFlag;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : toAlchemyMixingStateTransitionFlagComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
