using Code.Common.Enums;
using Code.Gameplay.Features.Flasks.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Flasks.Monobehaviours
{
  public class MixingFlaskShaker : MonoBehaviour
  {
    [Inject] private MixingFlaskInputHandler _mixingFlaskInputHandler;
    
    public float RotationSpeed = 10; 
    public float TiltAngle = 30;
    public float TiltSpeed = 3; 

    private float _targetTiltAngle;
    private float _currentTiltAngle;

    private float _targetRotationY;
    private float _currentRotationY;

    private Quaternion _initialRotation;

    void Start()
    {
        _initialRotation = transform.rotation;
    }

    public void Tick()
    {
      if (_mixingFlaskInputHandler.GetClockWise(out ClockWiseDirectionId clockwiseDirection, out float length))
      {
        Rotate(clockwiseDirection, length);

        _targetTiltAngle = length > 20 
          ? TiltAngle 
          : 0f;
      }
      else
      {
        if (!Input.GetMouseButton(0))
          _targetTiltAngle = 0f;
      }

      SmoothTilt();
      SmoothRotate();

      Quaternion tiltRotation = Quaternion.Euler(_currentTiltAngle, 0f, 0f);
      Quaternion yawRotation = Quaternion.Euler(0f, _currentRotationY, 0f);

      transform.rotation = _initialRotation * yawRotation * tiltRotation;
    }

    private void Rotate(ClockWiseDirectionId clockwiseDirection, float length)
    {
      int multiplier = clockwiseDirection == ClockWiseDirectionId.Clockwise 
        ? 1 
        : -1;
    
      float rotationAmount = RotationSpeed * length * multiplier;
      _targetRotationY += rotationAmount * Time.deltaTime;
    }

    private void SmoothRotate()
    {
      _currentRotationY = Mathf.Lerp(_currentRotationY, _targetRotationY, Time.deltaTime * 5f);
    }

    private void SmoothTilt()
    {
      _currentTiltAngle = Mathf.Lerp(_currentTiltAngle, _targetTiltAngle, Time.deltaTime * TiltSpeed);
    }
  }
}
