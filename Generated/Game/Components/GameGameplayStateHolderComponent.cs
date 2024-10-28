//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameplayStateHolder;

    public static Entitas.IMatcher<GameEntity> GameplayStateHolder {
        get {
            if (_matcherGameplayStateHolder == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameplayStateHolder);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameplayStateHolder = matcher;
            }

            return _matcherGameplayStateHolder;
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

    public Code.Gameplay.Features.GameplayStateHolder gameplayStateHolder { get { return (Code.Gameplay.Features.GameplayStateHolder)GetComponent(GameComponentsLookup.GameplayStateHolder); } }
    public Code.Gameplay.Features.GameplayStateId GameplayStateHolder { get { return gameplayStateHolder.Value; } }
    public bool hasGameplayStateHolder { get { return HasComponent(GameComponentsLookup.GameplayStateHolder); } }

    public GameEntity AddGameplayStateHolder(Code.Gameplay.Features.GameplayStateId newValue) {
        var index = GameComponentsLookup.GameplayStateHolder;
        var component = (Code.Gameplay.Features.GameplayStateHolder)CreateComponent(index, typeof(Code.Gameplay.Features.GameplayStateHolder));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceGameplayStateHolder(Code.Gameplay.Features.GameplayStateId newValue) {
        var index = GameComponentsLookup.GameplayStateHolder;
        var component = (Code.Gameplay.Features.GameplayStateHolder)CreateComponent(index, typeof(Code.Gameplay.Features.GameplayStateHolder));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveGameplayStateHolder() {
        RemoveComponent(GameComponentsLookup.GameplayStateHolder);
        return this;
    }
}