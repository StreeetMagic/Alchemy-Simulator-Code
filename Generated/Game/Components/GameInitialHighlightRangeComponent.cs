//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInitialHighlightRange;

    public static Entitas.IMatcher<GameEntity> InitialHighlightRange {
        get {
            if (_matcherInitialHighlightRange == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InitialHighlightRange);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInitialHighlightRange = matcher;
            }

            return _matcherInitialHighlightRange;
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

    public Code.Gameplay.Features.Highlight.InitialHighlightRange initialHighlightRange { get { return (Code.Gameplay.Features.Highlight.InitialHighlightRange)GetComponent(GameComponentsLookup.InitialHighlightRange); } }
    public float InitialHighlightRange { get { return initialHighlightRange.Value; } }
    public bool hasInitialHighlightRange { get { return HasComponent(GameComponentsLookup.InitialHighlightRange); } }

    public GameEntity AddInitialHighlightRange(float newValue) {
        var index = GameComponentsLookup.InitialHighlightRange;
        var component = (Code.Gameplay.Features.Highlight.InitialHighlightRange)CreateComponent(index, typeof(Code.Gameplay.Features.Highlight.InitialHighlightRange));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceInitialHighlightRange(float newValue) {
        var index = GameComponentsLookup.InitialHighlightRange;
        var component = (Code.Gameplay.Features.Highlight.InitialHighlightRange)CreateComponent(index, typeof(Code.Gameplay.Features.Highlight.InitialHighlightRange));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveInitialHighlightRange() {
        RemoveComponent(GameComponentsLookup.InitialHighlightRange);
        return this;
    }
}
