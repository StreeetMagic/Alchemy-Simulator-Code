using UnityEngine;

namespace Code.Preparation
{
  public class AlchemyPreparationHeadsUpDisplayView : MonoBehaviour
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