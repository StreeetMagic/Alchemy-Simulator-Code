using UnityEngine;

namespace Code.Cooking
{
  public class AlchemyCookingHeadsUpDisplayView : MonoBehaviour
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