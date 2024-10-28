using System.Collections.Generic;
using Code.Infrastructure.Scenes;

namespace Code.Infrastructure.Projects
{
  public class ProjectData
  {
    private readonly Dictionary<SceneId, SceneTypeId> _scenes = new()
    {
      { SceneId.Gameplay, SceneTypeId.Core },
      { SceneId.VladGameplayTest, SceneTypeId.Core },
      { SceneId.ValeraGameplayTest, SceneTypeId.Core },
      { SceneId.VovaGameplayTest, SceneTypeId.Core },

      { SceneId.Unknown, SceneTypeId.Infrastructure },
      { SceneId.Initial, SceneTypeId.Infrastructure },
      { SceneId.Empty, SceneTypeId.Infrastructure },
      { SceneId.LoadConfigs, SceneTypeId.Infrastructure },
      { SceneId.LoadProgress, SceneTypeId.Infrastructure },
    };

    public SceneId InitialSceneId { get; set; }
    public ConfigId ConfigId { get; set; }

    public SceneTypeId GetGameLoopSceneTypeId(SceneId sceneId) =>
      _scenes[sceneId];
  }
}