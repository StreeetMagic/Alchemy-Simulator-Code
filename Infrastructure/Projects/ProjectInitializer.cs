using System;
using Code.Gameplay.Features.Inputs.Service;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Infrastructure.Projects
{
  public class ProjectInitializer : MonoBehaviour, IInitializable
  {
    private TickableManager _tickableManager;
    private IInputService _inputService;
    private SceneLoader _sceneLoader;
    private ProjectData _projectData;

    [Inject]
    private void Construct(TickableManager tickableManager, IInputService inputService,
      SceneLoader sceneLoader, ProjectData projectData)
    {
      _tickableManager = tickableManager;
      _inputService = inputService;
      _sceneLoader = sceneLoader;
      _projectData = projectData;
    }

    public void Initialize()
    {
      string sceneName = SceneManager.GetActiveScene().name;

      switch (sceneName)
      {
        case nameof(SceneId.Initial):
          InitializeProject(ConfigId.Default, SceneId.Gameplay);
          break;

#if UNITY_EDITOR
        case nameof(SceneId.VladGameplayTestStarter):
          InitializeProject(ConfigId.Vlad, SceneId.VladGameplayTest);
          break;

        case nameof(SceneId.ValeraGameplayTestStarter):
          InitializeProject(ConfigId.Valera, SceneId.ValeraGameplayTest);
          break;

        case nameof(SceneId.VovaGameplayTestStarter):
          InitializeProject(ConfigId.Vova, SceneId.VovaGameplayTest);
          break;
#endif

        default:
          throw new Exception("С этой сцены нельзя стартовать");
      }
    }

    private void InitializeProject(ConfigId configId, SceneId initialSceneId)
    {
      // switch (BuildType)
      // {
      //
      //   case BuildTypeId.Creative:
      //     Debug.Log("В креативном билде FireBase не работает");
      //     break;
      //
      //   case BuildTypeId.Unknown:
      //   default:
      //     throw new Exception("В префабе ProjectContext (ProjectInitializer) не указан тип сборки (BuildType)");
      // }

      _tickableManager.Add(_inputService);
      _projectData.ConfigId = configId;
      _projectData.InitialSceneId = initialSceneId;
      _sceneLoader.Load(SceneId.LoadConfigs);
    }
  }
}