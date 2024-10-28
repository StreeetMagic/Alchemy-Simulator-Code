//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHighlighter;

    public static Entitas.IMatcher<GameEntity> Highlighter {
        get {
            if (_matcherHighlighter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Highlighter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHighlighter = matcher;
            }

            return _matcherHighlighter;
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

    static readonly Code.Gameplay.Features.Highlight.HighlighterComponent highlighterComponent = new Code.Gameplay.Features.Highlight.HighlighterComponent();

    public bool isHighlighter {
        get { return HasComponent(GameComponentsLookup.Highlighter); }
        set {
            if (value != isHighlighter) {
                var index = GameComponentsLookup.Highlighter;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : highlighterComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
