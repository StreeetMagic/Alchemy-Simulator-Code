using System.Collections.Generic;
using Code.Gameplay.Features.Items;
using Entitas;

namespace Code.Gameplay.Features.Alchemy
{
  /// <summary>
  /// Из них можно получить Reagent
  /// </summary>
  [Game] public class Element : IComponent { }
  
  /// <summary>
  ///  Из них можно получить Potion 
  /// </summary>
  [Game] public class Reagent : IComponent { }
  
  [Game] public class Draft : IComponent {public Dictionary<ItemId, int> Value;}
  
  [Game] public class Potion : IComponent { }
}