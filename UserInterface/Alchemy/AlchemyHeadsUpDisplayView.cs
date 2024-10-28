using UnityEngine;
using UnityEngine.UI;

namespace Code
{
  public class AlchemyHeadsUpDisplayView : MonoBehaviour
  {
    [field: SerializeField]
    public Button ExitAlchemyTableButton { get; private set; }      
    
    [field: SerializeField]
    public Button EnterIdleButton { get; private set; }   
  }
}