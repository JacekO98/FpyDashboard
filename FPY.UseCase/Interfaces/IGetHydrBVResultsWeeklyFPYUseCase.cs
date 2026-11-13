using FPY.CoreBussines;

namespace FPY.UseCase.Interfaces
{
    public interface IGetHydrBVResultsWeeklyFpyUseCase
    {
        Task<List<WeeklyFpy>> ExecuteAsync();
    }
}