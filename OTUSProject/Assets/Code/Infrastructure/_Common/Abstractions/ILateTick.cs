namespace Code.Infrastructure._Common.Abstractions
{
  public interface ILateTick : IMyReflection
  {
    void LateTick();
  }
}