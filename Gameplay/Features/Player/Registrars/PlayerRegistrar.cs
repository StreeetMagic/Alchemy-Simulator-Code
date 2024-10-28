using Code.Common;
using Code.Gameplay.Features.Player.Configs;
using Code.Infrastructure.ConfigProviders;
using Code.Infrastructure.Prefabs;
using Code.Infrastructure.View.Registrars;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Gameplay.Features.Player.Registrars
{
  [RequireComponent(typeof(CharacterController))]
  public class PlayerRegistrar : EntityComponentRegistrar
  {
    [FormerlySerializedAs("_interractDistance")]
    [SerializeField]
    private float _interractRange;

    [SerializeField]
    private float _hightlightRange;

    private BalanceConfigProvider _balanceConfigProvider;

    [Inject]
    public void Construct(BalanceConfigProvider balanceConfigProvider)
    {
      _balanceConfigProvider = balanceConfigProvider;
    }

    public override void RegisterComponents()
    {
      PlayerMoverConfig config = _balanceConfigProvider.PlayerMover;

      Entity
        .AddViewId(PrefabId.Player)
        .AddWorldPosition(transform.position)
        .AddCharacterController(GetComponent<CharacterController>())
        .AddMoveDirection(Vector3.zero)
        .AddHorizontalDirection(Vector2.zero)
        .AddVerticalRotation(default)
        .AddHorizontalRotation(default)
        .AddPlayerHeadBobWalkTimer(default)
        .AddPlayerHeadBobSprintTimer(default)
        .AddCrouchHeight(config.CrouchHeight)
        .AddStandingHeight(config.StandinghHeight)
        .AddTimeToCrouch(config.TimeToCrouch)
        .AddCrouchCenter(config.CrouchCenter)
        .AddStandingCenter(config.StandingCenter)
        .AddInitialJumpForce(config.JumpForce)
        .AddInitialGravity(config.Gravity)
        .AddInitialWalkSpeed(config.WalkSpeed)
        .AddCurrentMoveSpeed(default)
        .AddInitialSprintSpeed(config.SprintSpeed)
        .AddInitialCrouchSpeed(config.CrouchSpeed)
        .AddWalkBobAmount(config.WalkBobAmount)
        .AddWalkBobSpeed(config.WalkBobSpeed)
        .AddSprintBobAmount(config.SprintBobAmount)
        .AddSprintBobSpeed(config.SprintBobSpeed)
        .AddHighlightHolder(default)
        .AddSingleRayCaster(default)
        .AddInitialInteractDistance(_interractRange)
        .AddInitialHighlightRange(_hightlightRange)
        .With(x => x.isAbleToSprint = config.CanSprint)
        .With(x => x.isAbleToJump = config.CanJump)
        .With(x => x.isAbleToCrouch = config.CanCrouch)
        .With(x => x.isAbleToHeadBob = config.CanHeadBob)
        .With(x => x.isUseFootSteps = config.UseFootsteps)
        .With(x => x.isPlayer = true)
        .With(x => x.isAbleToMove = true)
        .With(x => x.isMovableByCharacterController = true)
        ;
    }

    public override void UnregisterComponents()
    {
      throw new System.NotImplementedException();
    }
  }
}