using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Highlight
{
  public sealed class HighlightFeature : Feature
  { 
    public HighlightFeature(ISystemFactory systems)
    {
      Add(systems.Create<HighlightHolderSetHighlightedSystem>());
      Add(systems.Create<HighlightHolderUnhighlightOnChangeGameModeSystem>());
      Add(systems.Create<HighlightHolderClearOnEmptyRaycasterSystem>());
      Add(systems.Create<HighlightHolderUnhighlightOnDistance>());
      
      Add(systems.Create<HighlightSystem>());
      Add(systems.Create<UnHighlightSystem>());
    }
  }
}