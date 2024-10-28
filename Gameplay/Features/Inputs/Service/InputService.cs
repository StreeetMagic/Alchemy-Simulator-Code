using Code.Infrastructure.ConfigProviders;
using UnityEngine;

namespace Code.Gameplay.Features.Inputs.Service
{
  public class InputService : IInputService
  {
    private readonly BalanceConfigProvider _balanceConfigProvider;

    public float Vertical { get; private set; }
    public float Horizontal { get; private set; }
    public float MouseY { get; private set; }
    public float MouseX { get; private set; }

    public bool SprintKeyPressed { get; private set; }

    public bool InterractKeyDown { get; private set; }
    public bool JumpKeyDown { get; private set; }
    public bool CrouchKeyDown { get; private set; }
    public bool ExitKeyDown { get; private set; }

    public bool HasAxisInput => Vertical != 0 || Horizontal != 0;
    public bool HasMouseLook => MouseY != 0 || MouseX != 0;

    private InputService(BalanceConfigProvider balanceConfigProvider)
    {
      _balanceConfigProvider = balanceConfigProvider;
    }

    public void Tick()
    {
      Vertical = Input.GetAxis("Vertical");
      Horizontal = Input.GetAxis("Horizontal");
      MouseY = Input.GetAxis("Mouse Y");
      MouseX = Input.GetAxis("Mouse X");
      
      if (_balanceConfigProvider.IsLoaded == false)
        return;
        
      SprintKeyPressed = Input.GetKey(_balanceConfigProvider.Input.SprintKey);
      InterractKeyDown = Input.GetKey(_balanceConfigProvider.Input.InteractKey);

      JumpKeyDown = Input.GetKeyDown(_balanceConfigProvider.Input.JumpKey);
      CrouchKeyDown = Input.GetKeyDown(_balanceConfigProvider.Input.CrouchKey);
      ExitKeyDown = Input.GetKeyDown(_balanceConfigProvider.Input.ExitKey);
    }
  }
}