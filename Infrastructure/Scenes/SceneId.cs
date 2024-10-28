namespace Code.Infrastructure.Scenes
{
  public enum SceneId
  {
    Unknown = 0,

    // ***************************************** //
    //INFRASTRUCTURE SCENES

    Initial = 1,
    Empty = 2,
    LoadConfigs = 4,
    LoadProgress = 5,

    // ***************************************** //

    Gameplay = 100,
    
    // ***************************************** //

    VladGameplayTest = 901,
    VladGameplayTestStarter = 1001,

    //

    ValeraGameplayTest = 902,
    ValeraGameplayTestStarter = 1002,

    //

    VovaGameplayTest = 904,
    VovaGameplayTestStarter = 1004,
  }
}