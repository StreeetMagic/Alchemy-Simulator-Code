using Plugins.SoftKitty.InventoryEngine.Scripts.Core;
using Object = UnityEngine.Object;

namespace Code.Gameplay.Features.Inventories
{
  public class InventoryService
  {
    public bool IsOpened { get; private set; }

    public void ToggleInventory()
    {
      UiWindow openWindow = ItemManager.PlayerInventoryHolder.OpenWindow();

      if (openWindow != null)
      {
        IsOpened = true;
      }
      else
      {
        var windowsManager = Object.FindObjectOfType<WindowsManager>();

        if (windowsManager)
          Object.Destroy(windowsManager.gameObject);

        IsOpened = false;
      }
    }
  }
}