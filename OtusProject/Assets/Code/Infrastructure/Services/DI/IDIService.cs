using Zenject;

namespace Code.Infrastructure.Services.DI
{
  public interface IDIService
  {
    DiContainer Container { get; }
  }
}