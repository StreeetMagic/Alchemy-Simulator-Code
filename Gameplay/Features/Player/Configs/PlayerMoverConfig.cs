using UnityEngine;

namespace Code.Gameplay.Features.Player.Configs
{
  [CreateAssetMenu(fileName = "PlayerMover", menuName = "Configs/PlayerMover")]
  public class PlayerMoverConfig : ScriptableObject
  {
    [field: Header("Character Options")]
    [field: SerializeField]
    public bool CanSprint { get; private set; } = true;

    [field: SerializeField]
    public bool CanJump { get; private set; } = true;

    [field: SerializeField]
    public bool CanCrouch { get; private set; } = true;

    [field: SerializeField]
    public bool CanHeadBob { get; private set; } = true;

    [field: SerializeField]
    public bool CanInteract { get; private set; } = true;

    [field: SerializeField]
    public bool UseFootsteps { get; private set; } = true;

    [field: Header("Movement Parameters")]
    [field: SerializeField]
    public float WalkSpeed { get; private set; } = 3.0f;

    [field: SerializeField]
    public float SprintSpeed { get; private set; } = 6.0f;

    [field: SerializeField]
    public float CrouchSpeed { get; private set; } = 1.5f;

    [field: Header("Camera Parameters")]
    [field: SerializeField, Range(1, 10)]
    public float LookSpeedX { get; private set; } = 2.0f;

    [field: SerializeField, Range(1, 10)]
    public float LookSpeedY { get; private set; } = 2.0f;

    [field: SerializeField, Range(1, 180)]
    public float LowerLookLimit { get; private set; } = 80.0f;

    [field: SerializeField, Range(1, 180)]
    public float UpperLookLimit { get; private set; } = 80.0f;

    [field: Header("Jumping Parameters")]
    [field: SerializeField]
    public float JumpForce { get; private set; } = 8.0f;

    [field: SerializeField]
    public float Gravity { get; private set; } = 30.0f;

    [field: Header("Crouching Parameters")]
    [field: SerializeField]
    public float CrouchHeight { get; private set; } = 0.5f;

    [field: SerializeField]
    public float StandinghHeight { get; private set; } = 2f;

    [field: SerializeField]
    public float TimeToCrouch { get; private set; } = 0.25f;

    [field: SerializeField]
    public Vector3 CrouchCenter { get; private set; } = new Vector3(0, 0.5f, 0);

    [field: SerializeField]
    public Vector3 StandingCenter { get; private set; } = new Vector3(0, 0, 0);

    [field: Header("Headbob Parameters")]
    [field: SerializeField]
    public float WalkBobSpeed { get; private set; } = 14.0f;

    [field: SerializeField]
    public float WalkBobAmount { get; private set; } = 0.05f;

    [field: SerializeField]
    public float SprintBobSpeed { get; private set; } = 18.0f;

    [field: SerializeField]
    public float SprintBobAmount { get; private set; } = 0.11f;

    [field: Header("Footstep Parameters")]
    [field: SerializeField]
    public float BaseStepSpeed { get; private set; } = 0.5f;

    [field: SerializeField]
    public float CrouchStepMultiplier { get; private set; } = 1.5f;

    [field: SerializeField]
    public float SprintStepMultiplier { get; private set; } = 0.6f;

    [field: SerializeField]
    public AudioSource FootstepAudioSource { get; private set; }

    [field: SerializeField]
    public AudioClip[] WoodClips { get; private set; }

    [field: SerializeField]
    public AudioClip[] StoneClips { get; private set; }

    [field: SerializeField]
    public AudioClip[] WaterClips { get; private set; }

    [field: SerializeField]
    public AudioClip[] GrassClips { get; private set; }
  }
}