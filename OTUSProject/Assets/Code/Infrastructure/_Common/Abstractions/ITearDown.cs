namespace Code.Infrastructure._Common.Abstractions
{
  public interface ITearDown : IMyReflection
  {
    void TearDown();
  }
}