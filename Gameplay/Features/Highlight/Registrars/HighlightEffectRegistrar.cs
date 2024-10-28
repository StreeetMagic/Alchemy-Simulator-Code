using Code.Infrastructure.View.Registrars;
using HighlightPlus;
using UnityEngine;

namespace Code.Gameplay.Features.Highlight.Registrars
{
  public class HighlightEffectRegistrar : EntityComponentRegistrar
  {
    [SerializeField]
    private HighlightEffect _highlightEffect;

    public override void RegisterComponents()
    {
      Entity.AddHighlightEffect(_highlightEffect);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasHighlightEffect)
        Entity.RemoveHighlightEffect(); 
    }
  }
}