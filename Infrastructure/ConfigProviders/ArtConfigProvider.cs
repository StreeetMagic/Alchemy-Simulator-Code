using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.AssetProviders;
using Code.Infrastructure.AudioServices.AudioMixers;
using Code.Infrastructure.AudioServices.Sounds;
using Code.Infrastructure.AudioServices.Sounds.Configs;
using Code.Infrastructure.Loggers;
using Code.Infrastructure.VisualEffects;
using Code.Infrastructure.VisualEffects.Configs;

namespace Code.Infrastructure.ConfigProviders
{
  public class ArtConfigProvider
  {
    private readonly IAssetProvider _assetProvider;

    public ArtConfigProvider(IAssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public Dictionary<AudioMixerGroupId, AudioMixerGroupArtSetup> AudioMixerGroups { get; private set; }
    public Dictionary<SoundId, SoundArtSetup> Sounds { get; private set; }
    public Dictionary<VisualEffectId, VisualEffectArtSetup> VisualEffects { get; private set; }
    
    public void LoadConfigs()
    {
      AudioMixerGroups = Load<AudioMixerGroupId, AudioMixerGroupArtSetup, AudioMixerGroupArtConfig>();
      Sounds = Load<SoundId, SoundArtSetup, SoundArtConfig>();
      VisualEffects = Load<VisualEffectId, VisualEffectArtSetup, VisualEffectArtConfig>();
    }

    private Dictionary<T, T1> Load<T, T1, T2>()
      where T2 : ArtConfig<T1>
      where T1 : ArtSetup<T>
      where T : Enum
    {
      Dictionary<T, T1> artSetups = _assetProvider.GetArtScriptable<T2>().Setups.ToDictionary(setup => setup.Id, setup => setup);

      ValidateUnknownKeys<T, T1, T2>(artSetups);

      IEnumerable<T> lostConfigs = GetEnums(artSetups.Keys.ToList());

      IEnumerable<T> enumerable = lostConfigs as T[] ?? lostConfigs.ToArray();

      if (enumerable.Any())
        new DebugLogger().LogWarning(typeof(T).Name + " Не хватает арт конфигов: " + string.Join(", ", enumerable));

      return artSetups;
    }

    private void ValidateUnknownKeys<T, T1, T2>(Dictionary<T, T1> artSetups)
      where T2 : ArtConfig<T1>
      where T1 : ArtSetup<T>
      where T : Enum
    {
      if (artSetups.Keys.All(id => Convert.ToInt32(id) != 0))
        return;

      new DebugLogger().LogError("В " + typeof(T2).Name + " присутствуют Unknown Keys: ");
    }

    private IEnumerable<T> GetEnums<T>(List<T> keys) where T : Enum
    {
      T[] allEnums = Enum.GetValues(typeof(T)).Cast<T>().Where(x => Convert.ToInt32(x) != 0).ToArray();

      T[] existEnums = allEnums
        .Where(keys.Contains)
        .ToArray();

      return allEnums.Except(existEnums).ToArray();
    }
  }
}