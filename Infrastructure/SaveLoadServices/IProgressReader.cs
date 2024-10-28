using Code.Infrastructure.PersistentProgresses;

namespace Code.Infrastructure.SaveLoadServices
{
  public interface IProgressReader
  {
    void ReadProgress(ProjectProgress projectProgress);
  }
}