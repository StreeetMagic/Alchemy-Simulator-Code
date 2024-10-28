using Code.Infrastructure.AudioServices;
using Code.Infrastructure.ConfigProviders;
using Code.Infrastructure.Loading;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Scenes.LoadConfigs
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    private SceneLoader _sceneLoader;
    private BalanceConfigProvider _balanceConfigProvider;
    private ArtConfigProvider _artConfigProvider;
    private DevConfigProvider _devConfigProvider;
    private AudioService _audioService;

    [Inject]
    public void Construct(SceneLoader sceneLoader,
      BalanceConfigProvider balanceConfigProvider,
      ArtConfigProvider artConfigProvider,
      DevConfigProvider devConfigProvider,
      AudioService audioService)
    {
      _sceneLoader = sceneLoader;
      _balanceConfigProvider = balanceConfigProvider;
      _artConfigProvider = artConfigProvider;
      _devConfigProvider = devConfigProvider;
      _audioService = audioService;
    }

    public void Initialize()
    {
      _balanceConfigProvider.LoadConfigs();
      _artConfigProvider.LoadConfigs();
      _devConfigProvider.LoadConfigs();

      _audioService.Init();
      _sceneLoader.Load(SceneId.LoadProgress);
    }
  }
}