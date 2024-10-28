using Zenject;

namespace Code.Gameplay.Features.Inputs.Service
{
  public interface IInputService : ITickable
  {
    float Vertical { get; }
    float Horizontal { get; }
  
    float MouseY { get; }
    float MouseX { get; }
  
    bool SprintKeyPressed { get; }
    bool InterractKeyDown { get; }
    bool JumpKeyDown { get; }
    bool CrouchKeyDown { get; }
    bool HasAxisInput { get; }
    bool HasMouseLook { get; }
    bool ExitKeyDown { get; }
  }
}