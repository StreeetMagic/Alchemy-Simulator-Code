using UnityEngine;

namespace Code.Infrastructure.CoroutineRunners
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    public void Dispose()
    {
      StopAllCoroutines();
    }
  }
}