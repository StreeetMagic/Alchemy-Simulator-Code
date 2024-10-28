using Entitas;

namespace Code.Gameplay.Features.Systems
{
  public class ReplaceAudioListenerToActiveCameraSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _audioListeners;
    private readonly IGroup<GameEntity> _cameras;

    public ReplaceAudioListenerToActiveCameraSystem(GameContext game)
    {
      _audioListeners = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.AudioListener,
          GameMatcher.Transform));

      _cameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.ActiveCamera,
          GameMatcher.Transform));
    }

    public void Execute()
    {
      foreach (GameEntity audioListener in _audioListeners)
      foreach (GameEntity camera in _cameras)
      {
        audioListener.Transform.position = camera.Transform.position;
      }
    }
  }
}