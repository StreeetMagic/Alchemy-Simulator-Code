//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAudioListener;

    public static Entitas.IMatcher<GameEntity> AudioListener {
        get {
            if (_matcherAudioListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AudioListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAudioListener = matcher;
            }

            return _matcherAudioListener;
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

    public Code.Gameplay.Features.AudioListeners.AudioListenerComponent audioListener { get { return (Code.Gameplay.Features.AudioListeners.AudioListenerComponent)GetComponent(GameComponentsLookup.AudioListener); } }
    public UnityEngine.AudioListener AudioListener { get { return audioListener.Value; } }
    public bool hasAudioListener { get { return HasComponent(GameComponentsLookup.AudioListener); } }

    public GameEntity AddAudioListener(UnityEngine.AudioListener newValue) {
        var index = GameComponentsLookup.AudioListener;
        var component = (Code.Gameplay.Features.AudioListeners.AudioListenerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.AudioListeners.AudioListenerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAudioListener(UnityEngine.AudioListener newValue) {
        var index = GameComponentsLookup.AudioListener;
        var component = (Code.Gameplay.Features.AudioListeners.AudioListenerComponent)CreateComponent(index, typeof(Code.Gameplay.Features.AudioListeners.AudioListenerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAudioListener() {
        RemoveComponent(GameComponentsLookup.AudioListener);
        return this;
    }
}
