using System;
using System.Collections.Generic;
using Code.Infrastructure.AudioServices.AudioMixers;
using UnityEngine;

namespace Code.Infrastructure.AudioServices.Sounds.Configs
{
  [Serializable]
  public class SoundArtSetup : ArtSetup<SoundId>
  {
    public AudioMixerGroupId AudioMixerGroupId;

    [Range(0f, 1f)] public float Volume;
    public List<AudioClip> AudioClips;
  }
}