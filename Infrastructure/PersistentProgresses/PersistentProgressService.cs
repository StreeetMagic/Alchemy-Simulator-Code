using Code.Infrastructure.ConfigProviders;
using UnityEngine;

namespace Code.Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    private readonly BalanceConfigProvider _balanceConfigProvider;

    public PersistentProgressService(BalanceConfigProvider balanceConfigProvider)
    {
      _balanceConfigProvider = balanceConfigProvider;
    }

    public ProjectProgress ProjectProgress { get; private set; }

    public void LoadProgress(string getString) =>
      ProjectProgress = JsonUtility.FromJson<ProjectProgress>(getString);

    public void SetDefault()
    {
      ProjectProgress = new ProjectProgress
        (
        )
        ;

      Debug.Log(nameof(_balanceConfigProvider));
    }
  }
}