using System;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Projects;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Scenes.LoadProgress
{
  public class LoadProgressInitializer : MonoBehaviour, IInitializable
  {
    private SceneLoader _sceneLoader;

    private ProjectData _projectData;

    [Inject]
    public void Construct(SceneLoader sceneLoader, ProjectData projectData)
    {
      _sceneLoader = sceneLoader;
      _projectData = projectData;
    }

    public void Initialize()
    {
      LoadScene();
    }

    private void LoadScene()
    {
      switch (_projectData.InitialSceneId)
      {
        case SceneId.Unknown:
          throw new Exception("Unknown scene id");

        case SceneId.Gameplay:
          _sceneLoader.Load(SceneId.Gameplay);
          break;

        case SceneId.VladGameplayTest:
          _sceneLoader.Load(SceneId.VladGameplayTest);
          break;

        case SceneId.ValeraGameplayTest:
          _sceneLoader.Load(SceneId.ValeraGameplayTest);
          break;

        case SceneId.VovaGameplayTest:
          _sceneLoader.Load(SceneId.VovaGameplayTest);
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}