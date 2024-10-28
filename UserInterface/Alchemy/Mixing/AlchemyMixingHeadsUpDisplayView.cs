using UnityEngine;

namespace Code.Mixing
{
  public class AlchemyMixingHeadsUpDisplayView : MonoBehaviour
  {
    public void Hide()
    {
      if (gameObject.activeSelf)
        gameObject.SetActive(false);
    }

    public void Show()
    {
      if (gameObject.activeSelf == false)
        gameObject.SetActive(true);
    }
  }
}