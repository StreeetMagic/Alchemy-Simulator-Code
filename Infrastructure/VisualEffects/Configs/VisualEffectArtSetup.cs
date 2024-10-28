using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Infrastructure.VisualEffects.Configs
{
  [Serializable]
  public class VisualEffectArtSetup : ArtSetup<VisualEffectId>
  {
    public List<ParticleSystem> Prefabs;
  }
}