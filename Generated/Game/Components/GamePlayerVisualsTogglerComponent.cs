//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlayerVisualsToggler;

    public static Entitas.IMatcher<GameEntity> PlayerVisualsToggler {
        get {
            if (_matcherPlayerVisualsToggler == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerVisualsToggler);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerVisualsToggler = matcher;
            }

            return _matcherPlayerVisualsToggler;
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

    public Code.Gameplay.Features.Player.PlayerVisualsTogglerComponent playerVisualsToggler { get { return (Code.Gameplay.Features.Player.PlayerVisualsTogglerComponent)GetComponent(GameComponentsLookup.PlayerVisualsToggler); } }
    public Code.Gameplay.Features.Player.PlayerVisualsToggler PlayerVisualsToggler { get { return playerVisualsToggler.Value; } }
    public bool hasPlayerVisualsToggler { get { return HasComponent(GameComponentsLookup.PlayerVisualsToggler); } }

    public GameEntity AddPlayerVisualsToggler(Code.Gameplay.Features.Player.PlayerVisualsToggler newValue) {
        var index = GameComponentsLookup.PlayerVisualsToggler;
        var component = (Code.Gameplay.Features.Player.PlayerVisualsTogglerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Player.PlayerVisualsTogglerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplacePlayerVisualsToggler(Code.Gameplay.Features.Player.PlayerVisualsToggler newValue) {
        var index = GameComponentsLookup.PlayerVisualsToggler;
        var component = (Code.Gameplay.Features.Player.PlayerVisualsTogglerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Player.PlayerVisualsTogglerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemovePlayerVisualsToggler() {
        RemoveComponent(GameComponentsLookup.PlayerVisualsToggler);
        return this;
    }
}
