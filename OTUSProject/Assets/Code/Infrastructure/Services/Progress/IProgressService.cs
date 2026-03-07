using Code.Infrastructure.Data;

namespace Code.Infrastructure.Services.Progress
{
  public interface IProgressService
  {
    PlayerProgress PlayerProgress { get; set; }
  }
}