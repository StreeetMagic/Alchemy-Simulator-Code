using Code.Infrastructure.PersistentProgresses;

namespace Code.Infrastructure.SaveLoadServices
{
  public interface IProgressWriter : IProgressReader
  {
    void WriteProgress(ProjectProgress projectProgress);
  }
}