using Code.Infrastructure.ConfigProviders;
using Code.Infrastructure.RandomServices;
using UnityEngine;

namespace Code.Infrastructure.VisualEffects
{
  public class VisualEffectProvider
  {
    private readonly ArtConfigProvider _artConfigProvider;
    private readonly RandomService _randomService;

    public VisualEffectProvider(ArtConfigProvider artConfigProvider, RandomService randomService)
    {
      _artConfigProvider = artConfigProvider;
      _randomService = randomService;
    }

    public ParticleSystem Get(VisualEffectId id) => 
      _artConfigProvider
        .VisualEffects[id]
        .Prefabs[_randomService.GetRandomInt(_artConfigProvider.VisualEffects[id].Prefabs.Count - 1)];
  }
}