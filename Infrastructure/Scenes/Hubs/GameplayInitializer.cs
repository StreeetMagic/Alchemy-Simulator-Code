using System.Collections.Generic;
using Code.Common;
using Code.Gameplay.Features.Items;
using Code.Infrastructure.Loading;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Scenes.Hubs
{
  public class GameplayInitializer : MonoBehaviour
  {
    private SceneLoader _sceneLoader;

    [Inject]
    public void Construct(SceneLoader sceneLoader, GameplayInstaller gameplayInstaller)
    {
      _sceneLoader = sceneLoader;
    }

    private void Start()
    {
      Time.timeScale = 1f;

      CreateEntity
        .Empty()
        .AddInventory(new Dictionary<ItemId, int>());
    }

    public void Restart()
    {
      Destroy();

      _sceneLoader.Load(SceneId.LoadProgress);
    }

    private void Destroy()
    {
      DOTween.KillAll();
      Time.timeScale = 0f;
    }
  }
}