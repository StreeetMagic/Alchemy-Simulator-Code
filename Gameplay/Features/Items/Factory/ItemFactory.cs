using System;
using System.Collections.Generic;
using Code.Common;
using Code.Gameplay.Features.Stats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Items.Factory
{
  public class ItemFactory
  {
    private readonly IIdentifierService _identifiers;

    public ItemFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity Create(ItemId typeId, Vector3 at)
    {
      switch (typeId)
      {
        case ItemId.Butterfly:
          return CreateButterfly(at);

        case ItemId.Unknown:
        default:
          throw new Exception($"Enemy with type id {typeId} does not exist");
      }
    }

    private GameEntity CreateButterfly(Vector3 at)
    {
      Dictionary<StatId, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[StatId.WalkSpeed] = 1);

      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddItem(ItemId.Butterfly)
          .AddWorldPosition(at)
          .AddBaseStats(baseStats)
          .AddStatModifiers(InitStats.EmptyStatDictionary())
          .AddInitialWalkSpeed(baseStats[StatId.WalkSpeed])
        ;
    }
  }
}