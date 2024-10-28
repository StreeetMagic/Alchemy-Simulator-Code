using Entitas;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerFootstepSystem : IExecuteSystem
  {
    // private readonly IGroup<GameEntity> _inputs;
    // private readonly IGroup<GameEntity> _movers;
    // private readonly IGroup<GameEntity> _cameras;
    //
    // private float _footstepTimer;
    //
    // public PlayerFootstepSystem(GameContext game)
    // {
    //   _inputs = game.GetGroup(
    //     GameMatcher.AllOf(
    //       GameMatcher.UserInput));
    //
    //   _movers = game.GetGroup(
    //     GameMatcher.AllOf(
    //       GameMatcher.Player,
    //       GameMatcher.AbleToMove,
    //       GameMatcher.CharacterController,
    //       GameMatcher.PlayerMoverConfig,
    //       GameMatcher.HorizontalDirection));
    //
    //   _cameras = game.GetGroup(
    //     GameMatcher.AllOf(
    //       GameMatcher.PlayerCamera,
    //       GameMatcher.Transform));
    // }
    //
    public void Execute()
    {
      //   foreach (GameEntity camera in _cameras)
      //   foreach (GameEntity input in _inputs)
      //   foreach (GameEntity mover in _movers)
      //   {
      //     if (mover.PlayerMoverConfig.UseFootsteps && input.isSprintKey)
      //       HandleFootsteps(true, mover.CharacterController, mover, camera.Transform.position);
      //     else
      //       HandleFootsteps(false, mover.CharacterController, mover, camera.Transform.position);
      //   }
    }
    //
    // private void HandleFootsteps(bool keyPressed, CharacterController characterController, GameEntity mover, Vector3 cameraPosition)
    // {
    //   if (!characterController.isGrounded)
    //     return;
    //
    //   if (mover.HorizontalDirection == Vector2.zero)
    //     return;
    //
    //   _footstepTimer -= Time.deltaTime;
    //
    //   if (_footstepTimer <= 0)
    //   {
    //     if (Physics.Raycast(cameraPosition, Vector3.down, out RaycastHit hit, 2))
    //     {
    //       switch (hit.collider.tag)
    //       {
    //         case "Footsteps/Grass":
    //           mover.PlayerMoverConfig.FootstepAudioSource.PlayOneShot(mover.PlayerMoverConfig.GrassClips[Random.Range(0, mover.PlayerMoverConfig.GrassClips.Length - 1)]);
    //           break;
    //
    //         case "Footsteps/Stone":
    //           mover.PlayerMoverConfig.FootstepAudioSource.PlayOneShot(mover.PlayerMoverConfig.StoneClips[Random.Range(0, mover.PlayerMoverConfig.StoneClips.Length - 1)]);
    //           break;
    //
    //         case "Footsteps/Water":
    //           mover.PlayerMoverConfig.FootstepAudioSource.PlayOneShot(mover.PlayerMoverConfig.WaterClips[Random.Range(0, mover.PlayerMoverConfig.WaterClips.Length - 1)]);
    //           break;
    //
    //         case "Footsteps/Wood":
    //           mover.PlayerMoverConfig.FootstepAudioSource.PlayOneShot(mover.PlayerMoverConfig.WoodClips[Random.Range(0, mover.PlayerMoverConfig.WoodClips.Length - 1)]);
    //           break;
    //
    //         // default:
    //         //   _footstepAudioSource.PlayOneShot(_grassClips[Random.Range(0, _grassClips.Length - 1)]);
    //         //   break;
    //       }
    //     }
    //
    //     if (mover.isCrouching)
    //       _footstepTimer = mover.PlayerMoverConfig.BaseStepSpeed * mover.PlayerMoverConfig.CrouchStepMultiplier;
    //     else
    //     {
    //       if (mover.PlayerMoverConfig.CanSprint && keyPressed)
    //         _footstepTimer = mover.PlayerMoverConfig.BaseStepSpeed * mover.PlayerMoverConfig.SprintStepMultiplier;
    //       else
    //         _footstepTimer = mover.PlayerMoverConfig.BaseStepSpeed;
    //     }
    //   }
    // }
  }
}