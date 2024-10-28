using UnityEngine;

namespace Code.Gameplay.Features.Player
{
  public class PlayerVisualsToggler : MonoBehaviour
  {
    [SerializeField]
    private GameObject[] _visuals;

    public void Enable()
    {
      foreach (GameObject visual in _visuals)
      {
        if (!visual.activeSelf)
          visual.SetActive(true);
      }
    }

    public void Disable()
    {
      foreach (GameObject visual in _visuals)
      {
        if (visual.activeSelf)
          visual.SetActive(false);
      }
    }
  }
}