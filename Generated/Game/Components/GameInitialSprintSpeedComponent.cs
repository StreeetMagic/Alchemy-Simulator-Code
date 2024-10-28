//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherInitialSprintSpeed;

    public static Entitas.IMatcher<GameEntity> InitialSprintSpeed {
        get {
            if (_matcherInitialSprintSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InitialSprintSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInitialSprintSpeed = matcher;
            }

            return _matcherInitialSprintSpeed;
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

    public Code.Gameplay.Features.Movement.InitialSprintSpeed initialSprintSpeed { get { return (Code.Gameplay.Features.Movement.InitialSprintSpeed)GetComponent(GameComponentsLookup.InitialSprintSpeed); } }
    public float InitialSprintSpeed { get { return initialSprintSpeed.Value; } }
    public bool hasInitialSprintSpeed { get { return HasComponent(GameComponentsLookup.InitialSprintSpeed); } }

    public GameEntity AddInitialSprintSpeed(float newValue) {
        var index = GameComponentsLookup.InitialSprintSpeed;
        var component = (Code.Gameplay.Features.Movement.InitialSprintSpeed)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.InitialSprintSpeed));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceInitialSprintSpeed(float newValue) {
        var index = GameComponentsLookup.InitialSprintSpeed;
        var component = (Code.Gameplay.Features.Movement.InitialSprintSpeed)CreateComponent(index, typeof(Code.Gameplay.Features.Movement.InitialSprintSpeed));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveInitialSprintSpeed() {
        RemoveComponent(GameComponentsLookup.InitialSprintSpeed);
        return this;
    }
}