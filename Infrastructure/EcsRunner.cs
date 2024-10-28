using Code.Gameplay;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
  public class EcsRunner : MonoBehaviour
  {
    private GameplayFeature _gameplayFeature;
    private ISystemFactory _systemFactory;

    [Inject]
    private void Construct(ISystemFactory systemFactory)
    {
      _systemFactory = systemFactory;
    }
    
    private void Start()
    {
      _gameplayFeature = _systemFactory.Create<GameplayFeature>();
      _gameplayFeature.Initialize();
    }

    private void Update()
    {
      _gameplayFeature.Execute();
      _gameplayFeature.Cleanup();
    }

    private void OnDestroy()
    {
      _gameplayFeature.TearDown();
    }
  }
}