//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCameraInitialLookSpeedY;

    public static Entitas.IMatcher<GameEntity> CameraInitialLookSpeedY {
        get {
            if (_matcherCameraInitialLookSpeedY == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CameraInitialLookSpeedY);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCameraInitialLookSpeedY = matcher;
            }

            return _matcherCameraInitialLookSpeedY;
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

    public Code.Gameplay.Features.CameraInitialLookSpeedY cameraInitialLookSpeedY { get { return (Code.Gameplay.Features.CameraInitialLookSpeedY)GetComponent(GameComponentsLookup.CameraInitialLookSpeedY); } }
    public float CameraInitialLookSpeedY { get { return cameraInitialLookSpeedY.Value; } }
    public bool hasCameraInitialLookSpeedY { get { return HasComponent(GameComponentsLookup.CameraInitialLookSpeedY); } }

    public GameEntity AddCameraInitialLookSpeedY(float newValue) {
        var index = GameComponentsLookup.CameraInitialLookSpeedY;
        var component = (Code.Gameplay.Features.CameraInitialLookSpeedY)CreateComponent(index, typeof(Code.Gameplay.Features.CameraInitialLookSpeedY));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCameraInitialLookSpeedY(float newValue) {
        var index = GameComponentsLookup.CameraInitialLookSpeedY;
        var component = (Code.Gameplay.Features.CameraInitialLookSpeedY)CreateComponent(index, typeof(Code.Gameplay.Features.CameraInitialLookSpeedY));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCameraInitialLookSpeedY() {
        RemoveComponent(GameComponentsLookup.CameraInitialLookSpeedY);
        return this;
    }
}