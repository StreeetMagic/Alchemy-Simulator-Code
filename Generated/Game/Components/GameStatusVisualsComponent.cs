//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStatusVisuals;

    public static Entitas.IMatcher<GameEntity> StatusVisuals {
        get {
            if (_matcherStatusVisuals == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatusVisuals);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatusVisuals = matcher;
            }

            return _matcherStatusVisuals;
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

    public Code.Common.StatusVisualsComponent statusVisuals { get { return (Code.Common.StatusVisualsComponent)GetComponent(GameComponentsLookup.StatusVisuals); } }
    public Code.Gameplay.Common.Visuals.StatusVisuals.IStatusVisuals StatusVisuals { get { return statusVisuals.Value; } }
    public bool hasStatusVisuals { get { return HasComponent(GameComponentsLookup.StatusVisuals); } }

    public GameEntity AddStatusVisuals(Code.Gameplay.Common.Visuals.StatusVisuals.IStatusVisuals newValue) {
        var index = GameComponentsLookup.StatusVisuals;
        var component = (Code.Common.StatusVisualsComponent)CreateComponent(index, typeof(Code.Common.StatusVisualsComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceStatusVisuals(Code.Gameplay.Common.Visuals.StatusVisuals.IStatusVisuals newValue) {
        var index = GameComponentsLookup.StatusVisuals;
        var component = (Code.Common.StatusVisualsComponent)CreateComponent(index, typeof(Code.Common.StatusVisualsComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveStatusVisuals() {
        RemoveComponent(GameComponentsLookup.StatusVisuals);
        return this;
    }
}