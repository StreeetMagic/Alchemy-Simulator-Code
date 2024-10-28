using System;
using Entitas;

namespace Code.Gameplay.Features.Systems
{
  public class ToggleCameraSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _togglers;
    private readonly IGroup<GameEntity> _playerCameras;
    private readonly IGroup<GameEntity> _interactCameras;

    public ToggleCameraSystem(GameContext game)
    {
      _togglers = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.CameraToggler,
          GameMatcher.CameraId));

      _playerCameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.PlayerCamera,
          GameMatcher.Camera,
          GameMatcher.CameraId));

      _interactCameras = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.InteractCamera,
          GameMatcher.Camera,
          GameMatcher.CameraId));
    }

    public void Execute()
    {
      foreach (GameEntity playerCamera in _playerCameras)
      foreach (GameEntity interactCamera in _interactCameras)
      foreach (GameEntity toggler in _togglers)
      {
        switch (toggler.CameraId)
        {
          case CameraId.Player:

            if (!playerCamera.Camera.gameObject.activeSelf)
            {
              playerCamera.isActiveCamera = true;
              playerCamera.Camera.gameObject.SetActive(true);
            }

            if (interactCamera.Camera.gameObject.activeSelf)
            {
              interactCamera.isActiveCamera = false;
              interactCamera.Camera.gameObject.SetActive(false);
            }

            break;

          case CameraId.Interact:

            if (!interactCamera.Camera.gameObject.activeSelf)
            {
              interactCamera.isActiveCamera = true;
              interactCamera.Camera.gameObject.SetActive(true);
            }

            if (playerCamera.Camera.gameObject.activeSelf)
            {
              playerCamera.isActiveCamera = false;
              playerCamera.Camera.gameObject.SetActive(false);
            }

            break;

          case CameraId.Unknown:
          default:
            throw new ArgumentOutOfRangeException();
        }
      }
    }
  }
}