using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Items.Systems
{
  public class OnItemInteractSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _items;
    private readonly IGroup<GameEntity> _inventories;

    public OnItemInteractSystem(GameContext game)
    {
      _items = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Item,
          GameMatcher.Interacted));

      _inventories = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Inventory));
    }

    public void Execute()
    {
      foreach (GameEntity inventory in _inventories)
      foreach (GameEntity item in _items)
      {
        Add(item.Item, inventory.Inventory);

        item.isDestructed = true;
      }
    }

    private void Add(ItemId id, Dictionary<ItemId, int> inventory)
    {
      if (inventory.TryAdd(id, 1))
        return;

      inventory[id]++;
    }
  }
}