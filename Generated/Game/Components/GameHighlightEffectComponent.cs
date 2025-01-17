//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHighlightEffect;

    public static Entitas.IMatcher<GameEntity> HighlightEffect {
        get {
            if (_matcherHighlightEffect == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HighlightEffect);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHighlightEffect = matcher;
            }

            return _matcherHighlightEffect;
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

    public Code.Gameplay.Features.Highlight.HighlightEffectComponent highlightEffect { get { return (Code.Gameplay.Features.Highlight.HighlightEffectComponent)GetComponent(GameComponentsLookup.HighlightEffect); } }
    public HighlightPlus.HighlightEffect HighlightEffect { get { return highlightEffect.Value; } }
    public bool hasHighlightEffect { get { return HasComponent(GameComponentsLookup.HighlightEffect); } }

    public GameEntity AddHighlightEffect(HighlightPlus.HighlightEffect newValue) {
        var index = GameComponentsLookup.HighlightEffect;
        var component = (Code.Gameplay.Features.Highlight.HighlightEffectComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Highlight.HighlightEffectComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHighlightEffect(HighlightPlus.HighlightEffect newValue) {
        var index = GameComponentsLookup.HighlightEffect;
        var component = (Code.Gameplay.Features.Highlight.HighlightEffectComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Highlight.HighlightEffectComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHighlightEffect() {
        RemoveComponent(GameComponentsLookup.HighlightEffect);
        return this;
    }
}
