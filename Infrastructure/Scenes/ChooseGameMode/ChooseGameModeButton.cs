using Code.Infrastructure.Loading;
using Code.Infrastructure.Projects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Infrastructure.Scenes.ChooseGameMode
{
  public class ChooseGameModeButton : MonoBehaviour
  {
    public ConfigId ConfigId;
    public SceneId SceneId;

    [Inject] private SceneLoader _sceneLoader;
    [Inject] private ProjectData _projectData;
    
    private Button _button;

    private void Start()
    {
      _button = GetComponent<Button>();
      
      _button.onClick.AddListener(() =>
      {
        _projectData.ConfigId = ConfigId; 
        _projectData.InitialSceneId = SceneId; 
        
        _sceneLoader.Load(SceneId.LoadConfigs);
      });
    }
  }
}