using System;

namespace Code.Infrastructure
{
  [Serializable]
  public class ArtSetup<T> where T : Enum
  {
    public T Id;
  }
}