using System.Collections.Generic;

namespace Code.Infrastructure.SaveLoadServices
{
  public interface ISaveLoadService
  {
    List<IProgressReader> ProgressReaders { get; }
    void SaveProgress(string saver);
    void LoadProgress();
    void DeleteSaves();
  }
}