using FPY.CoreBussines;

namespace FPY.UseCase.Interfaces
{
    public interface IGetPneuResultsWeeklyFpyUseCase
    {
        Task<List<WeeklyFpy>> ExecuteAsync();
    }
}