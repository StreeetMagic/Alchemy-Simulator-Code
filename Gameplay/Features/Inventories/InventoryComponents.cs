using System.Collections.Generic;
using Code.Gameplay.Features.Items;
using Entitas;

namespace Code.Gameplay.Features.Inventories
{
  [Game] public class Inventory : IComponent {public Dictionary<ItemId, int> Value;}
}

