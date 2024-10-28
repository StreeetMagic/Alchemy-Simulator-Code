using UnityEngine;
using UnityEngine.UI;

namespace Code.Idle
{
  public class AlchemyIdleHeadsUpDisplayView : MonoBehaviour
  {
    [field: SerializeField]
    public Button EnterAlchemyMixingStateButton { get; private set; }

    [field: SerializeField]
    public Button EnterAlchemyCookingStateButton { get; private set; }

    [field: SerializeField]
    public Button EnterAlchemyShakingStateButton { get; private set; }

    [field: SerializeField]
    public Button EnterAlchemyPreparingStateButton { get; private set; }

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