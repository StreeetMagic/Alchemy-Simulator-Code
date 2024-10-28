using UnityEngine;

namespace Code.Shaking
{
  public class AlchemyShakingHeadsUpDisplayView : MonoBehaviour
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