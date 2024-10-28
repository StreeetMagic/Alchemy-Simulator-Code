using System.Collections;
using System.Collections.Generic;
using Code.Infrastructure.CoroutineRunners;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Player.Systems
{
  public class PlayerCrouchSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _movers;
    private readonly IGroup<GameEntity> _cameras;

    private readonly List<GameEntity> _buffer = new(1);

    private readonly ICoroutineRunner _coroutineRunner;

    public PlayerCrouchSystem(GameContext game, ICoroutineRunner coroutineRunner)
    {
      _inputs = game.GetGroup(
        GameMatcher.AllOf(
          GameMatcher.UserInput,
          GameMatcher.CrouchKey));

      _movers = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.CharacterController,
            GameMatcher.StandingHeight,
            GameMatcher.CrouchHeight,
            GameMatcher.StandingCenter,
            GameMatcher.CrouchCenter,
            GameMatcher.TimeToCrouch)
          .NoneOf(GameMatcher.CrouchingAnimation));

      _cameras = game.GetGroup(
        GameMatcher
          .AllOf(
            GameMatcher.PlayerCamera,
            GameMatcher.Transform)
      );

      _coroutineRunner = coroutineRunner;
    }

    public void Execute()
    {
      foreach (GameEntity _ in _inputs)
      foreach (GameEntity camera in _cameras)
      foreach (GameEntity mover in _movers.GetEntities(_buffer))
      {
        if (mover.CharacterController.isGrounded)
          _coroutineRunner.StartCoroutine(CrouchStand(mover.CharacterController, mover, camera.Transform.position));
      }
    }

    private IEnumerator CrouchStand(CharacterController characterController, GameEntity mover, Vector3 cameraPosition)
    {
      if (mover.isCrouching && Physics.Raycast(cameraPosition, Vector3.up, 1f))
        yield break;

      mover.isCrouchingAnimation = true;

      float timeElapsed = 0;

      float targetHeight = mover.isCrouching
        ? mover.StandingHeight
        : mover.CrouchHeight;

      float currentHeight = characterController.height;

      Vector3 targetCenter = mover.isCrouching
        ? mover.StandingCenter
        : mover.CrouchCenter;

      Vector3 currentCenter = characterController.center;

      while (timeElapsed < mover.TimeToCrouch)
      {
        characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed / mover.TimeToCrouch);
        characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed / mover.TimeToCrouch);
        timeElapsed += Time.deltaTime;
        yield return null;
      }

      characterController.height = targetHeight;
      characterController.center = targetCenter;

      mover.isCrouching = !mover.isCrouching;

      mover.isCrouchingAnimation = false;
    }
  }
}