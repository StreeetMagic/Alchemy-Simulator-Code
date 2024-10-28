using UnityEngine;

namespace Code.Infrastructure.AudioServices.Sounds.Configs
{
  [CreateAssetMenu(fileName = "Sound", menuName = "ArtConfigs/Sound")]
  public class SoundArtConfig : ArtConfig<SoundArtSetup>
  {
    protected override void Validate()
    {
    }
  }
}