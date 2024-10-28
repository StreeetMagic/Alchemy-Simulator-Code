using UnityEngine;

namespace Code.Infrastructure.Prefabs
{
  [CreateAssetMenu(fileName = "Prefab", menuName = "ArtConfigs/Prefab")]
  public class PrefabArtConfig : ScriptableObject
  {
    public PrefabSetup[] Prefabs;
  }
}