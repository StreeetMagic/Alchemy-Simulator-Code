//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHighlightHolder;

    public static Entitas.IMatcher<GameEntity> HighlightHolder {
        get {
            if (_matcherHighlightHolder == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HighlightHolder);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHighlightHolder = matcher;
            }

            return _matcherHighlightHolder;
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

    public Code.Gameplay.Features.Highlight.HighlightHolder highlightHolder { get { return (Code.Gameplay.Features.Highlight.HighlightHolder)GetComponent(GameComponentsLookup.HighlightHolder); } }
    public int HighlightHolder { get { return highlightHolder.Value; } }
    public bool hasHighlightHolder { get { return HasComponent(GameComponentsLookup.HighlightHolder); } }

    public GameEntity AddHighlightHolder(int newValue) {
        var index = GameComponentsLookup.HighlightHolder;
        var component = (Code.Gameplay.Features.Highlight.HighlightHolder)CreateComponent(index, typeof(Code.Gameplay.Features.Highlight.HighlightHolder));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHighlightHolder(int newValue) {
        var index = GameComponentsLookup.HighlightHolder;
        var component = (Code.Gameplay.Features.Highlight.HighlightHolder)CreateComponent(index, typeof(Code.Gameplay.Features.Highlight.HighlightHolder));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHighlightHolder() {
        RemoveComponent(GameComponentsLookup.HighlightHolder);
        return this;
    }
}
