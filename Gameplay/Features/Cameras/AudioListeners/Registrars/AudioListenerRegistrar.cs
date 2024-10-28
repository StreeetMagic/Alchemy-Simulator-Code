using Code.Infrastructure.View.Registrars;
using UnityEngine;

namespace Code.Gameplay.Features.AudioListeners.Registrars
{
  public class AudioListenerRegistrar : EntityComponentRegistrar
  {
    [SerializeField]
    private AudioListener _listener;

    public override void RegisterComponents()
    {
      Entity.AddAudioListener(_listener);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasAudioListener)
        Entity.RemoveAudioListener();
    }
  }
}