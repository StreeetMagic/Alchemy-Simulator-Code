using Code.Gameplay.Features.Inputs;
using Code.Gameplay.Features.Player.Configs;
using Code.Infrastructure.AssetProviders;
using Code.Infrastructure.PersistentProgresses;
using Code.Infrastructure.Projects;
using UnityEngine;

namespace Code.Infrastructure.ConfigProviders
{
  public class BalanceConfigProvider
  {
    private readonly ProjectData _projectData;
    private readonly IAssetProvider _assetProvider;

    public BalanceConfigProvider(ProjectData projectData, IAssetProvider assetProvider)
    {
      _projectData = projectData;
      _assetProvider = assetProvider;
    }

    public bool IsLoaded { get; private set; }

    public ProjectConfig Project { get; private set; }
    public InputConfig Input { get; private set; }
    public PlayerMoverConfig PlayerMover { get; private set; }

    public void LoadConfigs()
    {
      //  Companions = LoadAll<CompanionId, CompanionConfig>(companionConfig => companionConfig.Id, true);

      Project = Load<ProjectConfig>();
      Input = Load<InputConfig>();
      PlayerMover = Load<PlayerMoverConfig>();

      IsLoaded = true;
    }

    private T Load<T>() where T : ScriptableObject
    {
      string name = typeof(T).Name;
      name = name.Replace("Config", "");
      string path = _projectData.ConfigId + "/" + name;

      T config = _assetProvider.GetScriptable<T>(path);
      return config;
    }

    // private Dictionary<T1, T2> LoadAll<T1, T2>(Func<T2, T1> predicate, bool check) where T1 : Enum where T2 : ScriptableObject
    // {
    //   string name = typeof(T2).Name;
    //
    //   name = name.Replace("Config", "");
    //
    //   string path = _projectData.ConfigId + "/" + name;
    //
    //   Dictionary<T1, T2> configMap = _assetProvider.GetScriptables<T2>(path).ToDictionary(predicate, x => x);
    //
    //   IEnumerable<T1> lostConfigs = GetEnums(configMap.Keys.ToList());
    //
    //   IEnumerable<T1> enumerable = lostConfigs as T1[] ?? lostConfigs.ToArray();
    //
    //   if (enumerable.Any() && check)
    //     new DebugLogger().LogWarning(path + " Не хватает конфигов: " + string.Join(", ", enumerable));
    //
    //   return configMap;
    // }

    // private IEnumerable<T> GetEnums<T>(List<T> keys) where T : Enum
    // {
    //   T[] allEnums = Enum.GetValues(typeof(T)).Cast<T>().Where(x => Convert.ToInt32(x) != 0).ToArray();
    //
    //   T[] existEnums =
    //     allEnums
    //       .Where(keys.Contains)
    //       .ToArray();
    //
    //   return allEnums.Except(existEnums).ToArray();
    // }
  }
}